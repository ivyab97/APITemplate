using System.Net;

namespace Application.DTO.Error
{
    public class TooManyRequestsException : HTTPError
    {
        public TooManyRequestsException(string message) : base((HttpStatusCode)404, "Too Many Requests", message)
        {
        }
    }
}
