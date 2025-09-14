
public abstract class AccountBase : IAccount
{
    protected List<Transaction> _transactions = new List<Transaction>();

    public readonly Guid Id;
    public readonly string Owner;

    public Money Balance { get; private set; }

    public AccountBase(string owner)
    {
        Id = Guid.NewGuid();
        Owner = owner;
    }

    public void Deposit(Money amount, TransactionType type, string description = "")
    {
        Balance = Balance.Add(amount);
        _transactions.Add(new Transaction(amount, description, type));
    }
   
    public void Withdraw(Money amount, TransactionType type, string description = "")
    {
        Balance = Balance.Subtract(amount);
        _transactions.Add(new Transaction(amount, description, type));
    }
   

    public IEnumerable<Transaction> GetTransactions()
    {
        return this._transactions.AsReadOnly();
    }

    public override string ToString()
    {
        return $"[Account]:\nAccount Id: {Id}\nAccount owner: {Owner}\nAccount Balance: {Balance}, ";
    }

    public abstract void ProtectedWithdrawal(Money amount, TransactionType type, string description= "");

}