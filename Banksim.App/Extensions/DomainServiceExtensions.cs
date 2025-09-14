using BankSim.Domain.Services;
using Microsoft.Extensions.DependencyInjection;

namespace BankSim.App.Extensions;

/// <summary>
/// This static class provides extension methods for registering domain services in the service collection.
/// </summary>
public static class DomainServiceExtensions
{
    /// <summary>
    /// This method registers domain services such as ITransferService and IStatementService with their
    /// respective implementations in the provided service collection.
    /// </summary>
    /// <param name="services">The service collection to which domain services will be added.</param>
    /// <returns>The updated service collection with domain services registered.</returns>
    public static IServiceCollection AddDomainServices(this IServiceCollection services)
    {
        services.AddScoped<ITransferService, TransferService>();
        services.AddScoped<IStatementService, StatementService>();  
        return services;
    }
}