public class InvalidCurrencyOperationException : DomainException
{
    public InvalidCurrencyOperationException() : base("You can't operate on different types!") { }
}