using System.Collections.Immutable;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using P7CreateRestApi.Models.Entities;

namespace P7CreateRestApi.Data;

public class LocalDbContext : IdentityDbContext<IdentityUser>
{
    public DbSet<BidEntity> Bids { get; set; }
    public DbSet<CurvePointEntity> CurvePoints { get; set; }
    public DbSet<RatingEntity> Ratings { get; set; }
    public DbSet<RuleEntity> Rules { get; set; }
    public DbSet<TradeEntity> Trades { get; set; }
    public DbSet<UserEntity> UserNames { get; set;}
    public LocalDbContext(DbContextOptions<LocalDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
            
        //Bids
        builder.Entity<BidEntity>()
            .Property(p => p.Id)
            .ValueGeneratedOnAdd()
            .IsRequired();
        builder.Entity<BidEntity>()
            .HasKey(p => p.Id);
        builder.Entity<BidEntity>()
            .Property(p => p.Account)
            .HasMaxLength(255)
            .IsRequired();
        builder.Entity<BidEntity>()
            .Property(p => p.BidType)
            .HasMaxLength(255)
            .IsRequired();
        builder.Entity<BidEntity>()
            .Property(p => p.Benchmark)
            .HasMaxLength(255)
            .IsRequired();
        builder.Entity<BidEntity>()
            .Property(p => p.Commentary)
            .HasMaxLength(255)
            .IsRequired();
        builder.Entity<BidEntity>()
            .Property(p => p.BidSecurity)
            .HasMaxLength(255)
            .IsRequired();
        builder.Entity<BidEntity>()
            .Property(p => p.BidStatus)
            .HasMaxLength(255)
            .IsRequired();
        builder.Entity<BidEntity>()
            .Property(p => p.Trader)
            .HasMaxLength(255)
            .IsRequired();
        builder.Entity<BidEntity>()
            .Property(p => p.Book)
            .HasMaxLength(255)
            .IsRequired();
        builder.Entity<BidEntity>()
            .Property(p => p.CreationName)
            .HasMaxLength(255)
            .IsRequired();
        builder.Entity<BidEntity>()
            .Property(p => p.RevisionName)
            .HasMaxLength(255)
            .IsRequired();
        builder.Entity<BidEntity>()
            .Property(p => p.DealName)
            .HasMaxLength(255)
            .IsRequired();
        builder.Entity<BidEntity>()
            .Property(p => p.DealType)
            .HasMaxLength(255)
            .IsRequired();
        builder.Entity<BidEntity>()
            .Property(p => p.SourceListId)
            .HasMaxLength(255)
            .IsRequired();
        builder.Entity<BidEntity>()
            .Property(p => p.Side)
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
        builder.Entity<RatingEntity>()
            .Property(p => p.MoodysRating)
            .HasMaxLength(255)
            .IsRequired();
        builder.Entity<RatingEntity>()
            .Property(p => p.SandPRating)
            .HasMaxLength(255)
            .IsRequired();
        builder.Entity<RatingEntity>()
            .Property(p => p.FitchRating)
            .HasMaxLength(255)
            .IsRequired();
        builder.Entity<RatingEntity>()
            .Property(p => p.OrderNumber)
            .IsRequired(false);
                
        
        //Rules
        builder.Entity<RuleEntity>()
            .Property(p => p.Id)
            .ValueGeneratedOnAdd()
            .IsRequired();
        builder.Entity<RuleEntity>()
            .HasKey(p => p.Id);
        builder.Entity<RuleEntity>()
            .Property(p => p.Name)
            .HasMaxLength(255)
            .IsRequired();
        builder.Entity<RuleEntity>()
            .Property(p => p.Description)
            .HasMaxLength(255)
            .IsRequired();
        builder.Entity<RuleEntity>()
            .Property(p => p.Json)
            .HasMaxLength(10_000)
            .IsRequired();
        builder.Entity<RuleEntity>()
            .Property(p => p.Template)
            .HasMaxLength(10_000)
            .IsRequired();
        builder.Entity<RuleEntity>()
            .Property(p => p.SqlStr)
            .HasMaxLength(10_000)
            .IsRequired();
        builder.Entity<RuleEntity>()
            .Property(p => p.SqlPart)
            .HasMaxLength(10_000)
            .IsRequired();
        
        //Trades
        builder.Entity<TradeEntity>()
            .Property(p => p.Id)
            .ValueGeneratedOnAdd()
            .IsRequired();
        builder.Entity<TradeEntity>()
            .HasKey(p => p.Id);
        builder.Entity<TradeEntity>()
            .Property(p => p.Account)
            .HasMaxLength(255)
            .IsRequired();
        builder.Entity<TradeEntity>()
            .Property(p => p.AccountType)
            .HasMaxLength(255)
            .IsRequired();
        builder.Entity<TradeEntity>()
            .Property(p => p.TradeSecurity)
            .HasMaxLength(255)
            .IsRequired();
        builder.Entity<TradeEntity>()
            .Property(p => p.TradeStatus)
            .HasMaxLength(255)
            .IsRequired();
        builder.Entity<TradeEntity>()
            .Property(p => p.Trader)
            .HasMaxLength(255)
            .IsRequired();  
        builder.Entity<TradeEntity>()
            .Property(p => p.Benchmark)
            .HasMaxLength(255)
            .IsRequired();
        builder.Entity<TradeEntity>()
            .Property(p => p.Book)
            .HasMaxLength(255)
            .IsRequired();
        builder.Entity<TradeEntity>()
            .Property(p => p.CreationName)
            .HasMaxLength(255)
            .IsRequired();
        builder.Entity<TradeEntity>()
            .Property(p => p.RevisionName)
            .HasMaxLength(255)
            .IsRequired();
        builder.Entity<TradeEntity>()
            .Property(p => p.DealName)
            .HasMaxLength(255)
            .IsRequired();
        builder.Entity<TradeEntity>()
            .Property(p => p.DealType)
            .HasMaxLength(255)
            .IsRequired();
        builder.Entity<TradeEntity>()
            .Property(p => p.SourceListId)
            .HasMaxLength(255)
            .IsRequired();
        builder.Entity<TradeEntity>()
            .Property(p => p.Side)
            .HasMaxLength(255)
            .IsRequired();
        
        //Users
        builder.Entity<UserEntity>()
            .Property(p => p.Id)
            .ValueGeneratedOnAdd()
            .IsRequired();
        builder.Entity<UserEntity>()
            .HasKey(p => p.Id);
        builder.Entity<UserEntity>()
            .Property(p => p.UserName)
            .HasMaxLength(255)
            .IsRequired();
        builder.Entity<UserEntity>()
            .HasIndex(p => p.UserName)
            .IsUnique();
            
    }


}