namespace BankSim.Domain.Exceptions;

/// <summary>
/// Thrown when a money value is invalid, such as being negative.
/// </summary>
public class InvalidMoneyException : DomainException
{
    /// <summary>
    /// The constructor for the InvalidMoneyException class.
    /// </summary>
    public InvalidMoneyException()
        : base("Money amount cannot be negative.")
    {
    }
}