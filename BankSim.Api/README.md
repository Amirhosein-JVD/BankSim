<?xml version="1.0"?>
<doc>
    <assembly>
        <name>BankSim.Api</name>
    </assembly>
    <members>
        <member name="T:BankSim.Api.Controllers.AccountsController">
            <summary>
            Conrollers of accounts
            </summary>
        </member>
        <member name="F:BankSim.Api.Controllers.AccountsController._accountStore">
            <summary>
            The account store
            </summary>
        </member>
        <member name="F:BankSim.Api.Controllers.AccountsController._statementService">
            <summary>
            The statement service
            </summary>
        </member>
        <member name="M:BankSim.Api.Controllers.AccountsController.#ctor(BankSim.Infrastructure.Persistence.IAccountStore,BankSim.Domain.Services.IStatementService)">
            <summary>
            Initializes a new instance of the <see cref="T:BankSim.Api.Controllers.AccountsController"/> class.
            </summary>
            <param name="accountStore">The account store.</param>
            <param name="statementService">The statement service.</param>
        </member>
        <member name="M:BankSim.Api.Controllers.AccountsController.GetAllAccounts">
            <summary>
            Gets all.
            </summary>
            <returns></returns>
        </member>
        <member name="M:BankSim.Api.Controllers.AccountsController.GetAccountById(System.Guid)">
            <summary>
            Gets the account by identifier.
            </summary>
            <param name="Id">The identifier.</param>
            <returns></returns>
            <exception cref="T:System.NotImplementedException"></exception>
        </member>
        <member name="M:BankSim.Api.Controllers.AccountsController.AddAccount(BankSim.Api.Models.AccountDto,System.String)">
            <summary>
            Adds the account.
            </summary>
            <param name="dto">The dto.</param>
            <param name="AccountType"></param>
            <exception cref="T:System.NotImplementedException"></exception>
        </member>
        <member name="T:BankSim.Api.Controllers.TransferController">
            <summary>
            Transfer controllers
            </summary>
        </member>
        <member name="F:BankSim.Api.Controllers.TransferController._transferService">
            <summary>
            The transfer service
            </summary>
        </member>
        <member name="F:BankSim.Api.Controllers.TransferController._accountStore">
            <summary>
            The account store
            </summary>
        </member>
        <member name="M:BankSim.Api.Controllers.TransferController.#ctor(BankSim.Domain.Services.ITransferService,BankSim.Infrastructure.Persistence.IAccountStore)">
            <summary>
            Initializes a new instance of the <see cref="T:BankSim.Api.Controllers.TransferController"/> class.
            </summary>
            <param name="transferService">The transfer service.</param>
            <param name="accountStore"></param>
        </member>
        <member name="M:BankSim.Api.Controllers.TransferController.Transfer(BankSim.Api.Models.TransferDto)">
            <summary>
            Transfers the specified dto.
            </summary>
            <param name="dto">The dto.</param>
            <returns></returns>
        </member>
        <member name="T:BankSim.Api.Middlewares.AccountMiddleware">
            <summary>
            Transfer log middleware
            </summary>
        </member>
        <member name="F:BankSim.Api.Middlewares.AccountMiddleware._next">
            <summary>
            The next
            </summary>
        </member>
        <member name="M:BankSim.Api.Middlewares.AccountMiddleware.#ctor(Microsoft.AspNetCore.Http.RequestDelegate)">
            <summary>
            Initializes a new instance of the <see cref="T:BankSim.Api.Middlewares.AccountMiddleware"/> class.
            </summary>
            <param name="next">The next.</param>
        </member>
        <member name="M:BankSim.Api.Middlewares.AccountMiddleware.InvokeAsync(Microsoft.AspNetCore.Http.HttpContext)">
            <summary>
            Invokes the asynchronous.
            </summary>
            <param name="context">The context.</param>
            <returns></returns>
        </member>
        <member name="T:BankSim.Api.Middlewares.TransferLogMiddleware">
            <summary>
            Transfer log middleware
            </summary>
        </member>
        <member name="F:BankSim.Api.Middlewares.TransferLogMiddleware._next">
            <summary>
            The next
            </summary>
        </member>
        <member name="M:BankSim.Api.Middlewares.TransferLogMiddleware.#ctor(Microsoft.AspNetCore.Http.RequestDelegate)">
            <summary>
            Initializes a new instance of the <see cref="T:BankSim.Api.Middlewares.TransferLogMiddleware"/> class.
            </summary>
            <param name="next">The next.</param>
        </member>
        <member name="M:BankSim.Api.Middlewares.TransferLogMiddleware.InvokeAsync(Microsoft.AspNetCore.Http.HttpContext)">
            <summary>
            Invokes the asynchronous.
            </summary>
            <param name="context">The context.</param>
            <returns></returns>
        </member>
        <member name="T:BankSim.Api.Models.AccountDto">
            <summary>
            The Account DTO
            </summary>
        </member>
        <member name="P:BankSim.Api.Models.AccountDto.Owner">
            <summary>
            Gets or sets the owner.
            </summary>
            <value>
            The owner.
            </value>res
        </member>
        <member name="P:BankSim.Api.Models.AccountDto.Balance">
            <summary>
            Gets or sets the balance.
            </summary>
            <value>
            The balance.
            </value>
        </member>
        <member name="M:BankSim.Api.Models.AccountDto.ToEntity(System.String,BankSim.Domain.ValueObjects.Money,System.String)">
            <summary>
            Converts to entity.
            </summary>
            <param name="owner">The owner.</param>
            <param name="amount">The amount.</param>
            <param name="AccountType">Type of the account.</param>
            <returns></returns>
        </member>
        <member name="M:BankSim.Api.Models.AccountDto.ToDto(System.String,BankSim.Domain.ValueObjects.Money)">
            <summary>
            Converts to dto.
            </summary>
            <param name="owner">The owner.</param>
            <param name="amount">The amount.</param>
            <returns></returns>
        </member>
        <member name="T:BankSim.Api.Models.TransferDto">
            <summary>
            Transfer DTO
            </summary>
        </member>
        <member name="P:BankSim.Api.Models.TransferDto.From">
            <summary>
            Gets or sets from.
            </summary>
            <value>
            From.
            </value>
        </member>
        <member name="P:BankSim.Api.Models.TransferDto.To">
            <summary>
            Gets or sets to.
            </summary>
            <value>
            To.
            </value>
        </member>
        <member name="P:BankSim.Api.Models.TransferDto.Amount">
            <summary>
            Gets or sets the amount.
            </summary>
            <value>
            The amount.
            </value>
        </member>
        <member name="P:BankSim.Api.Models.TransferDto.Description">
            <summary>
            Gets or sets the description.
            </summary>
            <value>
            The description.
            </value>
        </member>
    </members>
</doc>
