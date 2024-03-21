using System.Net;

namespace Application.DTO.Response
{
    public class HTTPResponse<T>where T : class
    {
        public HTTPResponse()
        {
        }
        public HttpStatusCode StatusCode { get; set; }
        public string Status {  get; set; }
        public string Message { get; set; }
        public T Result { get; set; }

    }
}
