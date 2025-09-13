public class BusinessRuleViolationException : DomainException
{
    public BusinessRuleViolationException() : base("You must have 100 balance so you can't do this operation.") { }
}