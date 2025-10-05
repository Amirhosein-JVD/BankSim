namespace BankSim.Api.Middlewares;

/// <summary>
/// Transfer log middleware
/// </summary>
public class LogMiddleware
{
    /// <summary>
    /// The next
    /// </summary>
    private readonly RequestDelegate _next;

    private readonly ILogger<LogMiddleware> _logger;

    /// <summary>
    /// Initializes a new instance of the <see cref="LogMiddleware"/> class.
    /// </summary>
    /// <param name="next">The next.</param>
    /// <param name="logger">The logger.</param>
    public LogMiddleware(RequestDelegate next, ILogger<LogMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    /// <summary>
    /// Invokes the asynchronous.
    /// </summary>
    /// <param name="context">The context.</param>
    /// <returns></returns>
    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            // Log request details
            _logger.LogInformation("Request: {RequestMethod} {RequestPath}", context.Request.Method,
                context.Request.Path);

            await _next(context); // Call the next middleware

            // Log response details
            _logger.LogInformation("Response: {ResponseStatusCode}", context.Response.StatusCode);
        }
        catch (Exception ex)
        {
            // Log any unhandled exceptions
            _logger.LogError(ex, "An error occurred processing the request.");
            throw; // Re-throw the exception
        }
    }
}