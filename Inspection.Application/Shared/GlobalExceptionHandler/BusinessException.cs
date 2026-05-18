public class BusinessException : Exception
{
    //public HttpStatusCode StatusCode { get; }
    //public List<string> Errors { get; }

    //public BusinessException(
    //    string message,
    //    List<string>? errors = null,
    //    HttpStatusCode statusCode = HttpStatusCode.BadRequest
    //) : base(message)
    //{
    //    StatusCode = statusCode;
    //    Errors = errors ?? new();
    //}
    public BusinessException() { }

    public BusinessException(string message)
        : base(message) { }

    public BusinessException(string message, Exception innerException)
        : base(message, innerException) { }
}
