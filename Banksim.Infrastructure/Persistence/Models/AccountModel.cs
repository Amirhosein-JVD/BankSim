namespace BankSim.Infrastructure.Persistence.Models;


/// <summary>
/// Schema that stored in database in Accounts table
/// </summary>
public class AccountModel
{

    /// <summary>
    /// Id
    /// </summary>
    public Guid Id { get; }

    /// <summary>
    /// Owner
    /// </summary>
    public required string Owner {  get; set; }

    /// <summary>
    /// Balance Amount
    /// </summary>
    public decimal BalanceAmount { get; set; }

    /// <summary>
    /// Balance Currency
    /// </summary>
    public int BalanceCurrency { get; set; }

    /// <summary>
    /// Account Type
    /// </summary>
    public required string AccountType { get; set; }
}