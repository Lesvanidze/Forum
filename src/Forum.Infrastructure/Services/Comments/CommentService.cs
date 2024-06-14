using AutoMapper;
using Forum.Application.Common.Models;
using Forum.Application.Common.Services;
using Forum.Application.Common.Services.DatabaseService;
using Microsoft.EntityFrameworkCore;

namespace Forum.Infrastructure.Services.Comments
{
    public class CommentService : ICommentService
    {
        private readonly IDatabaseService databaseService;
        private readonly IMapper mapper;

        public CommentService(IMapper mapper, IDatabaseService databaseService)
        {
            this.mapper = mapper;
            this.databaseService = databaseService;
        }

        public async Task DeleteCommentsByUserId(int userId, CancellationToken cancellationToken)
        {
            var comment = await databaseService.Comments.Where(c => c.UserId == userId).FirstOrDefaultAsync(cancellationToken) ?? throw new InvalidOperationException("Comment Not Found");
            databaseService.Comments.Remove(comment);
        }

        public async Task<CommentDto?> GetCommentById(int commentId, CancellationToken cancellationToken)
        {
            var result = await databaseService.Comments.Where(c => c.Id == commentId).FirstOrDefaultAsync(cancellationToken) ?? throw new InvalidOperationException("Comment not found");

            return mapper.Map<CommentDto>(result);
        }

        public async Task<IEnumerable<CommentDto>> GetCommentsByTopicId(int topicId, CancellationToken cancellationToken)
        {
            var result = await databaseService.Comments.Where(c => c.TopicId == topicId).ToListAsync(cancellationToken) ?? throw new InvalidOperationException("Comment not found");

            return mapper.Map<IEnumerable<CommentDto>>(result);
        }

        public async Task<IEnumerable<CommentDto?>> GetCommentsByUserId(int userId, CancellationToken cancellationToken)
        {
            var result = await databaseService.Comments.Where(c => c.UserId == userId).ToListAsync(cancellationToken) ?? throw new InvalidOperationException("Comments not found ");

            return mapper.Map<IEnumerable<CommentDto?>>(result);
        }

        public  async Task<int> GetCommentsCountByTopicId(int topicId, CancellationToken cancellationToken)
        {
            var result = await databaseService.Comments.Where(c => c.TopicId == topicId).CountAsync(cancellationToken);

            return result;
        }

        public async Task<int> GetCommentsCountByUserId(int userId, CancellationToken cancellationToken)
        {
            var result = await databaseService.Comments.Where(c => c.UserId == userId).CountAsync(cancellationToken);

            return result;
        }
    }
}
