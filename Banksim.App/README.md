<?xml version="1.0"?>
<doc>
    <assembly>
        <name>BankSim.App</name>
    </assembly>
    <members>
        <member name="T:BankSim.App.Extensions.DomainServiceExtensions">
            <summary>
            This static class provides extension methods for registering domain services in the service collection.
            </summary>
        </member>
        <member name="M:BankSim.App.Extensions.DomainServiceExtensions.AddDomainServices(Microsoft.Extensions.DependencyInjection.IServiceCollection)">
            <summary>
            This method registers domain services such as ITransferService and IStatementService with their
            respective implementations in the provided service collection.
            </summary>
            <param name="services">The service collection to which domain services will be added.</param>
            <returns>The updated service collection with domain services registered.</returns>
        </member>
        <member name="T:BankSim.App.Modules.AccountsModule">
            <summary>
            This static class provides an extension method to register the Accounts module services.
            </summary>
        </member>
        <member name="M:BankSim.App.Modules.AccountsModule.AddAccountsModule(Microsoft.Extensions.DependencyInjection.IServiceCollection)">
            <summary>
            This method registers the services required for the Accounts module, including the account store.
            </summary>
            <param name="services">The service collection to which the module services will be added.</param>
            <returns>The updated service collection.</returns>
        </member>
        <member name="T:BankSim.App.Modules.StatementsModule">
            <summary>
            This static class provides an extension method to register the Statements module services.
            </summary>
        </member>
        <member name="M:BankSim.App.Modules.StatementsModule.AddStatementsModule(Microsoft.Extensions.DependencyInjection.IServiceCollection)">
            <summary>
            This method registers the services required for the Statements module.
            </summary>
            <param name="services">The service collection to which the module services will be added.</param>
            <returns>The updated service collection.</returns>
        </member>
        <member name="T:BankSim.App.Program">
            <summary>
            The main entry point for the banking simulation application.
            </summary>
        </member>
        <member name="M:BankSim.App.Program.Main(System.String[])">
            <summary>
            The main method that configures and runs the banking simulation application.
            </summary>
            <param name="args">The command-line arguments.</param>
        </member>
    </members>
</doc>
