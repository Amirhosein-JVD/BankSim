using BankSim.App.Modules;
using BankSim.Domain.Abstractions;
using BankSim.Domain.Account;
using BankSim.Domain.Services;
using BankSim.Domain.ValueObjects;
using BankSim.Infrastructure.Persistence;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace BankSim.App;

/// <summary>
/// The main entry point for the banking simulation application.
/// </summary>
public static class Program
{
    /// <summary>
    /// The main method that configures and runs the banking simulation application.
    /// </summary>
    /// <param name="args">The command-line arguments.</param>
    public static void Main(string[] args)
    {
        var builder = Host.CreateDefaultBuilder(args)
            .ConfigureServices(services =>
            {
                services.AddStatementsModule();
                services.AddAccountsModule();
            });

        var host = builder.Build();

        using var scope = host.Services.CreateScope();
        var sp = scope.ServiceProvider;

        var transfer = sp.GetRequiredService<ITransferService>();
        var statement = sp.GetRequiredService<IStatementService>();
        var accountStore = sp.GetRequiredService<IAccountStore>();

        AccountBase alice = new CheckingAccount("Alice", new Money(1200m, Currency.USD));
        AccountBase bob   = new CheckingAccount("Bob",   new Money( 700m, Currency.USD));

        accountStore.Add(alice);
        accountStore.Add(bob);


        foreach (var item in accountStore.GetAll())
        {
            Console.WriteLine(item);
            Console.WriteLine("\n--------------------------------------------------------------------\n");
        }

        // Example (updated signatures):
        // alice.Deposit(new Money(900m, MoneyType.USD), "seed");
        // transfer.Transfer(alice, bob, new Money(200m, MoneyType.USD), "gift");
        // Console.WriteLine(alice);
        // Console.WriteLine(bob);
    }
}