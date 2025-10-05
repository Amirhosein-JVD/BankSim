using NATS.Net;

namespace Banksim.Consumer
{
    /// <summary>
    /// This is consumer
    /// </summary>
    public static class Program
    {
        /// <summary>
        /// Defines the entry point of the application.
        /// </summary>
        /// <param name="args">The arguments.</param>
        public static async Task Main(string[] args)
        {
            await using var client = new NatsClient();
            Console.WriteLine("Listening for user entity changes: ");
            while (true)
            {
                await foreach (var msg in client.SubscribeAsync<string>(subject: "users.>"))
                {
                    Console.WriteLine($"Message: {msg.Data} on subject: {msg.Subject}");
                }
            }
        }
    }
}