
public class InMemoryAccountStore : IAccountStore
{
    private readonly Dictionary<Guid, AccountBase> _accounts = new();
    public void Add(AccountBase account)
    {
        if (_accounts.ContainsKey(account.Id))
        {
            throw new InvalidOperationException("Account alredy exist!");
        }
        _accounts[account.Id] = account;
       
    }

    public AccountBase Get(Guid id)
    {
        if (!_accounts.TryGetValue(id, out var acc))
        {
            throw new KeyNotFoundException($"Account {id} not found!");
        }
        return acc;
    }

    public IReadOnlyList<AccountBase> GetAll()
    {
       return _accounts.Values.ToList();
    }
}