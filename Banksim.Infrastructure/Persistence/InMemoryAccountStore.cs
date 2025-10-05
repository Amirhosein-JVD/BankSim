using BankSim.Domain.Abstractions;
using BankSim.Domain.ValueObjects;
using BankSim.Infrastructure.Persistence.Services;

namespace BankSim.Infrastructure.Persistence;

/// <summary>
/// The InMemoryAccountStore class provides an in-memory implementation of the IAccountStore interface.
/// </summary>
public class InMemoryAccountStore : IAccountStore, ITransferDatabaseService
{
    private readonly Dictionary<Guid, AccountBase> _accounts = new();

    /// <summary>
    /// The Add method adds a new account to the store.
    /// </summary>
    /// <param name="account">The account to be added.</param>
    /// <exception cref="InvalidOperationException">Thrown when an account with the same ID already exists.</exception>
    public void Add(AccountBase account)
    {
        if (!_accounts.TryAdd(account.Id, account))
            throw new InvalidOperationException("Account already exists.");
    }

    /// <inheritdoc />
    public AccountBase Get(Guid id)
    {
        if (!_accounts.TryGetValue(id, out var acc))
            throw new KeyNotFoundException($"Account {id} not found.");
        return acc;
    }

    /// <inheritdoc />
    public IReadOnlyList<AccountBase> GetAll() => _accounts.Values.ToList();


    /// <inheritdoc />
    public void Transfer(Guid from, Guid to, Money amount)
    {
        throw new Exception("You must use domain transfer service!");
    }
}