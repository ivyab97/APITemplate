using System.Net;

namespace Application.DTO.Error
{
    public class ForbiddenException : HTTPError
    {
        public ForbiddenException(string message) : base((HttpStatusCode)403, "Forbidden", message)
        {
        }
    }
}