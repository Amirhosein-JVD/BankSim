using BankSim.Domain.ValueObjects;

/// <summary>
/// transfer service for database
/// </summary>
public interface ITransferDatabaseService
{
    /// <summary>
    /// Transfer for database
    /// </summary>
    /// <param name="from"></param>
    /// <param name="to"></param>
    /// <param name="amount"></param>
    /// <param name="description"></param>
    public void Transfer(Guid from, Guid to, Money amount, string description = "");
}

