using Microsoft.AspNet.Identity.EntityFramework;

namespace Domain.Entities;

public class User
{ 
    public int Id { get; set; }
    public string UserName { get; set; }
    public string Email { get; set; }
    public bool IsAdmin { get; set; } 
    public bool IsBanned { get; set; }
    public virtual Ban? BanInfo { get; set; }

    public virtual IEnumerable<Topic>? Topics { get; set; } 
    public virtual IEnumerable<Comment>? Comments { get; set; }
    public override string ToString() => $"Id: {Id}, UserName: {UserName}, Email: {Email}, IsAdmin: {IsAdmin}, IsBanned: {IsBanned}";
}