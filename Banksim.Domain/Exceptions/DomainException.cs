namespace BankSim.Domain.Exceptions;

/// <summary>
/// The base exception class for domain-related errors.
/// </summary>
public class DomainException : Exception
{
    /// <summary>
    /// The constructor for the DomainException class.
    /// </summary>
    /// <param name="message">The error message.</param>
    public DomainException(string message) : base(message)
    {
    }
}