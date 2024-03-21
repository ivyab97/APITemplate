using System.Net;

namespace Application.DTO.Error
{
    public class NoContentException : HTTPError
    {
        public NoContentException(string message) : base((HttpStatusCode)204, "No Content", message)
        {
        }
    }
}