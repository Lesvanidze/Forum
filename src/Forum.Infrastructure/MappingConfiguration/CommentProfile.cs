using AutoMapper;
using Domain.Entities;
using Forum.Application.Common.Models;

namespace Forum.Infrastructure.MappingConfiguration
{
    public class CommentProfile : Profile
    {
        public CommentProfile()
        {
            CreateMap<Comment, CommentDto>();
            CreateMap<CommentDto, Comment>();
        }
    }
}
