using Microsoft.Extensions.Hosting;
using Orleans.Configuration;

namespace Banksim.OrleansHost
{
    /// <summary>
    /// This is palace that we run silo server 
    /// </summary>
    public static class Program
    {
        /// <summary>
        /// Defines the entry point of the application.
        /// </summary>
        /// <param name="args">The arguments.</param>
        public static async Task Main(string[] args)
        {
            try
            {
                await Host.CreateDefaultBuilder(args)
                    .UseOrleans(siloBuilder =>
                    {
                        siloBuilder.UseLocalhostClustering()
                            .AddMemoryGrainStorage("accountState");

                        siloBuilder.Configure<ClusterOptions>(clusterOptions =>
                        {
                            clusterOptions.ClusterId = "Banksim.OrleansHost";
                            clusterOptions.ServiceId = "Banksim.ServiceId";
                        });
                    }).RunConsoleAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error starting Orleans host: {ex.Message}");
            }
        }
    }
}