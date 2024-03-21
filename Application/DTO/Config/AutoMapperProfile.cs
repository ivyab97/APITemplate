using Application.DTO.Error;
using Application.DTO.Request;
using Application.DTO.Response;
using AutoMapper;
using Domain.Entities;

namespace Application.DTO.Config
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<UserRequest, User>().ReverseMap();
            CreateMap<UserRequest, UserResponse>().ReverseMap();
            CreateMap<User, UserResponse>().ReverseMap();
            CreateMap<HTTPError, HTTPResponse<string>>().ReverseMap();
        }
    }
}
