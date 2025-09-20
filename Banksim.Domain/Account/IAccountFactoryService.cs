using BankSim.Domain.Abstractions;

namespace BankSim.Domain.Account;

/// <summary>
/// Account factory service
/// </summary>
public interface IAccountFactoryService
{
    /// <summary>
    /// Accounts the factory.
    /// </summary>
    /// <param name="owner">The owner.</param>
    /// <param name="balance">The balance.</param>
    /// <param name="currency">The currency.</param>
    /// <param name="accountType">Type of the account.</param>
    /// <returns></returns>
    public AccountBase AccountFactory(string owner, decimal balance, int currency, int accountType);
}
