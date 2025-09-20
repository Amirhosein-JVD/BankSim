/// <summary>
/// Api reslult
/// </summary>
/// <typeparam name="T"></typeparam>
public record ApiResult<T> (T? Data, string? Error = null, string TraceId="")
{
    /// <summary>
    /// Oks the specified data.
    /// </summary>
    /// <param name="data">The data.</param>
    /// <param name="traceId">The trace identifier.</param>
    /// <returns></returns>
    public static ApiResult<T> Ok(T data, string traceId ="") => new(data, null, traceId);

    /// <summary>
    /// Fails the specified error.
    /// </summary>
    /// <param name="error">The error.</param>
    /// <param name="traceId">The trace identifier.</param>
    /// <returns></returns>
    public static ApiResult<T> Fail(string error, string traceId ="") => new(default, null, traceId);
}