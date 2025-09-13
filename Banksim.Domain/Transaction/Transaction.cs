public class Transaction
{
    public Guid TransactionId { get; } = Guid.NewGuid();
    public DateTimeOffset OccurredAt { get; } = DateTimeOffset.Now;
    public TransactionType Type { get; set; }
    public Money Amount { get; init; }
    public string Description { get; init; }

    public override string ToString()
    {
        return $"[Transaction]:\nTransaction ID : {TransactionId}\nTransaction Time: {OccurredAt}\nTransaction Type: {Type}\nAmount: {Amount.ToString()}\nDescription: {Description}";
    }
}