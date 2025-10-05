using BankSim.Domain.Exceptions;
using BankSim.Domain.Transaction;
using BankSim.Domain.ValueObjects;
using Banksim.Grain.Abstractions;
using Banksim.Grain.States;

namespace Banksim.Grain.Accounts
{
    /// <summary>
    /// This is AccountGrain class
    /// </summary>
    public class AccountGrain : Orleans.Grain, IAccountGrain
    {
        /// <summary>
        /// The state
        /// </summary>
        private readonly AccountState _state;

        /// <summary>
        /// Initializes a new instance of the <see cref="AccountGrain"/> class.
        /// </summary>
        public AccountGrain()
        {
            _state = new AccountState();
        }


        /// <summary>
        /// Called when [activate asynchronous].
        /// </summary>
        public override async Task OnActivateAsync(CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(_state.Owner))
            {
                _state.Owner = $"Customer-{this.GetPrimaryKey()}";
                _state.UpdateBalance(new Money { Amount = 0, Currency = Currency.USD });
            }

            await base.OnActivateAsync(cancellationToken);
        }

        /// <summary>
        /// Deposits the specified amount.
        /// </summary>
        /// <param name="amount">The amount.</param>
        /// <param name="currency">The currency.</param>
        /// <param name="description">The description.</param>
        public async Task Deposit(decimal amount, Currency currency, string description = "")
        {
            var depositMoney = new Money(amount, currency);
            _state.UpdateBalance(_state.Balance.Add(depositMoney));
            _state.AddTransaction(new Transaction(depositMoney, description, TransactionType.Deposit));
            await Task.CompletedTask;
        }

        /// <summary>
        /// Gets the balance.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public Task<decimal> GetBalance() => Task.FromResult(_state.Balance.Amount);

        /// <summary>
        /// Gets the owner.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public Task<string> GetOwner() => Task.FromResult(_state.Owner);

        /// <summary>
        /// Withdraws the specified amount.
        /// </summary>
        /// <param name="amount">The amount.</param>
        /// <param name="currency">The currency.</param>
        /// <param name="description">The description.</param>
        /// <exception cref="BankSim.Domain.Exceptions.InsufficientFundsException"></exception>
        public async Task Withdraw(decimal amount, Currency currency, string description = "")
        {
            if (_state.Balance.Amount < amount)
            {
                throw new InsufficientFundsException();
            }

            var withdrawalMoney = new Money(amount, currency);
            _state.UpdateBalance(_state.Balance.Subtract(withdrawalMoney));
            _state.AddTransaction(new Transaction(withdrawalMoney, description, TransactionType.Withdrawal));
            await Task.CompletedTask;
        }
    }
}