public class NegativeMoneyException : DomainException
{
    public NegativeMoneyException() : base("Negative money! Check the values again.") { }
}