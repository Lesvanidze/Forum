

using Domain.Enums;

namespace Domain.Entities;

// ReSharper disable once EntityFramework.ModelValidation.UnlimitedStringLength
public class Topic : BaseEntity
{
    public string Title { get; set; } 
    public string Content { get; set; }
    public State State { get; set; } = State.Pending;
    public Status Status { get; set; } = Status.Active;
    public int UserId { get; set; } 
    public User User { get; set; } 
    public IEnumerable<Comment>? Comments {get; set; }
    public override string ToString() =>
        $"Id: {Id}, Title: {Title}, Content: {Content}, State: {State}, Status: {Status},s UserId: {UserId}";
}