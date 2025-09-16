using BankSim.Api.Models;
using BankSim.Domain.Services;
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
        [ProducesResponseType(200)]
        [ProducesResponseType(400)] 
        [ProducesResponseType(404)] 
        [ProducesResponseType(500)] 
        public IActionResult Transfer(TransferDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var accountFrom = _accountStore.Get(dto.From);
                var accountTo = _accountStore.Get(dto.To);

                if (accountFrom == null || accountTo == null)
                    return NotFound("Account not found");

                _transferService.Transfer(accountFrom, accountTo, dto.Amount, dto.Description);

                return Ok();
            }
            catch
            {
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
