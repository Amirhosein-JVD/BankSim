public interface IStatementService
{
    void FilterType<T>(IReadOnlyList<Transaction> transactions, TransactionType type);
    void FilterTime(IReadOnlyList<Transaction> transaction, DateTimeOffset startTime, DateTimeOffset endTime);
    void FilterAmount(IReadOnlyList<Transaction> transaction, Money amount);


}