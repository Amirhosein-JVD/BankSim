using BankSim.Domain.Abstractions;
using BankSim.Domain.Account;
using BankSim.Domain.ValueObjects;
using BankSim.Domain.Exceptions;
using BankSim.Infrastructure.Persistence.Models;

namespace BankSim.Infrastructure.Persistence.Mapper;

/// <summary>
/// Mapper Account
/// </summary>
public class MapperAccount : IMapperAccount
{
   /// <summary>
   /// ToDatabaseModel
   /// </summary>
   /// <param name="account"></param>
   /// <returns></returns>
    public static AccountModel ToDatabaseModel(AccountBase account)
    {
        if (account.GetType().Name == "CheckingAccount")
        {
            return new AccountModel { Owner = account.Owner, BalanceAmount = account.Balance.Amount, BalanceCurrency = (int)account.Balance.Currency, AccountType = "CheckingAccount" };
        } else if (account.GetType().Name == "SavingsAccount")
        {
            return new AccountModel { Owner = account.Owner, BalanceAmount = account.Balance.Amount, BalanceCurrency = (int)account.Balance.Currency, AccountType = "SavingsAccount" };
        }
        else
        {
            throw new DomainException("Account type not found!");
        }
    }

   /// <summary>
   /// ToDomain
   /// </summary>
   /// <param name="account"></param>
   /// <returns></returns>
    public static AccountBase ToDomain(AccountModel account)
    {
        if (account.AccountType == "CheckingAccount")
        {
            return new CheckingAccount(account.Owner, new Money(account.BalanceAmount, (Currency)account.BalanceCurrency));

        } else if (account.AccountType == "SavingsAccount"){

            return new SavingsAccount(account.Owner, new Money(account.BalanceAmount, (Currency)account.BalanceCurrency));
        }
        else
        {
            throw new DomainException("Accounts type not found!");
        }
    }
}