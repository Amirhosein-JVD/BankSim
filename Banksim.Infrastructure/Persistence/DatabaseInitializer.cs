
using Dapper;
using System.Data;

/// <summary>
/// Database Initializer
/// </summary>
public static class DatabaseInitializer
{
    /// <summary>
    /// creating tables
    /// </summary>
    /// <param name="connection"></param>
    public static void EnsureTableIsCreated(IDbConnection connection)
    {
       
        var createAccounts = @"
            IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='Accounts' AND xtype='U')
            CREATE TABLE Accounts (
                Id UNIQUEIDENTIFIER NOT NULL PRIMARY KEY DEFAULT NEWID(),
                Owner NVARCHAR(100) NOT NULL,
                BalanceAmount DECIMAL(18,2) NOT NULL,
                BalanceCurrency INT NOT NULL,
                AccountType NVARCHAR(50) NOT NULL
        );";

        connection.Execute(createAccounts);
    }
}