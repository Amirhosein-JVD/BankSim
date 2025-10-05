using BankSim.Domain.Transaction;
using BankSim.Domain.ValueObjects;

namespace Banksim.Grain.States
{
    /// <summary>
    /// This is the AccountState
    /// </summary>
    public class AccountState
    {
        /// <summary>
        /// Gets or sets the owner.
        /// </summary>
        /// <value>
        /// The owner.
        /// </value>
        public string Owner { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the balance.
        /// </summary>
        /// <value>
        /// The balance.
        /// </value>
        public Money Balance { get; private set; } = new Money { Amount = 0, Currency = Currency.USD };

        /// <summary>
        /// Gets or sets the transactions.
        /// </summary>
        /// <value>
        /// The transactions.
        /// </value>
        public List<Transaction> Transactions { get ;private set; } = [];

        /// <summary>
        /// Gets or sets the type of the account.
        /// </summary>
        /// <value>
        /// The type of the account.
        /// </value>
        public string AccountType { get; set; } = "Checking";
        
        /// <summary>
        /// Updates the balance.
        /// </summary>
        /// <param name="newBalance">The new balance.</param>
        public void UpdateBalance(Money newBalance) => Balance = newBalance;
        
        /// <summary>
        /// Adds the transaction.
        /// </summary>
        /// <param name="transaction">The transaction.</param>
        public void AddTransaction(Transaction transaction) => Transactions.Add(transaction);
    }
}