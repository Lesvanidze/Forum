namespace Forum.Application.Common.Models
{
    public class BanDto
    {
        public DateTime BanEndDate { get; set; }
        public string? Reason { get; set; }

        public string UserId { get; set; } = null!;
        public UserDto BannedUser { get; set; } = null!;
        public override string ToString() => $" BanEndDate: {BanEndDate}, Reason: {Reason}, UserId: {UserId}";
    }
}
