namespace Forum.Application.Common.Models
{
    public class UserDto
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public bool IsAdmin { get; set; }
        public bool IsBanned { get; set; }
        public override string ToString() => $"UserName: {UserName}, Email: {Email}, IsAdmin: {IsAdmin}, IsBanned: {IsBanned}";
    }
}
