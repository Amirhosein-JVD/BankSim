using BankSim.Domain.Transaction;
using BankSim.Domain.ValueObjects;

namespace BankSim.Domain.Services;

/// <summary>
/// This service provides methods to filter and retrieve bank statement transactions based on various criteria.
/// </summary>
public interface IStatementService
{
    /// <summary>
    /// This method filters transactions by their type.
    /// </summary>
    /// <param name="transactions">The collection of transactions to filter.</param>
    /// <param name="type">The type of transactions to filter by.</param>
    /// <returns>The filtered collection of transactions.</returns>
    IEnumerable<Transaction.Transaction> FilterType(IEnumerable<Transaction.Transaction> transactions,
        TransactionType type);

    /// <summary>
    /// This method filters transactions that occurred within a specified time range.
    /// </summary>
    /// <param name="transactions">The collection of transactions to filter.</param>
    /// <param name="startTime">The start time of the range.</param>
    /// <param name="endTime">The end time of the range.</param>
    /// <returns>The filtered collection of transactions.</returns>
    IEnumerable<Transaction.Transaction> FilterTime(IEnumerable<Transaction.Transaction> transactions,
        DateTimeOffset startTime, DateTimeOffset endTime);

    /// <summary>
    /// This method filters transactions based on their amount, returning those within the specified range.
    /// </summary>
    /// <param name="transactions">The collection of transactions to filter.</param>
    /// <param name="lowAmount">The lower bound of the amount range.</param>
    /// <param name="highAmount">The upper bound of the amount range.</param>
    /// <returns>The filtered collection of transactions.</returns>
    IEnumerable<Transaction.Transaction> FilterAmount(IEnumerable<Transaction.Transaction> transactions,
        Money lowAmount, Money highAmount);
}