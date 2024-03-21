namespace Application.Interfaces
{
    public interface IService<Request, Response> where Request : class where Response : class
    {
        Task<Response> Create(Request request);
        Task DeleteById(int id);
        Task<List<Response>> GetAll();
        Task<Response> GetById(int id);
        Task<Response> Update(int id, Request request);
    }
}
