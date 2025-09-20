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
    public class AccountRequestDto
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

        /// <summary>
        /// Converts to dto.
        /// </summary>
        /// <param name="owner">The owner.</param>
        /// <param name="amount">The amount.</param>
        /// <returns></returns>
        public static AccountRequestDto ToDto(string owner, Money amount) {
            return new AccountRequestDto { Owner= owner, Balance=amount };
        }
    }
}
