public class InvalidMoneyException : DomainException
{
    public InvalidMoneyException() : base("Money can't be a negative number!") { }
}