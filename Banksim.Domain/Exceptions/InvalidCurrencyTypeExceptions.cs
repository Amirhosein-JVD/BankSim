namespace BankSim.Domain.Exceptions;

/// <summary>
/// Thrown when an invalid currency type is provided.
/// </summary>
public class InvalidCurrencyTypeException : DomainException
{
    /// <summary>
    /// The constructor for the InvalidCurrencyTypeException class.
    /// </summary>
    public InvalidCurrencyTypeException() : base("You must choose  'IRR' or 'USD'.")
    {
    }
}