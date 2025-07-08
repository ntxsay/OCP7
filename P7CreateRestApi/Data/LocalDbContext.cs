using Microsoft.EntityFrameworkCore;
using P7CreateRestApi.Domain;
using P7CreateRestApi.Models.Entities;

namespace P7CreateRestApi.Data
{
    public class LocalDbContext : DbContext
    {
        public DbSet<BidEntity> Bids { get; set; }
        public LocalDbContext(DbContextOptions<LocalDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

        public DbSet<User> Users { get; set;}
    }
}