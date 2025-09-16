using BankSim.Api.Models;
using BankSim.Domain.Account;
using BankSim.Domain.Services;
using BankSim.Infrastructure.Persistence;
using Microsoft.AspNetCore.Mvc;


namespace BankSim.Api.Controllers
{
    /// <summary>
    /// Conrollers of accounts
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
        [ProducesResponseType(typeof(IEnumerable<AccountDto>), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public ActionResult<IEnumerable<AccountDto>> GetAllAccounts()
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var accounts = _accountStore.GetAll();
                return Ok(accounts);
            }
            catch
            {
                return StatusCode(500, "Internal server error");
            }
        }

        /// <summary>
        /// Gets the account by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(AccountDto), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public ActionResult<AccountDto> GetAccountById(Guid id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var account = _accountStore.Get(id);
                if (account == null)
                    return NotFound(); 

                return Ok(account);
            }
            catch
            {
                return StatusCode(500, "Internal server error");
            }
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
        public ActionResult AddAccount(AccountDto dto, AccountTypesEnum accountType)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                switch (accountType)
                {
                    case AccountTypesEnum.CheckingAccount:
                        _accountStore.Add(new CheckingAccount(dto.Owner, dto.Balance));
                        return Ok();
                    case AccountTypesEnum.SavingAccount:
                        _accountStore.Add(new SavingsAccount(dto.Owner, dto.Balance));
                        return Ok();
                    default:
                        return NotFound("Account type not found");
                }
            }
            catch
            {
                return StatusCode(500, "Internal server error");
            }
        }

    }
}
