public interface IAccount
{
    Guid Id { get; }
    string Owner { get; init; }
    Money Balance { get; set; }
    void Deposit (Money amount, TransactionType type, string description = "");
    void Withdraw (Money amount, TransactionType type, string description = "");
    IReadOnlyList<Transaction> GetTransactions();
}