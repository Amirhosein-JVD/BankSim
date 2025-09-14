using BankSim.Infrastructure.Persistence;
using Microsoft.Extensions.DependencyInjection;

namespace BankSim.App.Modules;

/// <summary>
/// This static class provides an extension method to register the Accounts module services.
/// </summary>
public static class AccountsModule
{
    /// <summary>
    /// This method registers the services required for the Accounts module, including the account store.
    /// </summary>
    /// <param name="services">The service collection to which the module services will be added.</param>
    /// <returns>The updated service collection.</returns>
    public static IServiceCollection AddAccountsModule(this IServiceCollection services)
    {
        services.AddSingleton<IAccountStore, InMemoryAccountStore>();
        return services;
    }
}