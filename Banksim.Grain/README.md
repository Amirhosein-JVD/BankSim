<?xml version="1.0"?>
<doc>
    <assembly>
        <name>Banksim.Grain</name>
    </assembly>
    <members>
        <member name="T:Banksim.Grain.Abstractions.IAccountGrain">
            <summary>
            This is interface for AccountGrain
            </summary>
        </member>
        <member name="M:Banksim.Grain.Abstractions.IAccountGrain.GetBalance">
            <summary>
            Gets the balance.
            </summary>
            <returns></returns>
        </member>
        <member name="M:Banksim.Grain.Abstractions.IAccountGrain.Deposit(System.Decimal,BankSim.Domain.ValueObjects.Currency,System.String)">
            <summary>
            Deposits the specified amount.
            </summary>
            <param name="amount">The amount.</param>
            <param name="currency">The currency.</param>
            <param name="description">The description.</param>
            <returns></returns>
        </member>
        <member name="M:Banksim.Grain.Abstractions.IAccountGrain.Withdraw(System.Decimal,BankSim.Domain.ValueObjects.Currency,System.String)">
            <summary>
            Withdraws the specified amount.
            </summary>
            <param name="amount">The amount.</param>
            <param name="currency">The currency.</param>
            <param name="description">The description.</param>
            <returns></returns>
        </member>
        <member name="M:Banksim.Grain.Abstractions.IAccountGrain.GetOwner">
            <summary>
            Gets the owner.
            </summary>
            <returns></returns>
        </member>
        <member name="T:Banksim.Grain.Accounts.AccountGrain">
            <summary>
            This is AccountGrain class
            </summary>
        </member>
        <member name="F:Banksim.Grain.Accounts.AccountGrain._state">
            <summary>
            The state
            </summary>
        </member>
        <member name="M:Banksim.Grain.Accounts.AccountGrain.#ctor">
            <summary>
            Initializes a new instance of the <see cref="T:Banksim.Grain.Accounts.AccountGrain"/> class.
            </summary>
        </member>
        <member name="M:Banksim.Grain.Accounts.AccountGrain.OnActivateAsync(System.Threading.CancellationToken)">
            <summary>
            Called when [activate asynchronous].
            </summary>
        </member>
        <member name="M:Banksim.Grain.Accounts.AccountGrain.Deposit(System.Decimal,BankSim.Domain.ValueObjects.Currency,System.String)">
            <summary>
            Deposits the specified amount.
            </summary>
            <param name="amount">The amount.</param>
            <param name="currency">The currency.</param>
            <param name="description">The description.</param>
        </member>
        <member name="M:Banksim.Grain.Accounts.AccountGrain.GetBalance">
            <summary>
            Gets the balance.
            </summary>
            <returns></returns>
            <exception cref="T:System.NotImplementedException"></exception>
        </member>
        <member name="M:Banksim.Grain.Accounts.AccountGrain.GetOwner">
            <summary>
            Gets the owner.
            </summary>
            <returns></returns>
            <exception cref="T:System.NotImplementedException"></exception>
        </member>
        <member name="M:Banksim.Grain.Accounts.AccountGrain.Withdraw(System.Decimal,BankSim.Domain.ValueObjects.Currency,System.String)">
            <summary>
            Withdraws the specified amount.
            </summary>
            <param name="amount">The amount.</param>
            <param name="currency">The currency.</param>
            <param name="description">The description.</param>
            <exception cref="T:BankSim.Domain.Exceptions.InsufficientFundsException"></exception>
        </member>
        <member name="T:Banksim.Grain.States.AccountState">
            <summary>
            This is the AccountState
            </summary>
        </member>
        <member name="P:Banksim.Grain.States.AccountState.Owner">
            <summary>
            Gets or sets the owner.
            </summary>
            <value>
            The owner.
            </value>
        </member>
        <member name="P:Banksim.Grain.States.AccountState.Balance">
            <summary>
            Gets or sets the balance.
            </summary>
            <value>
            The balance.
            </value>
        </member>
        <member name="P:Banksim.Grain.States.AccountState.Transactions">
            <summary>
            Gets or sets the transactions.
            </summary>
            <value>
            The transactions.
            </value>
        </member>
        <member name="P:Banksim.Grain.States.AccountState.AccountType">
            <summary>
            Gets or sets the type of the account.
            </summary>
            <value>
            The type of the account.
            </value>
        </member>
    </members>
</doc>
