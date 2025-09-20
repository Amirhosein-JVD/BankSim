using BankSim.Domain.Abstractions;
using BankSim.Domain.Exceptions;
using BankSim.Domain.ValueObjects;

namespace BankSim.Domain.Account;

/// <summary>
/// Adding account service
/// </summary>
public class AccountFactoryService: IAccountFactoryService
{
    /// <summary>
    /// Adds the account.
    /// </summary>
    /// <param name="owner">The owner.</param>
    /// <param name="balance">The balance.</param>
    /// <param name="currency">The currency.</param>
    /// <param name="accountType">Type of the account.</param>
    /// <returns></returns>
    public  AccountBase AccountFactory(string owner, decimal balance, int currency, int accountType)
    {
        switch ((AccountTypesEnum) accountType)
        {
            case AccountTypesEnum.CheckingAccount:
                return new CheckingAccount(owner, new Money(balance, (Currency) currency));

            case AccountTypesEnum.SavingsAccount:
                return new SavingsAccount(owner, new Money(balance, (Currency) currency));

            default:
                throw new DomainException("Account type not found!");
        }
    }
}

