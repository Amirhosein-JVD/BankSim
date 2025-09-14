using Microsoft.Extensions.DependencyInjection;

public static class DomainServiceExtensions
{
    public static IServiceCollection AddDomianService(this IServiceCollection services)
    {
        services.AddScoped<ITransferService, TransferService>();
        services.AddScoped<IStatementService, StatementService>();  
        return services;
    }
}