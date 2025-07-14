using System.Collections.Immutable;
using Microsoft.EntityFrameworkCore;
using P7CreateRestApi.DataTransferObject;
using P7CreateRestApi.Models.Entities;

namespace P7CreateRestApi.Data;

public class LocalDbContext : DbContext
{
    public DbSet<BidEntity> Bids { get; set; }
    public DbSet<CurvePointEntity> CurvePoints { get; set; }
    public DbSet<RatingEntity> Ratings { get; set; }
    public DbSet<RuleEntity> Rules { get; set; }
    public DbSet<TradeEntity> Trades { get; set; }
    public DbSet<UserEntity> Users { get; set;}
    public LocalDbContext(DbContextOptions<LocalDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
            
        //Bids
        builder.Entity<BidEntity>()
            .Property(p => p.BidListId)
            .ValueGeneratedOnAdd()
            .IsRequired();
        builder.Entity<BidEntity>()
            .HasKey(p => p.BidListId);
        builder.Entity<BidEntity>()
            .Property(p => p.Account)
            .HasMaxLength(255)
            .IsRequired();
        builder.Entity<BidEntity>()
            .Property(p => p.BidType)
            .HasMaxLength(255)
            .IsRequired();
            
        //CurvePoint
        builder.Entity<CurvePointEntity>()
            .Property(p => p.Id)
            .ValueGeneratedOnAdd()
            .IsRequired();
        builder.Entity<CurvePointEntity>()
            .HasKey(p => p.Id);
        builder.Entity<CurvePointEntity>()
            .Property(p => p.CurveId)
            .IsRequired();
            
        //Ratings
        builder.Entity<RatingEntity>()
            .Property(p => p.Id)
            .ValueGeneratedOnAdd()
            .IsRequired();
        builder.Entity<RatingEntity>()
            .HasKey(p => p.Id);
                
            
    }


}