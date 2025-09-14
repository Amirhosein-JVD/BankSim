public class Transaction
{
    public Guid TransactionId { get; }
    public DateTimeOffset OccurredAt { get; }
    public TransactionType Type { get; }
    public Money Amount { get; }
    public string Description { get; }

    public Transaction(TransactionType type, Money amount, string description)
    {
        TransactionId = Guid.NewGuid();
        OccurredAt = DateTimeOffset.Now;
        Type = type;
        Amount = amount;
        Description = description;
    }

    public Transaction(Money amount, string description, TransactionType type)
    {
        Amount = amount;
        Description = description;
        Type = type;
    }

    public override string ToString()
    {
        return $"[Transaction]:\n" +
               $"Transaction ID : {TransactionId}\n" +
               $"Transaction Time: {OccurredAt}\n" +
               $"Transaction Type: {Type}\n" +
               $"Amount: {Amount}\n" +
               $"Description: {Description}";
    }
}
