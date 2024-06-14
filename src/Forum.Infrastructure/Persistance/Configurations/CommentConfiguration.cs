using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Configurations;

public class CommentConfiguration : IEntityTypeConfiguration<Comment>
{
    public void Configure(EntityTypeBuilder<Comment> builder)
    {
        builder
            .HasOne(c => c.User)
            .WithMany(c => c.Comments)
            .OnDelete(DeleteBehavior.Cascade);

        builder
            .HasOne(c => c.Topic)
            .WithMany(t => t.Comments)
            .HasForeignKey(c => c.TopicId)
            .OnDelete(DeleteBehavior.Cascade);

        builder
            .Property(c => c.Content)
            .HasMaxLength(2000);

        SeedData(builder);
    }

    private void SeedData(EntityTypeBuilder<Comment> builder)
    {
        builder.HasData(
            new Comment
            {
                Id = 1,
                Content = "This is a comment on the first topic by user 1.",
                TopicId = 1,
                UserId = 1
            },
            new Comment
            {
                Id = 2,
                Content = "This is another comment on the first topic by user 2.",
                TopicId = 1,
                UserId = 2
            },
            new Comment
            {
                Id = 3,
                Content = "This is a comment on the second topic by user 1.",
                TopicId = 2,
                UserId = 3
            }
        );
    }
}