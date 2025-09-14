public interface IStatementService
{
    IEnumerable<Transaction> FilterType(IEnumerable<Transaction> transactions, TransactionType type);
    IEnumerable<Transaction> FilterTime(IEnumerable<Transaction> transactions, DateTimeOffset startTime, DateTimeOffset endTime);
    IEnumerable<Transaction> FilterAmount(IEnumerable<Transaction> transactions, Money lowAmount, Money highAmount);

}