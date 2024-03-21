using Application.DTO.Request;
using Application.DTO.Response;

namespace Application.Interfaces
{
    public interface IUserService : IService<UserRequest, UserResponse>
    {
    }
}
