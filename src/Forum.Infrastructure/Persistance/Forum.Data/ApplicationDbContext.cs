using Domain.Entities;
using Forum.Application.Common.Services.DatabaseService;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System.Reflection;

namespace Forum.Infrastructure.Persistance.Forum.Data
{
    public class ApplicationDbContext : DbContext, IDatabaseService
    {
        public DbSet<Topic> Topics { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Ban> Bans { get; set; }

        public ApplicationDbContext()
            : base(new DbContextOptionsBuilder<ApplicationDbContext>().UseSqlServer("SQL").Options) { }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> optionsBuilder)
            : base(optionsBuilder) { }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("dbo");

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        }
        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return await base.SaveChangesAsync(cancellationToken);
        }
        public void Migrate()
        {
            Database.Migrate();
        }
    }
}

