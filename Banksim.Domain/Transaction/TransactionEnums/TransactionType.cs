namespace BankSim.Domain.Transaction.TransactionEnums;

/// <summary>
/// The types of transactions that can occur in a bank account.
/// </summary>
public enum TransactionType
{
    /// <summary>
    /// The transaction is a deposit of funds into the account.
    /// </summary>
    Deposit,
    
    /// <summary>
    /// The transaction is a withdrawal of funds from the account.
    /// </summary>
    Withdrawal,
    
    /// <summary>
    /// The transaction is a transfer of funds into the account from another account.
    /// </summary>
    TransferIn,
    
    /// <summary>
    /// The transaction is a transfer of funds out of the account to another account.
    /// </summary>
    TransferOut
}