
public abstract class AccountBase : IAccount
{
    protected List<Transaction> _transactions = new List<Transaction>();

    public Guid Id { get;  } = Guid.NewGuid();


    public Money Balance { get; set; }

    public string Owner { get; init; }

    public void Deposit(Money amount, TransactionType type, string description = "")
    {
        Balance = Balance.Add(amount);
        _transactions.Add(new Transaction { Amount= amount, Description= description, Type= type});
    }
   
    public void Withdraw(Money amount, TransactionType type, string description = "")
    {
        Balance = Balance.Subtract(amount);
        _transactions.Add(new Transaction { Amount = amount, Description = description, Type = type });
    }
   

    public IReadOnlyList<Transaction> GetTransactions()
    {
        return this._transactions.AsReadOnly();
    }

    public override string ToString()
    {
        return $"[Account]:\nAccount Id: {Id}\nAccount owner: {Owner}\nAccount Balance: {Balance}, ";
    }

    public abstract void ProtectedWithdrawal(Money amount, TransactionType type, string description= "");

}