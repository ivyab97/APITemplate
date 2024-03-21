using System.Net;

namespace Application.DTO.Error
{
    public class UnauthorizedException : HTTPError
    {
        public UnauthorizedException(string message) : base((HttpStatusCode)401, "Unauthorized", message)
        {
        }
    }
}