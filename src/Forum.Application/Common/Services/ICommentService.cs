using Forum.Application.Common.Models;

namespace Forum.Application.Common.Services
{
    public interface ICommentService
    {

        Task<CommentDto?> GetCommentById(int commentId, CancellationToken cancellationToken);

        Task<IEnumerable<CommentDto?>> GetCommentsByTopicId(int topicId, CancellationToken cancellationToken);

        Task<IEnumerable<CommentDto?>> GetCommentsByUserId(int userId, CancellationToken cancellationToken);

        Task<int> GetCommentsCountByTopicId(int topicId, CancellationToken cancellationToken);

        Task<int> GetCommentsCountByUserId(int userId, CancellationToken cancellationToken);

        Task DeleteCommentsByUserId(int userId, CancellationToken cancellationToken);
    }
}
