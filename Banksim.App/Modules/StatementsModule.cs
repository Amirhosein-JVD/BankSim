using BankSim.Domain.Services;
using Microsoft.Extensions.DependencyInjection;

namespace BankSim.App.Modules;

/// <summary>
/// This static class provides an extension method to register the Statements module services.
/// </summary>
public static class StatementsModule
{
    /// <summary>
    /// This method registers the services required for the Statements module.
    /// </summary>
    /// <param name="services">The service collection to which the module services will be added.</param>
    /// <returns>The updated service collection.</returns>
    public static IServiceCollection AddStatementsModule(this IServiceCollection services)
    {
            services.AddScoped<IStatementService, StatementService>();
            services.AddScoped<ITransferService, TransferService>();
            return services;
    }
}