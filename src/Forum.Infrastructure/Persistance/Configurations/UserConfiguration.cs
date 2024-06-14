using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.Property(u => u.Email).HasMaxLength(80);

        builder.HasKey(u => u.Id);

        builder
            .HasMany(u => u.Topics)
            .WithOne(u => u.User);

        builder
            .HasMany(u => u.Comments)
            .WithOne(u => u.User);


        SeedData(builder);
    }
    
    private void SeedData(EntityTypeBuilder<User> builder)
    {
        builder.HasData(
            new User
            {
                UserName = "john.doe",
                Email = "john.doe@example.com",
                IsAdmin = false,
                IsBanned = false
            },
            new User
            {
                UserName = "jane.smith",
                Email = "jane.smith@example.com",
                IsAdmin = false,
                IsBanned = false
            },
            new User
            {
                UserName = "admin",
                Email = "admin@example.com",
                IsAdmin = true,
                IsBanned = false
            },
            new User
            {
                UserName = "banned.user",
                Email = "banned.user@example.com",
                IsAdmin = false,
                IsBanned = true
            }
        );
    }
}