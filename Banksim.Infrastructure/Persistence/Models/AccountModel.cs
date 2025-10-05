namespace BankSim.Infrastructure.Persistence.Models;


/// <summary>
/// Schema that stored in database in Accounts table
/// </summary>
public class AccountModel
{

    /// <summary>
    /// Id
    /// </summary>
    public Guid Id { get; init; }

    /// <summary>
    /// Owner
    /// </summary>
    public required string Owner {  get; init; }

    /// <summary>
    /// Balance Amount
    /// </summary>
    public decimal BalanceAmount { get; init; }

    /// <summary>
    /// Balance Currency
    /// </summary>
    public int BalanceCurrency { get; init; }

    /// <summary>
    /// Account Type
    /// </summary>
    public required string AccountType { get; init; }
}