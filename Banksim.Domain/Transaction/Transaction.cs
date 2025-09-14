using BankSim.Domain.Transaction.TransactionEnums;
using BankSim.Domain.ValueObjects;

namespace BankSim.Domain.Transaction;

/// <summary>
/// The Transaction record represents a financial transaction in a bank account.
/// </summary>
/// <param name="TransactionId">The unique identifier for the transaction.</param>
/// <param name="OccurredAt">The timestamp when the transaction occurred.</param>
/// <param name="Type">The type of transaction (e.g., Deposit, Withdrawal, TransferIn, TransferOut).</param>
/// <param name="Amount">The amount of money involved in the transaction.</param>
/// <param name="Description">The description or memo associated with the transaction.</param>
public sealed record Transaction(
    Guid TransactionId,
    DateTimeOffset OccurredAt,
    TransactionType Type,
    Money Amount,
    string Description = "")
{
    /// <summary>
    /// The constructor to create a new transaction with the specified amount, description, and type.
    /// </summary>
    /// <param name="amount">The amount of money involved in the transaction.</param>
    /// <param name="description">The description or memo associated with the transaction.</param>
    /// <param name="type">The type of transaction (e.g., Deposit, Withdrawal, TransferIn, TransferOut).</param>
    public Transaction(Money amount, string description, TransactionType type)
        : this(Guid.NewGuid(), DateTimeOffset.UtcNow, type, amount, description ?? string.Empty)
    {
    }

    /// <inheritdoc />
    public override string ToString()
        => $"{OccurredAt:u} | {Type} | {Amount} | {Description} (Id: {TransactionId})";
}