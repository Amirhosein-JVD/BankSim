
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;



public class Program
{

    public static void Main(string[] args)
    {
        var host = Host.CreateDefaultBuilder(args).ConfigureServices(services =>
        {
            services.AddSingleton<IStatementService, StatementService>();
            services.AddSingleton<ITransferService, TransferService>();
            services.AddSingleton<IAccountStore, InMemoryAccountStore>();

        }).Build();

        using var scope = host.Services.CreateScope();
        var sp = scope.ServiceProvider;

        var transfer = sp.GetRequiredService<ITransferService>();
        var statement = sp.GetRequiredService<IStatementService>();
        var accountStore = sp.GetRequiredService<IAccountStore>();

        AccountBase alice = new CheckingAccount("Alice", new Money { Amount = 1200M, Currency = MoneyType.USD });
        AccountBase bob = new CheckingAccount("Bob", new Money { Amount = 700M, Currency = MoneyType.USD });

        accountStore.Add(alice);
        accountStore.Add(bob);


        foreach (var item in accountStore.GetAll())
        {
            Console.WriteLine(item);
            Console.WriteLine("\n--------------------------------------------------------------------\n");
        }

        //alice.Deposit(new Money { Amount = 900M, Currency = MoneyType.USD }, TransactionType.Deposit, "seed");
        //transfer.Transfer(alice, bob, new Money { Amount = 200M, Currency = MoneyType.USD }, "gift");
        //Console.WriteLine(alice.ToString());
        //Console.WriteLine(bob.ToString());

    }
}