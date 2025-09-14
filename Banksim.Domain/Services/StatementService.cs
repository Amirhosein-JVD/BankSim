public class StatementService : IStatementService
{
    public IEnumerable<Transaction> FilterType(IEnumerable<Transaction> transactions, TransactionType type)
    {
        return transactions.Where(item => item.Type == type);
    }

    public IEnumerable<Transaction> FilterTime(IEnumerable<Transaction> transactions, DateTimeOffset startTime, DateTimeOffset endTime)
    {
        return transactions.Where(item => item.OccurredAt >= startTime && item.OccurredAt <= endTime);
    }
    public IEnumerable<Transaction> FilterAmount(IEnumerable<Transaction> transactions, Money lowAmount, Money highAmount)
    {
        return transactions.Where(item => item.Amount.Amount >= lowAmount.Amount && item.Amount.Amount <= highAmount.Amount);
    }
}