using BankSim.Domain.Abstractions;

namespace BankSim.Infrastructure.Persistence;

/// <summary>
/// The IAccountStore interface defines methods for managing and retrieving bank account information.
/// </summary>
public interface IAccountStore
{
    /// <summary>
    /// The Get method retrieves an account by its unique identifier.
    /// </summary>
    /// <param name="id">The unique identifier of the account.</param>
    /// <returns>The account associated with the specified identifier.</returns>
    IAccount Get(Guid id);

    /// <summary>
    /// The Add method adds a new account to the store.
    /// </summary>
    /// <param name="account">The account to be added.</param>
    void Add(IAccount account);

    /// <summary>
    /// The GetAll method retrieves all accounts from the store.
    /// </summary>
    /// <returns>A read-only list of all accounts.</returns>
    IReadOnlyList<IAccount> GetAll();
}