using BankSim.Domain.Abstractions;
using BankSim.Domain.Exceptions;
using BankSim.Domain.ValueObjects;

namespace BankSim.Domain.Account;

/// <summary>
/// The SavingsAccount class represents a savings account in the banking system.
/// </summary>
public class SavingsAccount : AccountBase
{
    /// <summary>
    /// The constructor for the SavingsAccount class.
    /// </summary>
    /// <param name="owner">The owner of the account.</param>
    /// <param name="initialBalance">The initial balance of the account.</param>
    public SavingsAccount(string owner, Money initialBalance) : base(owner, initialBalance)
    {
    }

    /// <inheritdoc />
    protected override void ProtectedWithdrawal(Money amount, string description = "")
    {
        if (Balance.Amount - amount.Amount <= 5)
            throw new InsufficientFundsException();

        Balance = Balance.Subtract(amount);
    }
}