public class CheckingAccount : AccountBase
{
    public CheckingAccount(string owner, Money initialBalance) : base(owner, initialBalance) { }

    public override void ProtectedWithdrawal(Money amount, TransactionType type, string description = "")
    {
        if (Balance.Amount - amount.Amount < 100)
        {
            throw new BusinessRuleViolationException();
        }
        Balance = Balance.Subtract(amount);
        _transactions.Add(new Transaction(amount, description, type));
    }
}