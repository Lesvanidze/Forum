using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace Forum.Application.Common.Services.DatabaseService
{
    public interface IDatabaseService
    {
        DatabaseFacade Database { get; }
        public DbSet<Topic> Topics { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Ban> Bans { get; set; }

        public Task<int> SaveChangesAsync(CancellationToken cancellationToken);

        void Migrate();
    }
}
