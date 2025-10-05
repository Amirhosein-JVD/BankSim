using BankSim.Domain.ValueObjects;

namespace BankSim.Infrastructure.Persistence.Services;

/// <summary>
/// transfer service for database
/// </summary>
public interface ITransferDatabaseService
{
    /// <summary>
    /// Transfer for database
    /// </summary>
    /// <param name="from">From account id</param>
    /// <param name="to">To account id</param>
    /// <param name="amount">Amount to transfer</param>
    public void Transfer(Guid from, Guid to, Money amount);
}