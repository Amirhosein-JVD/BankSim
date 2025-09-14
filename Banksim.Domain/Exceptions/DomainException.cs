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

    /// <summary>
    /// The constructor for the DomainException class with an inner exception.
    /// </summary>
    /// <param name="message">The error message.</param>
    /// <param name="inner">The inner exception.</param>
    public DomainException(string message, Exception inner) : base(message, inner)
    {
    }
}