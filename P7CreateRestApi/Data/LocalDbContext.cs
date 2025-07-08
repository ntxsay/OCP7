using Microsoft.EntityFrameworkCore;
using P7CreateRestApi.Domain;

namespace P7CreateRestApi.Data
{
    public class LocalDbContext : DbContext
    {
        public LocalDbContext(DbContextOptions<LocalDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

        public DbSet<User> Users { get; set;}
    }
}