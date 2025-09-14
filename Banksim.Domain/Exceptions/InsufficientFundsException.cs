namespace BankSim.Domain.Exceptions;

/// <summary>
/// Thrown when an operation is attempted that requires more funds than are available in the account.
/// </summary>
public class InsufficientFundsException : DomainException
{
    /// <summary>
    /// The constructor for the InsufficientFundsException class.
    /// </summary>
    public InsufficientFundsException() : base("Your Balance is'nt enough!")
    {
    }
}