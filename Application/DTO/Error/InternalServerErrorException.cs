using System.Net;

namespace Application.DTO.Error
{
    public class InternalServerErrorException : HTTPError
    {
        public InternalServerErrorException(string message) : base((HttpStatusCode)500, "Internal Server Error", message)
        {
        }
    }
}