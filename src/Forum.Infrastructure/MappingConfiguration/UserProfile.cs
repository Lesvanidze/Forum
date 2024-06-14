using AutoMapper;
using Domain.Entities;
using Forum.Application.Common.Models;

namespace Forum.Infrastructure.MappingConfiguration
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserDto>();
            CreateMap<UserDto, User>();
        }
    }
}
