//namespace BankSim.Api.Models.Response
//{
//    /// <summary>
//    /// Base Response for all requests
//    /// </summary>
//    public class BaseResponse<T>
//    {
//        /// <summary>
//        /// Gets or sets a value indicating whether this instance is success.
//        /// </summary>
//        /// <value>
//        ///   <c>true</c> if this instance is success; otherwise, <c>false</c>.
//        /// </value>
//        public bool IsSuccess { get; set; }

//        /// <summary>
//        /// Gets or sets the messeage.
//        /// </summary>
//        /// <value>
//        /// The messeage.
//        /// </value>
//        public required string Messeage { get; set; }

//        /// <summary>
//        /// Gets or sets the data.
//        /// </summary>
//        /// <value>
//        /// The data.
//        /// </value>
//        public required T Data { get; set; }

//        /// <summary>
//        /// Gets or sets the errors.
//        /// </summary>
//        /// <value>
//        /// The errors.
//        /// </value>
//        public List<string> Errors { get; set; } = new List<string>();

//        /// <summary>
//        /// Gets or sets the status code.
//        /// </summary>
//        /// <value>
//        /// The status code.
//        /// </value>
//        public int StatusCode { get; set; }

//        /// <summary>
//        /// Gets or sets the timestamp.
//        /// </summary>
//        /// <value>
//        /// The timestamp.
//        /// </value>
//        public DateTime Timestamp { get; set; } = DateTime.UtcNow;

//        /// <summary>
//        /// Gets or sets the request identifier.
//        /// </summary>
//        /// <value>
//        /// The request identifier.
//        /// </value>
//        public string RequestId { get; set; } = Guid.NewGuid().ToString();

//        /// <summary>
//        /// Initializes a new instance of the <see cref="BaseResponse{T}"/> class.
//        /// </summary>
//        public BaseResponse() { }

//        /// <summary>
//        /// Initializes a new instance of the <see cref="BaseResponse{T}"/> class.
//        /// </summary>
//        /// <param name="isSuccess">if set to <c>true</c> [is success].</param>
//        /// <param name="messeage">The messeage.</param>
//        /// <param name="data">The data.</param>
//        /// <param name="statusCode">The status code.</param>
//        public BaseResponse(bool isSuccess, string messeage, T data, int statusCode = 200)
//        {
//            IsSuccess = isSuccess;
//            Messeage = messeage;
//            Data = data;
//            StatusCode = statusCode;
//        }
//    }
//}

/// <summary>
/// /
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