<?xml version="1.0"?>
<doc>
    <assembly>
        <name>BankSim.Infrastructure</name>
    </assembly>
    <members>
        <member name="T:BankSim.Infrastructure.Persistence.IAccountStore">
            <summary>
            The IAccountStore interface defines methods for managing and retrieving bank account information.
            </summary>
        </member>
        <member name="M:BankSim.Infrastructure.Persistence.IAccountStore.Get(System.Guid)">
            <summary>
            The Get method retrieves an account by its unique identifier.
            </summary>
            <param name="id">The unique identifier of the account.</param>
            <returns>The account associated with the specified identifier.</returns>
        </member>
        <member name="M:BankSim.Infrastructure.Persistence.IAccountStore.Add(BankSim.Domain.Abstractions.AccountBase)">
            <summary>
            The Add method adds a new account to the store.
            </summary>
            <param name="account">The account to be added.</param>
        </member>
        <member name="M:BankSim.Infrastructure.Persistence.IAccountStore.GetAll">
            <summary>
            The GetAll method retrieves all accounts from the store.
            </summary>
            <returns>A read-only list of all accounts.</returns>
        </member>
        <member name="T:BankSim.Infrastructure.Persistence.InMemoryAccountStore">
            <summary>
            The InMemoryAccountStore class provides an in-memory implementation of the IAccountStore interface.
            </summary>
        </member>
        <member name="M:BankSim.Infrastructure.Persistence.InMemoryAccountStore.Add(BankSim.Domain.Abstractions.AccountBase)">
            <summary>
            The Add method adds a new account to the store.
            </summary>
            <param name="account">The account to be added.</param>
            <exception cref="T:System.InvalidOperationException">Thrown when an account with the same ID already exists.</exception>
        </member>
        <member name="M:BankSim.Infrastructure.Persistence.InMemoryAccountStore.Get(System.Guid)">
            <inheritdoc />
        </member>
        <member name="M:BankSim.Infrastructure.Persistence.InMemoryAccountStore.GetAll">
            <inheritdoc />
        </member>
    </members>
</doc>
