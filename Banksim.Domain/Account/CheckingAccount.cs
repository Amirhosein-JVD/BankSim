public class CheckingAccount : AccountBase
{
    public override void ProtectedWithdrawal(Money amount, TransactionType type, string description = "")
    {
        if (Balance.Amount - amount.Amount < 100)
        {
            throw new BusinessRuleViolationException();
        }
        Balance = Balance.Subtract(amount);
        _transactions.Add(new Transaction { Amount = amount, Description = description, Type = type });
    }
}