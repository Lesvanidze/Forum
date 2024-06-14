namespace Forum.Application.Common.Models
{
    public class CommentDto
    {
        public string Content { get; set; } = null!;

        public int TopicId { get; set; }
        public TopicDto Topic { get; set; } = null!;

        public string UserId { get; set; } = null!;
        public UserDto User { get; set; } = null!;

        public override string ToString() => $"Content: {Content}, TopicId: {TopicId}, UserId: {UserId}";
    }
}
