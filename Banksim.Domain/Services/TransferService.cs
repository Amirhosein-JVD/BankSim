using BankSim.Domain.Abstractions;
using BankSim.Domain.Exceptions;
using BankSim.Domain.ValueObjects;

namespace BankSim.Domain.Services;

/// <summary>
/// Transfer service for handling money transfers between accounts.
/// </summary>
public class TransferService : ITransferService
{
    /// <inheritdoc />
    public void Transfer(IAccount from, IAccount to, Money amount, string description = "")
    {
        if (from is null || to is null) throw new ArgumentNullException(nameof(from));
        if (ReferenceEquals(from, to)) throw new DomainException("Cannot transfer to the same account.");
        if (amount.Amount <= 0) throw new InvalidMoneyException();

        from.Withdraw(amount, description);
        to.Deposit(amount, description);
    }
}