using System.Net;

namespace Fetch
{
    public class FetchResponse<T>
    {
        public HttpStatusCode StatusCode { get; }
        public T Content { get; }
        public string Message { get; }
        public dynamic Error { get; }
        public bool HasError { get; } = false;

        public FetchResponse(HttpStatusCode statusCode)
        {
            StatusCode = statusCode;
        }
        public FetchResponse(HttpStatusCode statusCode, T data)
        {
            StatusCode = statusCode;
            Content = data;
        }
        public FetchResponse(HttpStatusCode statusCode, string message)
        {
            StatusCode = statusCode;
            Message = message;
        }

        public FetchResponse(HttpStatusCode statusCode, string message, dynamic error)
        {
            StatusCode = statusCode;
            Message = message;
            Error = error;
            HasError = true;
        }
    }
}
