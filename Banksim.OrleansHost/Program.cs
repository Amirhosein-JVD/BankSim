using Microsoft.Extensions.Hosting;
using Orleans.Configuration;

namespace Banksim.OrleansHost
{

    /// <summary>
    /// This is palace that we run silo server 
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Defines the entry point of the application.
        /// </summary>
        /// <param name="args">The arguments.</param>
        public static async Task Main(string[] args)
        {
            await Host.CreateDefaultBuilder(args)
                .UseOrleans(siloBuilder =>
                {
                    siloBuilder.UseLocalhostClustering()
                    .AddMemoryGrainStorage("accountState");

                    siloBuilder.Configure<ClusterOptions>(configureOptions: option =>
                    {
                        option.ClusterId = "Banksim.OrleansHost";
                        option.ServiceId = "Banksim.ServiceId";
                    });
                }).RunConsoleAsync();
        }
    }
}