using BankSim.Api.Models;
using BankSim.Api.Models.Requestes;
using BankSim.Domain.Abstractions;
using BankSim.Domain.Account;
using BankSim.Domain.Services;
using BankSim.Domain.ValueObjects;
using BankSim.Infrastructure.Persistence;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;


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
        /// Initializes a new instance of the <see cref="AccountsController"/> class.
        /// </summary>
        /// <param name="accountStore">The account store.</param>
        /// <param name="statementService">The statement service.</param>
        public AccountsController(IAccountStore accountStore, IStatementService statementService)
        {
            _accountStore = accountStore;
            _statementService = statementService;
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
        public ActionResult<ApiResult<string>> AddAccount(AccountRequestDto dto, AccountTypesEnum accountType)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var className = accountType.ToString();

            var type = Assembly.Load("BankSim.Domain")
                               .GetTypes()
                               .FirstOrDefault(t => t.Name == className);


            if (type == null)
                return NotFound(ApiResult<string>.Fail("Account type not found", HttpContext.TraceIdentifier));

            var accountInstance = Activator.CreateInstance(type, dto.Owner,
                new Money(dto.Balance.Amount, (Currency)dto.Balance.Currency));

            _accountStore.Add(new SavingsAccount(dto.Owner, new Money(dto.Balance.Amount, (Currency)dto.Balance.Currency)));
            return Ok(ApiResult<string>.Ok("Adding account is success!", HttpContext.TraceIdentifier));
  
        }

    }
}
