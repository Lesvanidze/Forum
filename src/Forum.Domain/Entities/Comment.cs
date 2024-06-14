namespace Domain.Entities;

// ReSharper disable once EntityFramework.ModelValidation.UnlimitedStringLength
public class Comment : BaseEntity
{
    public string Content { get; set; } 

    public int TopicId { get; set; }
    public Topic Topic { get; set; } 
    
    public int UserId { get; set; } 
    public User User { get; set; }

    public override string ToString() => $"Id: {Id}, Content: {Content}, TopicId: {TopicId}, UserId: {UserId}";
}