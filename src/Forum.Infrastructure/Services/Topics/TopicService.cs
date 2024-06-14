using AutoMapper;
using Domain.Entities;
using Forum.Application.Common.Models;
using Forum.Application.Common.Services;
using Forum.Application.Common.Services.DatabaseService;
using Microsoft.Extensions.Configuration;
using System.Data.Entity;

namespace Forum.Infrastructure.Services.Topics
{
    public class TopicService : ITopicService
    {
        private readonly IDatabaseService databaseService;
        private readonly IMapper mapper;
        private readonly IConfiguration configuration;
        private readonly double ArchiveAfterDays = 30;

        public TopicService(IMapper mapper, IDatabaseService databaseService, IConfiguration configuration)
        {
            this.mapper = mapper;
            this.databaseService = databaseService;
            this.configuration = configuration;
        }

        public async Task ArchiveOldTopics(CancellationToken cancellationToken)
        {

            var topics = await databaseService.Topics.ToListAsync(cancellationToken);
            List<Comment> comments;
            foreach(var topic in topics)
            {
                comments = await databaseService.Comments.Where(c => c.TopicId == topic.Id).ToListAsync(cancellationToken);
                foreach(var comment in comments)
                {
                    if(comment.CreationDate.AddDays(ArchiveAfterDays) > DateTime.Now)
                    {
                        topic.Status = Domain.Enums.Status.Inactive;
                    }
                }
            }
        }

        public async Task DeleteTopicsByUserId(int userId, CancellationToken cancellationToken)
        {
            var topics = await databaseService.Topics.Where(t => t.UserId == userId).ToListAsync(cancellationToken);

            databaseService.Topics.RemoveRange(topics);
        }

        public async Task<IEnumerable<TopicDto>> GetAllTopics(CancellationToken cancellationToken)
        {
            var result = await databaseService.Topics.Where(t => t.Status == Domain.Enums.Status.Active).ToListAsync();

            return mapper.Map<IEnumerable<TopicDto>>(result);
        }

        public async Task<TopicDto?> GetTopicById(int topicId,CancellationToken cancellationToken)
        {
            var result = await databaseService.Topics.Where(t => t.Id == topicId).ToListAsync(cancellationToken);

            return mapper.Map<TopicDto?>(result);
        }

        public async Task<IEnumerable<TopicDto?>> GetTopicsByUserId(int userId, CancellationToken cancellationToken)
        {
            var result = await databaseService.Topics.Where(t => t.UserId == userId).ToListAsync(cancellationToken);

            return mapper.Map<IEnumerable<TopicDto?>>(result);
        }
    }
}
