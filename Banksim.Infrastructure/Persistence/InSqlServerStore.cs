using BankSim.Domain.Abstractions;
using BankSim.Infrastructure.Persistence;
using Dapper;
using Microsoft.Data.SqlClient;
using System.ComponentModel.DataAnnotations;
using BankSim.Domain.ValueObjects;
using BankSim.Domain.Account;
using BankSim.Domain.Exceptions;
using BankSim.Infrastructure.Persistence.Mapper;
using BankSim.Infrastructure.Persistence.Models;

/// <summary>
/// sql server
/// </summary>
public class InSqlServerStore : IAccountStore, ITransferDatabaseService
{
    private readonly string _connectionString;

    /// <summary>
    /// sql server constructor
    /// </summary>
    /// <param name="connectionString"></param>
    public InSqlServerStore(string connectionString) => _connectionString = connectionString;

    /// <summary>
    /// add account to Users table
    /// </summary>
    /// <param name="account"></param>
    /// <exception cref="NotImplementedException"></exception>
    public void Add(AccountBase account)
    {
        using var connection = new SqlConnection(_connectionString);

        AccountModel accountDatabase = MapperAccount.ToDatabaseModel(account);

        connection.Execute(@"INSERT INTO Accounts (Owner, BalanceAmount, BalanceCurrency, AccountType)
            VALUES (@Owner, @BalanceAmount, @BalanceCurrency, @AccountType)", accountDatabase);
    }

    /// <summary>
    /// get account in Users table by id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public AccountBase Get(Guid id)
    {
        using var connection = new SqlConnection(_connectionString);
        var account =  connection.QueryFirst<AccountModel>(@"SELECT * FROM Accounts WHERE Id= @Id", new {Id = id});
        return MapperAccount.ToDomain(account);
    
    }

    /// <summary>
    /// Get all accounts existing in Users table
    /// </summary>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public IReadOnlyList<AccountBase> GetAll()
    {
        using var connection = new SqlConnection(_connectionString);

        var accounts = connection.Query<AccountModel>(@"SELECT * FROM Accounts");

        List<AccountBase> result = new List<AccountBase> ();

        foreach (var account in accounts) 
        {
            result.Add(MapperAccount.ToDomain(account));
        }
        return result;
    }

    /// <summary>
    /// This is transfer for database
    /// </summary>
    public void Transfer(Guid from, Guid to, Money amount, string description="")
    {
        using var connection = new SqlConnection(_connectionString);

        Money money = new Money(amount.Amount, (Currency)amount.Currency);

        var fromAccount = Get(from);
        var toAccount = Get(to);
        connection.Execute(@"UPDATE Accounts SET BalanceAmount= @BalanceAmount WHERE Id = @Id", 
            new
            {
                BalanceAmount = fromAccount.Balance.Amount - money.Amount,
                Id= from
            });
        connection.Execute(@"UPDATE Accounts SET BalanceAmount= @BalanceAmount WHERE Id = @Id",
           new
           {
               BalanceAmount = toAccount.Balance.Amount + money.Amount,
               Id= to
           });
    }
}