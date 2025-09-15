using BankSim.Api.Models;
using BankSim.Domain.Abstractions;
using BankSim.Domain.Services;
using BankSim.Domain.ValueObjects;
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
        /// Initializes a new instance of the <see cref="TransferController"/> class.
        /// </summary>
        /// <param name="transferService">The transfer service.</param>
        public TransferController(ITransferService transferService)
        {
            _transferService = transferService;
        }
        /// <summary>
        /// Transfers the specified dto.
        /// </summary>
        /// <param name="dto">The dto.</param>
        [HttpPost]
        public IActionResult Transfer(TransferDto dto)
        {
            if (ModelState.IsValid)
                _transferService.Transfer(dto.From , dto.To, dto.Amount, dto.Description);

            return Ok();
        }
    }
}
