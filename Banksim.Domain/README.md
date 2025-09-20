<?xml version="1.0"?>
<doc>
    <assembly>
        <name>BankSim.Domain</name>
    </assembly>
    <members>
        <member name="T:BankSim.Domain.Abstractions.AccountBase">
            <summary>
            The base class for different types of bank accounts, providing common functionality such as deposit,
            </summary>
        </member>
        <member name="F:BankSim.Domain.Abstractions.AccountBase.Transactions">
            <summary>
            The list of transactions associated with the account.
            </summary>
        </member>
        <member name="P:BankSim.Domain.Abstractions.AccountBase.Owner">
            <summary>
            The owner of the account.
            </summary>
        </member>
        <member name="P:BankSim.Domain.Abstractions.AccountBase.Id">
            <inheritdoc />
        </member>
        <member name="P:BankSim.Domain.Abstractions.AccountBase.Balance">
            <summary>
            The current balance of the account.
            </summary>
        </member>
        <member name="M:BankSim.Domain.Abstractions.AccountBase.#ctor(System.String,BankSim.Domain.ValueObjects.Money)">
            <summary>
            The constructor for the AccountBase class.
            </summary>
            <param name="owner">The owner of the account.</param>
            <param name="initialBalance">The initial balance of the account.</param>
        </member>
        <member name="M:BankSim.Domain.Abstractions.AccountBase.Deposit(BankSim.Domain.ValueObjects.Money,System.String)">
            <inheritdoc />
        </member>
        <member name="M:BankSim.Domain.Abstractions.AccountBase.Withdraw(BankSim.Domain.ValueObjects.Money,System.String)">
            <inheritdoc />
        </member>
        <member name="M:BankSim.Domain.Abstractions.AccountBase.GetTransactions">
            <inheritdoc />
        </member>
        <member name="M:BankSim.Domain.Abstractions.AccountBase.ToString">
            <inheritdoc />
        </member>
        <member name="M:BankSim.Domain.Abstractions.AccountBase.ProtectedWithdrawal(BankSim.Domain.ValueObjects.Money,System.String)">
            <summary>
            The protected method to handle the withdrawal logic, to be implemented by derived classes.
            </summary>
            <param name="amount">The amount of money to withdraw.</param>
            <param name="description">The description or memo associated with the transaction.</param>
        </member>
        <member name="T:BankSim.Domain.Abstractions.IAccount">
            <summary>
            The interface for different types of bank accounts, providing common functionality such as deposit,
            withdrawal, and transaction history.
            </summary>
        </member>
        <member name="P:BankSim.Domain.Abstractions.IAccount.Id">
            <summary>
            The unique identifier for the account.
            </summary>
        </member>
        <member name="P:BankSim.Domain.Abstractions.IAccount.Balance">
            <summary>
            The current balance of the account.
            </summary>
        </member>
        <member name="M:BankSim.Domain.Abstractions.IAccount.Deposit(BankSim.Domain.ValueObjects.Money,System.String)">
            <summary>
            The method to deposit money into the account.
            </summary>
            <param name="amount">The amount of money to deposit. see <see cref="T:BankSim.Domain.ValueObjects.Money"/>.</param>
            <param name="description">An optional description for the transaction.</param>
        </member>
        <member name="M:BankSim.Domain.Abstractions.IAccount.Withdraw(BankSim.Domain.ValueObjects.Money,System.String)">
            <summary>
            The method to withdraw money from the account.
            </summary>
            <param name="amount">The amount of money to withdraw.</param>
            <param name="description">An optional description for the transaction.</param>
        </member>
        <member name="M:BankSim.Domain.Abstractions.IAccount.GetTransactions">
            <summary>
            Gets the list of transactions associated with the account.
            </summary>
            <returns></returns>
        </member>
        <member name="T:BankSim.Domain.Account.CheckingAccount">
            <summary>
            The CheckingAccount class represents a checking account in the banking system.
            It inherits from AccountBase and implements specific withdrawal rules.
            </summary>
        </member>
        <member name="M:BankSim.Domain.Account.CheckingAccount.#ctor(System.String,BankSim.Domain.ValueObjects.Money)">
            <summary>
            The constructor for the CheckingAccount class.
            </summary>
            <param name="owner">The owner of the account.</param>
            <param name="initialBalance">The initial balance of the account.</param>
        </member>
        <member name="M:BankSim.Domain.Account.CheckingAccount.ProtectedWithdrawal(BankSim.Domain.ValueObjects.Money,System.String)">
            <inheritdoc />
        </member>
        <member name="T:BankSim.Domain.Account.SavingsAccount">
            <summary>
            The SavingsAccount class represents a savings account in the banking system.
            </summary>
        </member>
        <member name="M:BankSim.Domain.Account.SavingsAccount.#ctor(System.String,BankSim.Domain.ValueObjects.Money)">
            <summary>
            The constructor for the SavingsAccount class.
            </summary>
            <param name="owner">The owner of the account.</param>
            <param name="initialBalance">The initial balance of the account.</param>
        </member>
        <member name="M:BankSim.Domain.Account.SavingsAccount.ProtectedWithdrawal(BankSim.Domain.ValueObjects.Money,System.String)">
            <inheritdoc />
        </member>
        <member name="T:BankSim.Domain.Exceptions.BusinessRuleViolationException">
            <summary>
            Thrown when a business rule is violated in the domain layer.
            </summary>
        </member>
        <member name="M:BankSim.Domain.Exceptions.BusinessRuleViolationException.#ctor">
            <summary>
            The constructor for the BusinessRuleViolationException class.
            </summary>
        </member>
        <member name="T:BankSim.Domain.Exceptions.DomainException">
            <summary>
            The base exception class for domain-related errors.
            </summary>
        </member>
        <member name="M:BankSim.Domain.Exceptions.DomainException.#ctor(System.String)">
            <summary>
            The constructor for the DomainException class.
            </summary>
            <param name="message">The error message.</param>
        </member>
        <member name="M:BankSim.Domain.Exceptions.DomainException.#ctor(System.String,System.Exception)">
            <summary>
            The constructor for the DomainException class with an inner exception.
            </summary>
            <param name="message">The error message.</param>
            <param name="inner">The inner exception.</param>
        </member>
        <member name="T:BankSim.Domain.Exceptions.InsufficientFundsException">
            <summary>
            Thrown when an operation is attempted that requires more funds than are available in the account.
            </summary>
        </member>
        <member name="M:BankSim.Domain.Exceptions.InsufficientFundsException.#ctor">
            <summary>
            The constructor for the InsufficientFundsException class.
            </summary>
        </member>
        <member name="T:BankSim.Domain.Exceptions.InvalidCurrencyOperationException">
            <summary>
            Thrown when an operation is attempted between different currency types.
            </summary>
        </member>
        <member name="M:BankSim.Domain.Exceptions.InvalidCurrencyOperationException.#ctor">
            <summary>
            The constructor for the InvalidCurrencyOperationException class.
            </summary>
        </member>
        <member name="T:BankSim.Domain.Exceptions.InvalidCurrencyTypeException">
            <summary>
            Thrown when an invalid currency type is provided.
            </summary>
        </member>
        <member name="M:BankSim.Domain.Exceptions.InvalidCurrencyTypeException.#ctor">
            <summary>
            The constructor for the InvalidCurrencyTypeException class.
            </summary>
        </member>
        <member name="T:BankSim.Domain.Exceptions.InvalidMoneyException">
            <summary>
            Thrown when a money value is invalid, such as being negative.
            </summary>
        </member>
        <member name="M:BankSim.Domain.Exceptions.InvalidMoneyException.#ctor">
            <summary>
            The constructor for the InvalidMoneyException class.
            </summary>
        </member>
        <member name="T:BankSim.Domain.Services.IStatementService">
            <summary>
            This service provides methods to filter and retrieve bank statement transactions based on various criteria.
            </summary>
        </member>
        <member name="M:BankSim.Domain.Services.IStatementService.FilterType(System.Collections.Generic.IEnumerable{BankSim.Domain.Transaction.Transaction},BankSim.Domain.Transaction.TransactionType)">
            <summary>
            This method filters transactions by their type.
            </summary>
            <param name="transactions">The collection of transactions to filter.</param>
            <param name="type">The type of transactions to filter by.</param>
            <returns>The filtered collection of transactions.</returns>
        </member>
        <member name="M:BankSim.Domain.Services.IStatementService.FilterTime(System.Collections.Generic.IEnumerable{BankSim.Domain.Transaction.Transaction},System.DateTimeOffset,System.DateTimeOffset)">
            <summary>
            This method filters transactions that occurred within a specified time range.
            </summary>
            <param name="transactions">The collection of transactions to filter.</param>
            <param name="startTime">The start time of the range.</param>
            <param name="endTime">The end time of the range.</param>
            <returns>The filtered collection of transactions.</returns>
        </member>
        <member name="M:BankSim.Domain.Services.IStatementService.FilterAmount(System.Collections.Generic.IEnumerable{BankSim.Domain.Transaction.Transaction},BankSim.Domain.ValueObjects.Money,BankSim.Domain.ValueObjects.Money)">
            <summary>
            This method filters transactions based on their amount, returning those within the specified range.
            </summary>
            <param name="transactions">The collection of transactions to filter.</param>
            <param name="lowAmount">The lower bound of the amount range.</param>
            <param name="highAmount">The upper bound of the amount range.</param>
            <returns>The filtered collection of transactions.</returns>
        </member>
        <member name="T:BankSim.Domain.Services.ITransferService">
            <summary>
            Transfer service interface for handling money transfers between accounts.
            </summary>
        </member>
        <member name="M:BankSim.Domain.Services.ITransferService.Transfer(BankSim.Domain.Abstractions.IAccount,BankSim.Domain.Abstractions.IAccount,BankSim.Domain.ValueObjects.Money,System.String)">
            <summary>
            The method to transfer money from one account to another.
            </summary>
            <param name="from">The account to transfer money from.</param>
            <param name="to">The account to transfer money to.</param>
            <param name="amount">The amount of money to transfer.</param>
            <param name="description">An optional description for the transfer.</param>
        </member>
        <member name="T:BankSim.Domain.Services.StatementService">
            <summary>
            This service provides methods to filter and retrieve bank statement transactions based on various criteria.
            </summary>
        </member>
        <member name="M:BankSim.Domain.Services.StatementService.FilterType(System.Collections.Generic.IEnumerable{BankSim.Domain.Transaction.Transaction},BankSim.Domain.Transaction.TransactionType)">
            <inheritdoc />
        </member>
        <member name="M:BankSim.Domain.Services.StatementService.FilterTime(System.Collections.Generic.IEnumerable{BankSim.Domain.Transaction.Transaction},System.DateTimeOffset,System.DateTimeOffset)">
            <inheritdoc />
        </member>
        <member name="M:BankSim.Domain.Services.StatementService.FilterAmount(System.Collections.Generic.IEnumerable{BankSim.Domain.Transaction.Transaction},BankSim.Domain.ValueObjects.Money,BankSim.Domain.ValueObjects.Money)">
            <inheritdoc />
        </member>
        <member name="T:BankSim.Domain.Services.TransferService">
            <summary>
            Transfer service for handling money transfers between accounts.
            </summary>
        </member>
        <member name="M:BankSim.Domain.Services.TransferService.Transfer(BankSim.Domain.Abstractions.IAccount,BankSim.Domain.Abstractions.IAccount,BankSim.Domain.ValueObjects.Money,System.String)">
            <inheritdoc />
        </member>
        <member name="T:BankSim.Domain.Transaction.Transaction">
            <summary>
            The Transaction record represents a financial transaction in a bank account.
            </summary>
            <param name="TransactionId">The unique identifier for the transaction.</param>
            <param name="OccurredAt">The timestamp when the transaction occurred.</param>
            <param name="Type">The type of transaction (e.g., Deposit, Withdrawal, TransferIn, TransferOut).</param>
            <param name="Amount">The amount of money involved in the transaction.</param>
            <param name="Description">The description or memo associated with the transaction.</param>
        </member>
        <member name="M:BankSim.Domain.Transaction.Transaction.#ctor(System.Guid,System.DateTimeOffset,BankSim.Domain.Transaction.TransactionType,BankSim.Domain.ValueObjects.Money,System.String)">
            <summary>
            The Transaction record represents a financial transaction in a bank account.
            </summary>
            <param name="TransactionId">The unique identifier for the transaction.</param>
            <param name="OccurredAt">The timestamp when the transaction occurred.</param>
            <param name="Type">The type of transaction (e.g., Deposit, Withdrawal, TransferIn, TransferOut).</param>
            <param name="Amount">The amount of money involved in the transaction.</param>
            <param name="Description">The description or memo associated with the transaction.</param>
        </member>
        <member name="P:BankSim.Domain.Transaction.Transaction.TransactionId">
            <summary>The unique identifier for the transaction.</summary>
        </member>
        <member name="P:BankSim.Domain.Transaction.Transaction.OccurredAt">
            <summary>The timestamp when the transaction occurred.</summary>
        </member>
        <member name="P:BankSim.Domain.Transaction.Transaction.Type">
            <summary>The type of transaction (e.g., Deposit, Withdrawal, TransferIn, TransferOut).</summary>
        </member>
        <member name="P:BankSim.Domain.Transaction.Transaction.Amount">
            <summary>The amount of money involved in the transaction.</summary>
        </member>
        <member name="P:BankSim.Domain.Transaction.Transaction.Description">
            <summary>The description or memo associated with the transaction.</summary>
        </member>
        <member name="M:BankSim.Domain.Transaction.Transaction.#ctor(BankSim.Domain.ValueObjects.Money,System.String,BankSim.Domain.Transaction.TransactionType)">
            <summary>
            The constructor to create a new transaction with the specified amount, description, and type.
            </summary>
            <param name="amount">The amount of money involved in the transaction.</param>
            <param name="description">The description or memo associated with the transaction.</param>
            <param name="type">The type of transaction (e.g., Deposit, Withdrawal, TransferIn, TransferOut).</param>
        </member>
        <member name="M:BankSim.Domain.Transaction.Transaction.ToString">
            <inheritdoc />
        </member>
        <member name="T:BankSim.Domain.Transaction.TransactionType">
            <summary>
            The types of transactions that can occur in a bank account.
            </summary>
        </member>
        <member name="F:BankSim.Domain.Transaction.TransactionType.Deposit">
            <summary>
            The transaction is a deposit of funds into the account.
            </summary>
        </member>
        <member name="F:BankSim.Domain.Transaction.TransactionType.Withdrawal">
            <summary>
            The transaction is a withdrawal of funds from the account.
            </summary>
        </member>
        <member name="F:BankSim.Domain.Transaction.TransactionType.TransferIn">
            <summary>
            The transaction is a transfer of funds into the account from another account.
            </summary>
        </member>
        <member name="F:BankSim.Domain.Transaction.TransactionType.TransferOut">
            <summary>
            The transaction is a transfer of funds out of the account to another account.
            </summary>
        </member>
        <member name="T:BankSim.Domain.ValueObjects.Currency">
            <summary>
            The enumeration of supported currency types.
            </summary>
        </member>
        <member name="F:BankSim.Domain.ValueObjects.Currency.IRR">
            <summary>
            The Iranian Rial currency.
            </summary>
        </member>
        <member name="F:BankSim.Domain.ValueObjects.Currency.USD">
            <summary>
            The US Dollar currency.
            </summary>
        </member>
        <member name="T:BankSim.Domain.ValueObjects.Money">
            <summary>
            The Money value object represents a monetary amount in a specific currency.
            It provides methods for addition, subtraction, and comparison while ensuring currency consistency.
            </summary>
        </member>
        <member name="P:BankSim.Domain.ValueObjects.Money.Amount">
            <summary>
            The monetary amount, which must be non-negative.
            </summary>
        </member>
        <member name="P:BankSim.Domain.ValueObjects.Money.Currency">
            <summary>
            The currency type of the monetary amount. see <see cref="T:BankSim.Domain.ValueObjects.Currency"/>.
            </summary>
        </member>
        <member name="M:BankSim.Domain.ValueObjects.Money.#ctor(System.Decimal,BankSim.Domain.ValueObjects.Currency)">
            <summary>
            The constructor for the Money value object.
            </summary>
            <param name="amount">The monetary amount, which must be non-negative.</param>
            <param name="currency">The currency type of the monetary amount.</param>
            <exception cref="T:BankSim.Domain.Exceptions.InvalidMoneyException">Thrown when the amount is negative.</exception>
        </member>
        <member name="M:BankSim.Domain.ValueObjects.Money.Add(BankSim.Domain.ValueObjects.Money)">
            <summary>
            The addition operation for two Money instances.
            Ensures both instances have the same currency before performing the addition.
            </summary>
            <param name="other">The other Money instance to add.</param>
            <returns>A new Money instance representing the sum.</returns>
        </member>
        <member name="M:BankSim.Domain.ValueObjects.Money.Subtract(BankSim.Domain.ValueObjects.Money)">
            <summary>
            The subtraction operation for two Money instances.
            </summary>
            <param name="other">The other Money instance to subtract.</param>
            <returns>A new Money instance representing the difference.</returns>
            <exception cref="T:BankSim.Domain.Exceptions.InsufficientFundsException">Thrown when the result would be negative.</exception>
        </member>
        <member name="M:BankSim.Domain.ValueObjects.Money.IsGreaterOrEqual(BankSim.Domain.ValueObjects.Money)">
            <summary>
            The greater-than comparison for two Money instances.
            </summary>
            <param name="other">The other Money instance to compare.</param>
            <returns>True if this instance is greater than the other; otherwise, false.</returns>
        </member>
        <member name="M:BankSim.Domain.ValueObjects.Money.ToString">
            <inheritdoc />
        </member>
        <member name="T:AccountTypesEnum">
            <summary>
            Account Types Enum
            </summary>
        </member>
        <member name="F:AccountTypesEnum.CheckingAccount">
            <summary>
            The checking account
            </summary>
        </member>
        <member name="F:AccountTypesEnum.SavingAccount">
            <summary>
            The saving account
            </summary>
        </member>
    </members>
</doc>
