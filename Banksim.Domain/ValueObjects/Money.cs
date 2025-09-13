public class Money
{
    private decimal _amount;
    private string? _currency;
    public decimal Amount
    {
        get { return _amount; }
        set {
            if (value >= 0)
            {
                _amount = value;
            }
            else
            {
                throw new InvalidMoneyException();
            }
        }
    }

    public string Currency
    {
        get => _currency;

        set
        {
            _currency = value switch
            {
                "IRR" => value,
                "USD" => value,
                _ => throw new InvalidCurrencyTypeException(),
            };
        }
    }

    public Money Add(Money asset)
    {
        if (this.Currency != asset.Currency)
        {
            throw new InvalidCurrencyOperationException();
        }
        return new Money { Amount = Amount + asset.Amount, Currency = Currency };
    }

    public Money Subtract(Money asset)
    {
        if (this.Currency != asset.Currency)
        {
            throw new InvalidCurrencyOperationException();
        }

        if(!this.IsGreaterOrEqual(asset))
        {
            throw new NegativeMoneyException();
        }

        return new Money { Amount = Amount - asset.Amount, Currency =  Currency };
    }

    public bool IsGreaterOrEqual(Money asset)
    {
        if (this.Currency != asset.Currency)
        {
            throw new InvalidCurrencyOperationException();
        }
        return this.Amount >= asset.Amount;
    }

    public override string ToString()
    {
        return $"[Money] Amount: {Amount},  Currency: {Currency}";
    }
}