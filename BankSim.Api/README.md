<?xml version="1.0"?>
<doc>
    <assembly>
        <name>BankSim.Api</name>
    </assembly>
    <members>
        <member name="T:BankSim.Api.Controllers.AccountsController">
            <summary>
            Controllers of accounts
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
        <member name="M:BankSim.Api.Controllers.AccountsController.#ctor(BankSim.Infrastructure.Persistence.IAccountStore,BankSim.Domain.Services.IStatementService,BankSim.Domain.Account.IAccountFactoryService)">
            <summary>
            Initializes a new instance of the <see cref="T:BankSim.Api.Controllers.AccountsController"/> class.
            </summary>
            <param name="accountStore">The account store.</param>
            <param name="statementService">The statement service.</param>
            <param name="accountFactoryService">The account factory service.</param>
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
            <param name="id">The identifier.</param>
            <returns></returns>
            <exception cref="T:System.NotImplementedException"></exception>
        </member>
        <member name="M:BankSim.Api.Controllers.AccountsController.AddAccount(BankSim.Api.Models.Requestes.AccountRequestDto,AccountTypesEnum)">
            <summary>
            Adds the account.
            </summary>
            <param name="dto">The dto.</param>
            <param name="accountType">Type of the account.</param>
            <returns></returns>
            <exception cref="T:BankSim.Domain.Exceptions.DomainException">Acconut not founded!</exception>
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
        <member name="M:BankSim.Api.Controllers.TransferController.Transfer(BankSim.Api.Models.Requestes.TransferDto)">
            <summary>
            Transfers the specified dto.
            </summary>
            <param name="dto">The dto.</param>
            <returns></returns>
        </member>
        <member name="T:BankSim.Api.Middlewares.LogMiddleware">
            <summary>
            Transfer log middleware
            </summary>
        </member>
        <member name="F:BankSim.Api.Middlewares.LogMiddleware._next">
            <summary>
            The next
            </summary>
        </member>
        <member name="M:BankSim.Api.Middlewares.LogMiddleware.#ctor(Microsoft.AspNetCore.Http.RequestDelegate)">
            <summary>
            Initializes a new instance of the <see cref="T:BankSim.Api.Middlewares.LogMiddleware"/> class.
            </summary>
            <param name="next">The next.</param>
        </member>
        <member name="M:BankSim.Api.Middlewares.LogMiddleware.InvokeAsync(Microsoft.AspNetCore.Http.HttpContext)">
            <summary>
            Invokes the asynchronous.
            </summary>
            <param name="context">The context.</param>
            <returns></returns>
        </member>
        <member name="T:BankSim.Api.Models.Requestes.AccountRequestDto">
            <summary>
            The Account DTO
            </summary>
        </member>
        <member name="P:BankSim.Api.Models.Requestes.AccountRequestDto.Owner">
            <summary>
            Gets or sets the owner.
            </summary>
            <value>
            The owner.
            </value>res
        </member>
        <member name="P:BankSim.Api.Models.Requestes.AccountRequestDto.Balance">
            <summary>
            Gets or sets the balance.
            </summary>
            <value>
            The balance.
            </value>
        </member>
        <member name="M:BankSim.Api.Models.Requestes.AccountRequestDto.ToDto(System.String,BankSim.Domain.ValueObjects.Money)">
            <summary>
            Converts to dto.
            </summary>
            <param name="owner">The owner.</param>
            <param name="amount">The amount.</param>
            <returns></returns>
        </member>
        <member name="T:BankSim.Api.Models.Requestes.TransferDto">
            <summary>
            Transfer DTO
            </summary>
        </member>
        <member name="P:BankSim.Api.Models.Requestes.TransferDto.From">
            <summary>
            Gets or sets from.
            </summary>
            <value>
            From.
            </value>
        </member>
        <member name="P:BankSim.Api.Models.Requestes.TransferDto.To">
            <summary>
            Gets or sets to.
            </summary>
            <value>
            To.
            </value>
        </member>
        <member name="P:BankSim.Api.Models.Requestes.TransferDto.Amount">
            <summary>
            Gets or sets the amount.
            </summary>
            <value>
            The amount.
            </value>
        </member>
        <member name="P:BankSim.Api.Models.Requestes.TransferDto.Description">
            <summary>
            Gets or sets the description.
            </summary>
            <value>
            The description.
            </value>
        </member>
        <member name="T:BankSim.Api.Models.Requestes.AccountResponseDto">
            <summary>
            The Account DTO
            </summary>
        </member>
        <member name="P:BankSim.Api.Models.Requestes.AccountResponseDto.Owner">
            <summary>
            Gets or sets the owner.
            </summary>
            <value>
            The owner.
            </value>res
        </member>
        <member name="P:BankSim.Api.Models.Requestes.AccountResponseDto.Balance">
            <summary>
            Gets or sets the balance.
            </summary>
            <value>
            The balance.
            </value>
        </member>
        <member name="T:ApiResult`1">
            <summary>
            Api reslult
            </summary>
            <typeparam name="T"></typeparam>
        </member>
        <member name="M:ApiResult`1.#ctor(`0,System.String,System.String)">
            <summary>
            Api reslult
            </summary>
            <typeparam name="T"></typeparam>
        </member>
        <member name="M:ApiResult`1.Ok(`0,System.String)">
            <summary>
            Oks the specified data.
            </summary>
            <param name="data">The data.</param>
            <param name="traceId">The trace identifier.</param>
            <returns></returns>
        </member>
        <member name="M:ApiResult`1.Fail(System.String,System.String)">
            <summary>
            Fails the specified error.
            </summary>
            <param name="error">The error.</param>
            <param name="traceId">The trace identifier.</param>
            <returns></returns>
        </member>
    </members>
</doc>
