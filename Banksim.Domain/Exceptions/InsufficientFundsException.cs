public class InsufficientFundsException : DomainException
{
    public InsufficientFundsException() : base("Your Balance is'nt enough!") { }
}