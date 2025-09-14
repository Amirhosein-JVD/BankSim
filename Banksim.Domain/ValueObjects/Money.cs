using BankSim.Domain.Exceptions;

namespace BankSim.Domain.ValueObjects;

/// <summary>
/// The Money value object represents a monetary amount in a specific currency.
/// It provides methods for addition, subtraction, and comparison while ensuring currency consistency.
/// </summary>
public readonly record struct Money
{
    /// <summary>
    /// The monetary amount, which must be non-negative.
    /// </summary>
    public decimal Amount { get; init; }

    /// <summary>
    /// The currency type of the monetary amount. see <see cref="ValueObjects.Currency"/>.
    /// </summary>
    public Currency Currency { get; init; }

    /// <summary>
    /// The constructor for the Money value object.
    /// </summary>
    /// <param name="amount">The monetary amount, which must be non-negative.</param>
    /// <param name="currency">The currency type of the monetary amount.</param>
    /// <exception cref="InvalidMoneyException">Thrown when the amount is negative.</exception>
    public Money(decimal amount, Currency currency)
    {
        if (amount < 0)
            throw new InvalidMoneyException();

        Currency = currency;
        Amount = amount;
    }

    /// <summary>
    /// The addition operation for two Money instances.
    /// Ensures both instances have the same currency before performing the addition.
    /// </summary>
    /// <param name="other">The other Money instance to add.</param>
    /// <returns>A new Money instance representing the sum.</returns>
    public Money Add(Money other)
    {
        ValidateSameCurrency(other);
        return new Money(Amount + other.Amount, Currency);
    }

    /// <summary>
    /// The subtraction operation for two Money instances.
    /// </summary>
    /// <param name="other">The other Money instance to subtract.</param>
    /// <returns>A new Money instance representing the difference.</returns>
    /// <exception cref="InsufficientFundsException">Thrown when the result would be negative.</exception>
    public Money Subtract(Money other)
    {
        ValidateSameCurrency(other);
        if (Amount < other.Amount)
            throw new InsufficientFundsException();
        return new Money(Amount - other.Amount, Currency);
    }

    /// <summary>
    /// The greater-than comparison for two Money instances.
    /// </summary>
    /// <param name="other">The other Money instance to compare.</param>
    /// <returns>True if this instance is greater than the other; otherwise, false.</returns>
    public bool IsGreaterOrEqual(Money other)
    {
        ValidateSameCurrency(other);
        return Amount >= other.Amount;
    }

    private void ValidateSameCurrency(Money other)
    {
        if (Currency != other.Currency)
            throw new InvalidCurrencyOperationException();
    }

    /// <inheritdoc />
    public override string ToString() => $"{Amount:0.##} {Currency}";
}