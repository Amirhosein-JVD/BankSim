public class InvalidCurrencyTypeException : DomainException
{
    public InvalidCurrencyTypeException() : base("You must choose  'IRR' or 'USD'.") { }
}