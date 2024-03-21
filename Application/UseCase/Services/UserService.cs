using Application.DTO.Error;
using Application.DTO.Request;
using Application.DTO.Response;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;


namespace Application.UseCase.Services
{
    public class UserService : Service<UserRequest, UserResponse, User>, IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository, IMapper mapper) : base(userRepository, mapper)
        {
            _userRepository = userRepository;
        }


        public override async Task<UserResponse> Update(int id, UserRequest request)
        {
            try
            {
                if (id <= 0)
                {
                    throw new BadRequestException("The ID must be greater than zero.");
                }
                var user = await _userRepository.RecoveryById(id);
                if (user != null)
                {
                    user.UserName = request.UserName;
                    user.Name = request.Name;
                    user.Surname = request.Surname;

                    var updatedUser = await _userRepository.Update(user);

                    return _mapper.Map<UserResponse>(updatedUser);
                }
                else
                {
                    throw new NotFoundException("The User with ID " + id + " was not found.");
                }
            }
            catch (Exception e)
            {
                if (e is HTTPError)
                {
                    throw e;
                }
                if (e is DbUpdateException)
                {
                    throw new ConflictException("There is a record with the same UserName.");
                }
                throw new InternalServerErrorException(e.Message);
            }
        }

    }
}
