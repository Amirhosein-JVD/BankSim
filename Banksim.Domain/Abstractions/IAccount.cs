using BankSim.Domain.ValueObjects;

namespace BankSim.Domain.Abstractions;

/// <summary>
/// The interface for different types of bank accounts, providing common functionality such as deposit,
/// withdrawal, and transaction history.
/// </summary>
public interface IAccount
{
    /// <summary>
    /// The unique identifier for the account.
    /// </summary>
    Guid Id { get; }
    
    /// <summary>
    /// The current balance of the account.
    /// </summary>
    Money Balance { get; }
    
    /// <summary>
    /// The method to deposit money into the account.
    /// </summary>
    /// <param name="amount">The amount of money to deposit. see <see cref="Money"/>.</param>
    /// <param name="description">An optional description for the transaction.</param>
    void Deposit (Money amount, string description = "");
    
    /// <summary>
    /// The method to withdraw money from the account.
    /// </summary>
    /// <param name="amount">The amount of money to withdraw.</param>
    /// <param name="description">An optional description for the transaction.</param>
    void Withdraw (Money amount, string description = "");
    
    /// <summary>
    /// Gets the list of transactions associated with the account.
    /// </summary>
    /// <returns></returns>
    IReadOnlyList<Transaction.Transaction> GetTransactions();
}