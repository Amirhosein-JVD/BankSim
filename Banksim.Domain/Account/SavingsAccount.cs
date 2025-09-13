public class SavingsAccount : AccountBase
{
    public override void ProtectedWithdrawal(Money amount, TransactionType type, string description= "")
    {
        if (Balance.Amount - amount.Amount <= 0)
        {
            throw new InsufficientFundsException();
        }
        Balance = Balance.Subtract(amount);
        _transactions.Add(new Transaction { Amount = amount, Description = description, Type = type });
    }
}
