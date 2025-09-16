using BankSim.Api.Models;
using BankSim.Domain.Account;
using BankSim.Domain.Services;
using BankSim.Domain.ValueObjects;
using BankSim.Infrastructure.Persistence;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography.Xml;

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
        public ActionResult<IEnumerable<AccountDto>> GetAllAccounts()
        {
            var _accounts = _accountStore.GetAll();
            return Ok(_accounts);
        }

        /// <summary>
        /// Gets the account by identifier.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        [HttpGet("{Id}")]
        public ActionResult<AccountDto> GetAccountById(Guid Id) 
        {
            var _account = _accountStore.Get(Id);
            return Ok(_account);
        }

        /// <summary>
        /// Adds the account.
        /// </summary>
        /// <param name="dto">The dto.</param>
        /// <param name="AccountType"></param>
        /// <exception cref="System.NotImplementedException"></exception>
        [HttpPost]
        public ActionResult AddAccount(AccountDto dto, string AccountType) 
        {
            _accountStore.Add(AccountDto.ToEntity(dto.Owner, dto.Balance, AccountType));
            return Ok();
        }
    }
}
