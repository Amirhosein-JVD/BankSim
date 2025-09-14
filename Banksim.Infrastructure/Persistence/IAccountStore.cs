public interface IAccountStore
{
    AccountBase Get(Guid id);
    void Add(AccountBase account);
    IReadOnlyList<AccountBase> GetAll();
}