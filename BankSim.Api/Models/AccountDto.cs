using BankSim.Domain.Abstractions;
using BankSim.Domain.Account;
using BankSim.Domain.Exceptions;
using BankSim.Domain.ValueObjects;

namespace BankSim.Api.Models
{
    /// <summary>
    /// The Account DTO
    /// </summary>
    public class AccountDto
    {

        /// <summary>
        /// Gets or sets the owner.
        /// </summary>
        /// <value>
        /// The owner.
        /// </value>
        public required string Owner { get; set; }

        /// <summary>
        /// Gets or sets the balance.
        /// </summary>
        /// <value>
        /// The balance.
        /// </value>
        public Money Balance { get; set; }

        /// <summary>
        /// Converts to entity.
        /// </summary>
        /// <param name="owner">The owner.</param>
        /// <param name="amount">The amount.</param>
        /// <param name="AccountType">Type of the account.</param>
        /// <returns></returns>
        public static AccountBase ToEntity(string owner, Money amount, string AccountType)
        {
           if (AccountType == "Checking")
           {
                return new CheckingAccount(owner, amount);

           } else if (AccountType == "Saving")
           {
                return new SavingsAccount(owner, amount);
            }
            else
            {
                throw new DomainException("Acconut not founded!");
            }
        }

        /// <summary>
        /// Converts to dto.
        /// </summary>
        /// <param name="owner">The owner.</param>
        /// <param name="amount">The amount.</param>
        /// <returns></returns>
        public static AccountDto ToDto(string owner, Money amount) {
            return new AccountDto { Owner= owner, Balance=amount };
        }
    }
}
