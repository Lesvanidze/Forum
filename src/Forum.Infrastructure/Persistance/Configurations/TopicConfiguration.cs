using Domain.Enums;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Configurations;

public class TopicConfiguration : IEntityTypeConfiguration<Topic>
{
    public void Configure(EntityTypeBuilder<Topic> builder)
    {
        builder
            .HasOne(t => t.User)
            .WithMany(a => a.Topics)
            .HasForeignKey(t => t.UserId)
            .IsRequired(false);

        builder.Property(t => t.Title).HasMaxLength(80);
        builder.Property(t => t.Content).HasMaxLength(2000);

        builder.Property(t => t.Status)
            .HasConversion(s => s == Status.Active,
                s => s
                    ? Status.Active
                    : Status.Inactive);

        builder.HasIndex(t => t.Title);

    
        SeedData(builder);
    }
    
    private void SeedData(EntityTypeBuilder<Topic> builder)
    {
        builder.HasData(
            new Topic
            {
                Id = 1,
                Title = "First Topic",
                Content = "This is the content of the first topic.",
                State = State.Pending,
                Status = Status.Active,
                UserId = 1
            },
            new Topic
            {
                Id = 2,
                Title = "Second Topic",
                Content = "This is the content of the second topic.",
                State = State.Pending,
                Status = Status.Active,
                UserId = 2
            },
            new Topic
            {
                Id = 3,
                Title = "Third Topic",
                Content = "This is the content of the third topic.",
                State = State.Pending,
                Status = Status.Inactive,
                UserId = 3
            }
        );
    }
}