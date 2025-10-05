using BankSim.Domain.Abstractions;
using BankSim.Domain.ValueObjects;
using BankSim.Infrastructure.Persistence.Mapper;
using BankSim.Infrastructure.Persistence.Models;
using BankSim.Infrastructure.Persistence.Services;
using Dapper;
using Microsoft.Data.SqlClient;

namespace BankSim.Infrastructure.Persistence;

/// <summary>
/// sql server
/// </summary>
public class InSqlServerStore : IAccountStore, ITransferDatabaseService
{
    private readonly string _connectionString;

    /// <summary>
    /// sql server constructor
    /// </summary>
    /// <param name="connectionString">The connection string to the SQL Server database.</param>
    public InSqlServerStore(string connectionString) => _connectionString = connectionString;

    /// <summary>
    /// add account to Users table
    /// </summary>
    /// <param name="account">The account to add.</param>
    /// <exception cref="NotImplementedException">Throws if the method is not implemented.</exception>
    public void Add(AccountBase account)
    {
        using var connection = new SqlConnection(_connectionString);

        var accountDatabase = MapperAccount.ToDatabaseModel(account);

        connection.Execute(@"INSERT INTO Accounts (Owner, BalanceAmount, BalanceCurrency, AccountType)
            VALUES (@Owner, @BalanceAmount, @BalanceCurrency, @AccountType)", accountDatabase);
    }

    /// <summary>
    /// get account in Users table by id
    /// </summary>
    /// <param name="id">The unique identifier of the account to retrieve.</param>
    /// <returns>The account with the specified id.</returns>
    /// <exception cref="NotImplementedException">Throws if the method is not implemented.</exception
    public AccountBase Get(Guid id)
    {
        using var connection = new SqlConnection(_connectionString);
        var account = connection.QueryFirst<AccountModel>(@"SELECT * FROM Accounts WHERE Id= @Id", new { Id = id });
        return MapperAccount.ToDomain(account);
    }

    /// <summary>
    /// Get all accounts existing in Users table
    /// </summary>
    /// <returns>List of accounts</returns>
    /// <exception cref="NotImplementedException">Throws if the method is not implemented.</exception
    public IReadOnlyList<AccountBase> GetAll()
    {
        using var connection = new SqlConnection(_connectionString);

        var accounts = connection.Query<AccountModel>(@"SELECT * FROM Accounts");

        return accounts.Select(MapperAccount.ToDomain).ToList();
    }

    /// <inheritdoc />
    public void Transfer(Guid from, Guid to, Money amount)
    {
        using var connection = new SqlConnection(_connectionString);
        using var transaction = connection.BeginTransaction();

        try
        {
            var fromAccount = Get(from);
            var toAccount = Get(to);

            connection.Execute(@"UPDATE Accounts SET BalanceAmount = @BalanceAmount WHERE Id = @Id", 
                new { BalanceAmount = fromAccount.Balance.Amount - amount.Amount, Id = from }, transaction);

            connection.Execute(@"UPDATE Accounts SET BalanceAmount = @BalanceAmount WHERE Id = @Id", 
                new { BalanceAmount = toAccount.Balance.Amount + amount.Amount, Id = to }, transaction);

            transaction.Commit();
        }
        catch
        {
            transaction.Rollback();
            throw;
        }
    }
}