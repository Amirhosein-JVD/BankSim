using BankSim.Api.Models;
using BankSim.Domain.Abstractions;
using BankSim.Domain.Services;
using BankSim.Domain.ValueObjects;
using BankSim.Infrastructure.Persistence;
using Microsoft.AspNetCore.Mvc;

namespace BankSim.Api.Controllers
{
    /// <summary>
    /// Transfer controllers
    /// </summary>
   
    [ApiController]
    [Route("api/[controller]")]
    public class TransferController: ControllerBase
    {
        /// <summary>
        /// The transfer service
        /// </summary>
        private readonly ITransferService _transferService;

        /// <summary>
        /// The account store
        /// </summary>
        private readonly IAccountStore _accountStore;

        /// <summary>
        /// Initializes a new instance of the <see cref="TransferController"/> class.
        /// </summary>
        /// <param name="transferService">The transfer service.</param>
        /// <param name="accountStore"></param>
        public TransferController(ITransferService transferService, IAccountStore accountStore)
        {
            _transferService = transferService;
            _accountStore = accountStore;   
        }

        /// <summary>
        /// Transfers the specified dto.
        /// </summary>
        /// <param name="dto">The dto.</param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Transfer(TransferDto dto)
        {
            var _accountFrom = _accountStore.Get(dto.From);
            var _accountTo = _accountStore.Get(dto.To);
            _transferService.Transfer(_accountFrom, _accountTo, dto.Amount, dto.Description);
            return Ok();
        }
    }
}
