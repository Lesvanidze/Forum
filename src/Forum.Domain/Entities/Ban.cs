namespace Domain.Entities;

// ReSharper disable once EntityFramework.ModelValidation.UnlimitedStringLength
public class Ban : BaseEntity
{
    public DateTime BanEndDate { get; set; }
    public string? Reason { get; set; }
    
    public int UserId { get; set; }
    public User BannedUser { get; set; } 

    public override string ToString() => $"Id: {Id}, BanEndDate: {BanEndDate}, Reason: {Reason}, UserId: {UserId}";
}