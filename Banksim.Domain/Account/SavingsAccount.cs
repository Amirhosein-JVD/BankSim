public class SavingsAccount : AccountBase
{
    public SavingsAccount(string owner, Money initialBalance) : base(owner, initialBalance) { }
    public override void ProtectedWithdrawal(Money amount, TransactionType type, string description= "")
    {
        if (Balance.Amount - amount.Amount <= 0)
        {
            throw new InsufficientFundsException();
        }
        Balance = Balance.Subtract(amount);
        _transactions.Add(new Transaction(amount, description, type));
    }
}
