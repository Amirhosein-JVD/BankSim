public readonly record struct Money
{
    public decimal Amount { get; init; }
    public MoneyType Currency { get; init; }

    public Money(decimal amount, MoneyType currency)
    {
        if (amount < 0)
            throw new InvalidMoneyException();

        Currency = currency;
        Amount = amount;
    }

    public Money Add(Money other)
    {
        ValidateSameCurrency(other);
        return new Money(Amount + other.Amount, Currency);
    }

    public Money Subtract(Money other)
    {
        ValidateSameCurrency(other);
        if (Amount < other.Amount)
            throw new InvalidMoneyException();
        return new Money(Amount - other.Amount, Currency);
    }

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

    public override string ToString() => $"[Money] Amount: {Amount}, Currency: {Currency}";
}
