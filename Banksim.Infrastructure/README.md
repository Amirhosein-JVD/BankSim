<?xml version="1.0"?>
<doc>
    <assembly>
        <name>BankSim.Infrastructure</name>
    </assembly>
    <members>
        <member name="T:DatabaseInitializer">
            <summary>
            Database Initializer
            </summary>
        </member>
        <member name="M:DatabaseInitializer.EnsureTableIsCreated(System.Data.IDbConnection)">
            <summary>
            creating tables
            </summary>
            <param name="connection"></param>
        </member>
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
        <member name="M:BankSim.Infrastructure.Persistence.InMemoryAccountStore.Transfer(System.Guid,System.Guid,BankSim.Domain.ValueObjects.Money,System.String)">
            <summary>
            transfer in memory
            </summary>
            <param name="from"></param>
            <param name="to"></param>
            <param name="amount"></param>
            <param name="description"></param>
            <exception cref="T:System.Exception"></exception>
        </member>
        <member name="T:BankSim.Infrastructure.Persistence.Mapper.IMapperAccount">
            <summary>
            Mapper to Domain entity and database entity
            </summary>
        </member>
        <member name="M:BankSim.Infrastructure.Persistence.Mapper.IMapperAccount.ToDomain(BankSim.Infrastructure.Persistence.Models.AccountModel)">
            <summary>
            This function convert database object to the domain object
            </summary>
        </member>
        <member name="M:BankSim.Infrastructure.Persistence.Mapper.IMapperAccount.ToDatabaseModel(BankSim.Domain.Abstractions.AccountBase)">
            <summary>
            this function convert domain object to database object
            </summary>
            <returns></returns>
        </member>
        <member name="T:BankSim.Infrastructure.Persistence.Mapper.MapperAccount">
            <summary>
            Mapper Account
            </summary>
        </member>
        <member name="M:BankSim.Infrastructure.Persistence.Mapper.MapperAccount.ToDatabaseModel(BankSim.Domain.Abstractions.AccountBase)">
            <summary>
            ToDatabaseModel
            </summary>
            <param name="account"></param>
            <returns></returns>
        </member>
        <member name="M:BankSim.Infrastructure.Persistence.Mapper.MapperAccount.ToDomain(BankSim.Infrastructure.Persistence.Models.AccountModel)">
            <summary>
            ToDomain
            </summary>
            <param name="account"></param>
            <returns></returns>
        </member>
        <member name="T:BankSim.Infrastructure.Persistence.Models.AccountModel">
            <summary>
            Schema that stored in database in Accounts table
            </summary>
        </member>
        <member name="P:BankSim.Infrastructure.Persistence.Models.AccountModel.Id">
            <summary>
            Id
            </summary>
        </member>
        <member name="P:BankSim.Infrastructure.Persistence.Models.AccountModel.Owner">
            <summary>
            Owner
            </summary>
        </member>
        <member name="P:BankSim.Infrastructure.Persistence.Models.AccountModel.BalanceAmount">
            <summary>
            Balance Amount
            </summary>
        </member>
        <member name="P:BankSim.Infrastructure.Persistence.Models.AccountModel.BalanceCurrency">
            <summary>
            Balance Currency
            </summary>
        </member>
        <member name="P:BankSim.Infrastructure.Persistence.Models.AccountModel.AccountType">
            <summary>
            Account Type
            </summary>
        </member>
        <member name="T:InSqlServerStore">
            <summary>
            sql server
            </summary>
        </member>
        <member name="M:InSqlServerStore.#ctor(System.String)">
            <summary>
            sql server constructor
            </summary>
            <param name="connectionString"></param>
        </member>
        <member name="M:InSqlServerStore.Add(BankSim.Domain.Abstractions.AccountBase)">
            <summary>
            add account to Users table
            </summary>
            <param name="account"></param>
            <exception cref="T:System.NotImplementedException"></exception>
        </member>
        <member name="M:InSqlServerStore.Get(System.Guid)">
            <summary>
            get account in Users table by id
            </summary>
            <param name="id"></param>
            <returns></returns>
            <exception cref="T:System.NotImplementedException"></exception>
        </member>
        <member name="M:InSqlServerStore.GetAll">
            <summary>
            Get all accounts existing in Users table
            </summary>
            <returns></returns>
            <exception cref="T:System.NotImplementedException"></exception>
        </member>
        <member name="M:InSqlServerStore.Transfer(System.Guid,System.Guid,BankSim.Domain.ValueObjects.Money,System.String)">
            <summary>
            This is transfer for database
            </summary>
        </member>
        <member name="T:ITransferDatabaseService">
            <summary>
            transfer service for database
            </summary>
        </member>
        <member name="M:ITransferDatabaseService.Transfer(System.Guid,System.Guid,BankSim.Domain.ValueObjects.Money,System.String)">
            <summary>
            Transfer for database
            </summary>
            <param name="from"></param>
            <param name="to"></param>
            <param name="amount"></param>
            <param name="description"></param>
        </member>
    </members>
</doc>
