namespace BankSim.Api.Middlewares
{
    /// <summary>
    /// Transfer log middleware
    /// </summary>
    public class TransferLogMiddleware
    {
        /// <summary>
        /// The next
        /// </summary>
        private readonly  RequestDelegate _next;

        /// <summary>
        /// Initializes a new instance of the <see cref="TransferLogMiddleware"/> class.
        /// </summary>
        /// <param name="next">The next.</param>
        public TransferLogMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        /// <summary>
        /// Invokes the asynchronous.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <returns></returns>
        public async Task InvokeAsync(HttpContext context)
        {
            if (context.Request.Path.StartsWithSegments("/api/Transfer"))
            {
                var start = DateTime.UtcNow;

                if (context.Response.StatusCode == 200)
                {
                    var duration = DateTime.UtcNow - start;
                    Console.WriteLine($"[Success] {context.Request.Method} {context.Request.Path} completed in {duration.TotalMilliseconds} ms");

                }
            }
            await _next(context);

        }
    }
}
