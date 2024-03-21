using System.Net;

namespace Application.DTO.Error
{
    public class HTTPError : Exception
    {
        public HttpStatusCode StatusCode { get; }
        public string Status { get; }
        public HTTPError(HttpStatusCode statusCode, string status, string message) : base (message)
        {
            StatusCode = statusCode;
            Status = status;
        }
    }
}
