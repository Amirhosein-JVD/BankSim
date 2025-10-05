using Banksim.Grain.Abstractions;
using Banksim.Grain.Accounts;
using BankSim.Api.Models;
using BankSim.Api.Models.Requestes;
using BankSim.Domain.Abstractions;
using BankSim.Domain.Account;
using BankSim.Domain.Services;
using BankSim.Domain.ValueObjects;
using BankSim.Infrastructure.Persistence;
using Microsoft.AspNetCore.Mvc;
using NATS.Client.JetStream.Models;
using NATS.Net;
using System.Reflection;
using System.Threading.Tasks;


namespace BankSim.Api.Controllers
{
    /// <summary>
    /// Controllers of accounts
    /// </summary>

    [ApiController]
    [Route("api/[controller]")]
    public class AccountsController : ControllerBase
    {
        /// <summary>
        /// The account store
        /// </summary>
        private readonly IAccountStore _accountStore;

        /// <summary>
        /// The statement service
        /// </summary>
        private readonly IStatementService _statementService;

        /// <summary>
        /// The account factory service
        /// </summary>
        private readonly IAccountFactoryService _accountFactoryService;

        /// <summary>
        /// The cluster client
        /// </summary>
        private readonly IClusterClient _clusterClient;


        /// <summary>
        /// Initializes a new instance of the <see cref="AccountsController"/> class.
        /// </summary>
        /// <param name="accountStore">The account store.</param>
        /// <param name="statementService">The statement service.</param>
        /// <param name="accountFactoryService">The account factory service.</param>
        /// <param name="clusterClient">The cluster client.</param>
        public AccountsController(IAccountStore accountStore,
            IStatementService statementService,
            IAccountFactoryService accountFactoryService,
            IClusterClient clusterClient)
        {
            _accountStore = accountStore;
            _statementService = statementService;
            _accountFactoryService = accountFactoryService;
            _clusterClient = clusterClient;
        }

        /// <summary>
        /// Gets all.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<AccountResponseDto>), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public ActionResult<ApiResult<IEnumerable<AccountBase>>> GetAllAccounts()
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var accounts = _accountStore.GetAll();
            return Ok(ApiResult<IEnumerable<AccountBase>>.Ok(accounts ,HttpContext.TraceIdentifier));
       
        }

        /// <summary>
        /// Gets the account by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(AccountResponseDto), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public ActionResult<ApiResult<AccountResponseDto>> GetAccountById(Guid id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ApiResult<AccountRequestDto>.Fail("Model isn't valid", HttpContext.TraceIdentifier));

         
            var account = _accountStore.Get(id);
            if (account == null)
                return NotFound(ApiResult<AccountResponseDto>.Fail("account not found!", HttpContext.TraceIdentifier)); 
                
            return Ok(ApiResult<AccountRequestDto>.Ok(AccountRequestDto.ToDto(account.Owner, account.Balance), HttpContext.TraceIdentifier));
         
        }

        /// <summary>
        /// Adds the account.
        /// </summary>
        /// <param name="dto">The dto.</param>
        /// <param name="accountType">Type of the account.</param>
        /// <returns></returns>
        /// <exception cref="BankSim.Domain.Exceptions.DomainException">Acconut not founded!</exception>
        [HttpPost]
        [ProducesResponseType(200)] 
        [ProducesResponseType(400)] 
        [ProducesResponseType(404)] 
        [ProducesResponseType(500)] 
        public async Task<ActionResult<ApiResult<string>>> AddAccount(AccountRequestDto dto, AccountTypesEnum accountType)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            
            Guid accountGrainId = Guid.NewGuid();
            IAccountGrain account =  _clusterClient.GetGrain<IAccountGrain>(accountGrainId);
            await account.Deposit(dto.Balance.Amount, dto.Balance.Currency);

            await using NatsClient client = new NatsClient();

            await client.PublishAsync<string>(subject: $"users.{await account.GetOwner()}", data: $"Balance: {await account.GetBalance()}, Owner: {await account.GetOwner()}");

            _accountStore.Add(_accountFactoryService.AccountFactory(dto.Owner, dto.Balance.Amount, (int) dto.Balance.Currency, (int) accountType));
            return Ok(ApiResult<string>.Ok("Adding account is success!", HttpContext.TraceIdentifier));
  
        }

    }
}
