using BankSim.Domain.Abstractions;
using BankSim.Domain.ValueObjects;

namespace BankSim.Domain.Services;

/// <summary>
/// Transfer service interface for handling money transfers between accounts.
/// </summary>
public interface ITransferService
{
    /// <summary>
    /// The method to transfer money from one account to another.
    /// </summary>
    /// <param name="from">The account to transfer money from.</param>
    /// <param name="to">The account to transfer money to.</param>
    /// <param name="amount">The amount of money to transfer.</param>
    /// <param name="description">An optional description for the transfer.</param>
    void Transfer(IAccount from, IAccount to, Money amount, string description = "");
}