public interface IAccount
{
    Money Balance { get; }
    void Deposit (Money amount, TransactionType type, string description = "");
    void Withdraw (Money amount, TransactionType type, string description = "");
    IEnumerable<Transaction> GetTransactions();
}