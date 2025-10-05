using BankSim.Domain.Transaction;
using BankSim.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public Money Balance { get; set; } = new Money { Amount= 0 , Currency= Currency.USD};

        /// <summary>
        /// Gets or sets the transactions.
        /// </summary>
        /// <value>
        /// The transactions.
        /// </value>
        public List<Transaction> Transactions { get; set; } = new List<Transaction>();

        /// <summary>
        /// Gets or sets the type of the account.
        /// </summary>
        /// <value>
        /// The type of the account.
        /// </value>
        public string AccountType { get; set; } = "Checking";
    }
}
