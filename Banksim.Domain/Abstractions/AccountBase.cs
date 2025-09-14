using BankSim.Domain.Transaction;
using BankSim.Domain.ValueObjects;

namespace BankSim.Domain.Abstractions;

/// <summary>
/// The base class for different types of bank accounts, providing common functionality such as deposit,
/// </summary>
public abstract class AccountBase : IAccount
{
    /// <summary>
    /// The list of transactions associated with the account.
    /// </summary>
    protected readonly List<Transaction.Transaction> Transactions = [];

    /// <summary>
    /// The owner of the account.
    /// </summary>
    public string Owner { get; }

    /// <inheritdoc />
    public Guid Id { get; }

    /// <summary>
    /// The current balance of the account.
    /// </summary>
    public Money Balance { get; protected set; }

    /// <summary>
    /// The constructor for the AccountBase class.
    /// </summary>
    /// <param name="owner">The owner of the account.</param>
    /// <param name="initialBalance">The initial balance of the account.</param>
    protected AccountBase(string owner, Money initialBalance)
    {
        Id = Guid.NewGuid();
        Owner = owner;
        Balance = initialBalance;
    }

    /// <inheritdoc />
    public void Deposit(Money amount, string description = "")
    {
        Balance = Balance.Add(amount);
        Transactions.Add(new Transaction.Transaction(amount, description, TransactionType.Deposit));
    }

    /// <inheritdoc />
    public void Withdraw(Money amount, string description = "")
    {
        ProtectedWithdrawal(amount, description);
        Transactions.Add(new Transaction.Transaction(amount, description, TransactionType.Withdrawal));
    }

    /// <inheritdoc />
    public IReadOnlyList<Transaction.Transaction> GetTransactions() => Transactions.AsReadOnly();

    /// <inheritdoc />
    public override string ToString()
        => $"Account Id: {Id}\nOwner: {Owner}\nBalance: {Balance}";

    /// <summary>
    /// The protected method to handle the withdrawal logic, to be implemented by derived classes.
    /// </summary>
    /// <param name="amount">The amount of money to withdraw.</param>
    /// <param name="description">The description or memo associated with the transaction.</param>
    protected abstract void ProtectedWithdrawal(Money amount, string description = "");
}