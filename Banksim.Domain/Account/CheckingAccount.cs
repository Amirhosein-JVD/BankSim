using BankSim.Domain.Abstractions;
using BankSim.Domain.ValueObjects;

namespace BankSim.Domain.Account;

/// <summary>
/// The CheckingAccount class represents a checking account in the banking system.
/// It inherits from AccountBase and implements specific withdrawal rules.
/// </summary>
public class CheckingAccount : AccountBase
{
    /// <summary>
    /// The constructor for the CheckingAccount class.
    /// </summary>
    /// <param name="owner">The owner of the account.</param>
    /// <param name="initialBalance">The initial balance of the account.</param>
    public CheckingAccount(string owner, Money initialBalance) : base(owner, initialBalance)
    {
    }

    /// <inheritdoc />
    protected override void ProtectedWithdrawal(Money amount, string description = "")
    {
        if (Balance.Amount - amount.Amount < 100)
            throw new BusinessRuleViolationException();

        Balance = Balance.Subtract(amount);
    }
}