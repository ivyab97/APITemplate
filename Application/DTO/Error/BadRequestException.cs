using System.Net;

namespace Application.DTO.Error
{
    public class BadRequestException : HTTPError
    {
        public BadRequestException(string message) : base((HttpStatusCode)400, "Bad Request", message)
        {
        }
    }
}
