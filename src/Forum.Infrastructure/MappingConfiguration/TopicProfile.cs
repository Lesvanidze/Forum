using AutoMapper;
using Domain.Entities;
using Forum.Application.Common.Models;

namespace Forum.Infrastructure.MappingConfiguration
{
    public class TopicProfile : Profile
    {
        public TopicProfile()
        {
            CreateMap<Topic, TopicDto>();
            CreateMap<TopicDto, Topic>();
        }
    }
}
