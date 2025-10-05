using BankSim.Domain.ValueObjects;

namespace Banksim.Grain.Abstractions
{
    /// <summary>
    /// This is the interface for AccountGrain.
    /// It defines methods for interacting with account data such as balance, deposits, and withdrawals.
    /// </summary>
    [Alias("Banksim.Grain.Abstractions.IAccountGrain")]
    public interface IAccountGrain: IGrainWithGuidKey
    {
        /// <summary>
        /// Gets the current balance of the account.
        /// </summary>
        /// <returns>The current balance.</returns>
        [Alias("GetBalance")]
        Task<decimal> GetBalance();

        /// <summary>
        /// Deposits the specified amount into the account.
        /// </summary>
        /// <param name="amount">The amount to deposit.</param>
        /// <param name="currency">The currency of the deposit.</param>
        /// <param name="description">An optional description of the deposit.</param>
        /// <returns>The updated balance after the deposit.</returns>
        [Alias("Deposit")]
        Task Deposit(decimal amount, Currency currency, string description = "");

        /// <summary>
        /// Withdraws the specified amount from the account.
        /// </summary>
        /// <param name="amount">The amount to withdraw.</param>
        /// <param name="currency">The currency of the withdrawal.</param>
        /// <param name="description">An optional description of the withdrawal.</param>
        /// <returns>The updated balance after the withdrawal.</returns>
        [Alias("Withdraw")]
        Task Withdraw(decimal amount, Currency currency, string description = "");

        /// <summary>
        /// Gets the owner of the account.
        /// </summary>
        /// <returns>The name of the account owner.</returns>
        [Alias("GetOwner")]
        Task<string> GetOwner();
    }
}
