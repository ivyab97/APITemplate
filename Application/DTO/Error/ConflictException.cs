using System.Net;

namespace Application.DTO.Error
{
    public class ConflictException : HTTPError
    {
        public ConflictException(string message) : base((HttpStatusCode)409, "Conflict", message)
        {
        }
    }
}