using Forum.Application.Common.Models;
using System.Threading;

namespace Forum.Application.Common.Services
{
    public interface ITopicService
    {
        Task<TopicDto?> GetTopicById(int topicId, CancellationToken cancellationToken);
        Task<IEnumerable<TopicDto?>> GetAllTopics(CancellationToken cancellationToken);
        Task<IEnumerable<TopicDto?>> GetTopicsByUserId(int userId, CancellationToken cancellationToken);
        Task DeleteTopicsByUserId(int userId, CancellationToken cancellationToken);
        Task ArchiveOldTopics(CancellationToken cancellationToken);
    }
}
