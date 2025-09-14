using Microsoft.Extensions.DependencyInjection;

public static class AcountsModule
{
    public static IServiceCollection AddAccountsModule(this IServiceCollection services)
    {
        services.AddSingleton<IAccountStore, InMemoryAccountStore>();
        return services;
    }

    //TODO
}