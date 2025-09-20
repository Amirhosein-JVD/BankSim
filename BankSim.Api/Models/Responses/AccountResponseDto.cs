using BankSim.Domain.Abstractions;
using BankSim.Domain.Account;
using BankSim.Domain.Exceptions;
using BankSim.Domain.ValueObjects;
using System.ComponentModel.DataAnnotations;

namespace BankSim.Api.Models.Requestes
{
    /// <summary>
    /// The Account DTO
    /// </summary>
    public class AccountResponseDto
    {

        /// <summary>
        /// Gets or sets the owner.
        /// </summary>
        /// <value>
        /// The owner.
        /// </value>res

        [Required]
        public required string Owner { get; set; }

        /// <summary>
        /// Gets or sets the balance.
        /// </summary>
        /// <value>
        /// The balance.
        /// </value>
        public Money Balance { get; set; }

    }
}
