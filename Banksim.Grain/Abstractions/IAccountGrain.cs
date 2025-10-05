using BankSim.Domain.ValueObjects;

namespace Banksim.Grain.Abstractions
{
    /// <summary>
    /// This is interface for AccountGrain
    /// </summary>
    public interface IAccountGrain: IGrainWithGuidKey
    {
        /// <summary>
        /// Gets the balance.
        /// </summary>
        /// <returns></returns>
        Task<decimal> GetBalance();

        /// <summary>
        /// Deposits the specified amount.
        /// </summary>
        /// <param name="amount">The amount.</param>
        /// <param name="currency">The currency.</param>
        /// <param name="description">The description.</param>
        /// <returns></returns>
        Task Deposit(decimal amount, Currency currency, string description = "");

        /// <summary>
        /// Withdraws the specified amount.
        /// </summary>
        /// <param name="amount">The amount.</param>
        /// <param name="currency">The currency.</param>
        /// <param name="description">The description.</param>
        /// <returns></returns>
        Task Withdraw(decimal amount, Currency currency, string description = "");

        /// <summary>
        /// Gets the owner.
        /// </summary>
        /// <returns></returns>
        Task<string> GetOwner();
    }
}
