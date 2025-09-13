public class StatementService : IStatementService
{
    public void FilterType<T>(IReadOnlyList<Transaction> transactions, TransactionType type)
    {
        foreach (var item in transactions.Where(item => item.Type == type))
        {
            Console.WriteLine(item.ToString());
        }
    }

    public void FilterTime(IReadOnlyList<Transaction> transaction, DateTimeOffset startTime, DateTimeOffset endTime)
    {
        foreach (var item in transaction.Where(item => item.OccurredAt >= startTime && item.OccurredAt <= endTime))
        {
            Console.WriteLine(item.ToString());
        }
    }
    public void FilterAmount(IReadOnlyList<Transaction> transaction, Money amount)
    {
        foreach (var item in transaction.Where(item => item.Amount.IsGreaterOrEqual(amount)))
        {
            Console.WriteLine(item.ToString());
        }
    }
}