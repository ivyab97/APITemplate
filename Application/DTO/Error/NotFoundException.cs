using System.Net;

namespace Application.DTO.Error
{
    public class NotFoundException : HTTPError
    {
        public NotFoundException(string message) : base((HttpStatusCode)404, "Not Found", message)
        { 
        }
    }
}
