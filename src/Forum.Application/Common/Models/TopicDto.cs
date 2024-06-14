namespace Forum.Application.Common.Models
{
    public class TopicDto
    {
        public string Title { get; set; } 
        public string Content { get; set; } 
        public string State { get; set; }
        public string Status { get; set; } 
        public string UserId { get; set; }
        public UserDto User { get; set; } 
        public IEnumerable<CommentDto>? Comments { get; set; }
        public override string ToString() =>
            $" Title: {Title}, Content: {Content}, State: {State}, Status: {Status},s UserId: {UserId}";
    }
}
