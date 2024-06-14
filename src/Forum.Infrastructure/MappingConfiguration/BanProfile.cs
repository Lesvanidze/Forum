using AutoMapper;
using Domain.Entities;
using Forum.Application.Common.Models;

namespace Forum.Infrastructure.MappingConfiguration
{
    public class BanProfile : Profile
    {
        public BanProfile()
        {
            CreateMap<Ban, BanDto>();
            CreateMap<BanDto, Ban>();
        }
    }
}
