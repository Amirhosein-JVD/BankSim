namespace BankSim.Domain.Exceptions;

/// <summary>
/// Thrown when an operation is attempted between different currency types.
/// </summary>
public class InvalidCurrencyOperationException : DomainException
{
    /// <summary>
    /// The constructor for the InvalidCurrencyOperationException class.
    /// </summary>
    public InvalidCurrencyOperationException() : base("You can't operate on different types!")
    {
    }
}