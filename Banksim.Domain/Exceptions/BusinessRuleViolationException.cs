namespace BankSim.Domain.Exceptions;

/// <summary>
/// Thrown when a business rule is violated in the domain layer.
/// </summary>
public class BusinessRuleViolationException : DomainException
{
    /// <summary>
    /// The constructor for the BusinessRuleViolationException class.
    /// </summary>
    public BusinessRuleViolationException()
        : base("Balance cannot fall below the required minimum (100).")
    {
    }
}