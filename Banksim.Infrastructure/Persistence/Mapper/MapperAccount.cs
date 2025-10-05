using BankSim.Domain.Abstractions;
using BankSim.Domain.Account;
using BankSim.Domain.ValueObjects;
using BankSim.Domain.Exceptions;
using BankSim.Infrastructure.Persistence.Models;

namespace BankSim.Infrastructure.Persistence.Mapper;

/// <summary>
/// Mapper Account
/// </summary>
public abstract class MapperAccount : IMapperAccount
{
   /// <summary>
   /// ToDatabaseModel
   /// </summary>
   /// <param name="account">The account</param>
   /// <returns>The account model</returns>
    public static AccountModel ToDatabaseModel(AccountBase account)
    {
        return account.GetType().Name switch
        {
            "CheckingAccount" => new AccountModel
            {
                Owner = account.Owner,
                BalanceAmount = account.Balance.Amount,
                BalanceCurrency = (int)account.Balance.Currency,
                AccountType = "CheckingAccount"
            },
            "SavingsAccount" => new AccountModel
            {
                Owner = account.Owner,
                BalanceAmount = account.Balance.Amount,
                BalanceCurrency = (int)account.Balance.Currency,
                AccountType = "SavingsAccount"
            },
            _ => throw new DomainException("Account type not found!")
        };
    }

   /// <summary>
   /// ToDomain
   /// </summary>
   /// <param name="account">The account model</param>
   /// <returns>The account</returns>
    public static AccountBase ToDomain(AccountModel account)
    {
        return account.AccountType switch
        {
            "CheckingAccount" => new CheckingAccount(account.Owner,
                new Money(account.BalanceAmount, (Currency)account.BalanceCurrency)),
            "SavingsAccount" => new SavingsAccount(account.Owner,
                new Money(account.BalanceAmount, (Currency)account.BalanceCurrency)),
            _ => throw new DomainException("Accounts type not found!")
        };
    }
}