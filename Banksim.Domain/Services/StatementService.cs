using BankSim.Domain.Transaction;
using BankSim.Domain.ValueObjects;

namespace BankSim.Domain.Services;

/// <summary>
/// This service provides methods to filter and retrieve bank statement transactions based on various criteria.
/// </summary>
public class StatementService : IStatementService
{
    /// <inheritdoc />
    public IEnumerable<Transaction.Transaction> FilterType(IEnumerable<Transaction.Transaction> transactions,
        TransactionType type)
    {
        return transactions.Where(item => item.Type == type);
    }

    /// <inheritdoc />
    public IEnumerable<Transaction.Transaction> FilterTime(IEnumerable<Transaction.Transaction> transactions,
        DateTimeOffset startTime, DateTimeOffset endTime)
    {
        return transactions.Where(item => item.OccurredAt >= startTime && item.OccurredAt <= endTime);
    }

    /// <inheritdoc />
    public IEnumerable<Transaction.Transaction> FilterAmount(IEnumerable<Transaction.Transaction> transactions,
        Money lowAmount, Money highAmount)
    {
        return transactions.Where(item =>
            item.Amount.IsGreaterOrEqual(lowAmount) &&
            highAmount.IsGreaterOrEqual(item.Amount));
    }
}