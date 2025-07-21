using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using P7CreateRestApi.Data;
using P7CreateRestApi.Models.Entities;
using P7CreateRestApi.Repositories;
using P7CreateRestApi.ViewModels;

namespace P7CreateRestApi.Tests;

public class IntegrationTests : IDisposable
{
    private readonly DbContextOptions<LocalDbContext> _options;
    private readonly LocalDbContext _dbContext;
    private readonly ICurvePointRepository _curvePointRepository;
    private readonly IBidRepository _bidRepository;
    
    public IntegrationTests()
    {
        _options = new DbContextOptionsBuilder<LocalDbContext>()
            .UseInMemoryDatabase("findexiumDb")
            .ConfigureWarnings(b => b.Ignore(InMemoryEventId.TransactionIgnoredWarning))
            .Options;

        _dbContext = new LocalDbContext(_options);
        _bidRepository = new BidRepository(_dbContext, 
            new LoggerFactory().CreateLogger<BidRepository>());
        
        _curvePointRepository = new CurvePointRepository(_dbContext,
            new LoggerFactory().CreateLogger<CurvePointRepository>());

        _dbContext.Database.EnsureCreated();
    }


    #region CurvePoint Tests

    [Theory]
    [InlineData(45)]
    public async Task CreateCurvePoint(byte curveId)
    {
        var curvePoint = new CurvePointEntity
        {
            CurveId = curveId,
            AsOfDate = DateTime.UtcNow,
            Term = 1.0,
            CurvePointValue = 0.05,
            CreationDate = DateTime.UtcNow
        };
        
        var isCreated = await _curvePointRepository.CreateAsync(curvePoint);
        Assert.True(isCreated, "Le point de courbe n'a pas été créé avec succès.");
    }
    
    [Fact]
    public async Task ReadCurveList()
    {
        List<CurvePointEntity> curvePoints = new List<CurvePointEntity>();
        foreach (var number in Enumerable.Range(1, 255))
        {
            var curvePoint = new CurvePointEntity
            {
                CurveId = (byte)number,
                AsOfDate = DateTime.UtcNow,
                Term = new Random().NextDouble(),
                CurvePointValue = new Random().NextDouble(),
                CreationDate = DateTime.UtcNow
            };
            
            curvePoints.Add(curvePoint);
        }
        
        var isCreated = await _curvePointRepository.CreateRangeAsync(curvePoints.ToArray());
        Assert.True(isCreated, "Les points de courbe n'ont pas été créés avec succès.");
        
        var bidList = await _curvePointRepository.ReadResultAllAsync();
        Assert.NotEmpty(bidList);
        Assert.IsType<List<CurvePoint>>(bidList);
    }
    
    [Theory]
    [InlineData(45)]
    public async Task UpdateCurvePoint(byte curveId)
    {
        var curvePoint = new CurvePointEntity
        {
            CurveId = curveId,
            AsOfDate = DateTime.UtcNow,
            Term = 1.0,
            CurvePointValue = 0.05,
            CreationDate = DateTime.UtcNow
        };
        
        var isCreated = await _curvePointRepository.CreateAsync(curvePoint);
        Assert.True(isCreated, "Le point de courbe n'a pas été créé avec succès.");
        
        //Mise à jour de valeurs
        curvePoint.CurvePointValue = 0.06;
        curvePoint.CreationDate = DateTime.UtcNow;
        curvePoint.Term = 1.5;
        curvePoint.AsOfDate = DateTime.UtcNow.AddDays(1);
        curvePoint.CurveId = 56;
        
        var isUpdated = await _curvePointRepository.UpdateAsync(curvePoint);
        Assert.True(isUpdated, "Le point de courbe n'a pas été mis à jour avec succès.");
    }
    
    [Theory]
    [InlineData(45)]
    public async Task DeleteCurvePoint(byte curveId)
    {
        var curvePoint = new CurvePointEntity
        {
            CurveId = curveId,
            AsOfDate = DateTime.UtcNow,
            Term = 1.0,
            CurvePointValue = 0.05,
            CreationDate = DateTime.UtcNow
        };
        
        var isCreated = await _curvePointRepository.CreateAsync(curvePoint);
        Assert.True(isCreated, "Le point de courbe n'a pas été créé avec succès.");
        
        var isDeleted = await _curvePointRepository.DeleteAsync(curvePoint);
        Assert.True(isDeleted, "Le point de courbe n'a pas été suprimé avec succès.");
    }

    #endregion

    #region BidList Tests

    [Theory]
    [InlineData("A-546", "Achat")]
    public async Task CreateBidList(string account, string bidType)
    {
        var bidList = new BidEntity
        {
            Account = account,
            BidType = bidType,
            BidQuantity = 100,
            AskQuantity = null,
            CreationDate = DateTime.UtcNow
        };
        
        var isCreated = await _bidRepository.CreateAsync(bidList);
        Assert.True(isCreated, "La liste d'enchères n'a pas été créée avec succès.");
    }
    
    [Fact]
    public async Task ReadBidList()
    {
        List<BidEntity> bidLists = new List<BidEntity>();
        foreach (var number in Enumerable.Range(1, 255))
        {
            var bidList = new BidEntity
            {
                Account = $"A-{number}",
                BidType = "Achat",
                BidQuantity = new Random().Next(1, 1000),
                AskQuantity = null,
                CreationDate = DateTime.UtcNow
            };
            
            bidLists.Add(bidList);
        }
        
        var isCreated = await _bidRepository.CreateRangeAsync(bidLists.ToArray());
        Assert.True(isCreated, "Les listes d'enchères n'ont pas été créées avec succès.");
        
        var list = await _bidRepository.ReadResultAllAsync();
        Assert.NotEmpty(list);
        Assert.IsType<List<BidList>>(list);
    }
    
    [Theory]
    [InlineData("A-546", "Achat")]
    public async Task UpdateBidList(string account, string bidType)
    {
        var bidList = new BidEntity
        {
            Account = account,
            BidType = bidType,
            BidQuantity = 100,
            AskQuantity = null,
            CreationDate = DateTime.UtcNow
        };
        
        var isCreated = await _bidRepository.CreateAsync(bidList);
        Assert.True(isCreated, "La liste d'enchères n'a pas été créée avec succès.");
        
        // Mise à jour de valeurs
        bidList.BidQuantity = 150;
        bidList.AskQuantity = 200;
        bidList.CreationDate = DateTime.UtcNow.AddDays(1);
        
        var isUpdated = await _bidRepository.UpdateAsync(bidList);
        Assert.True(isUpdated, "La liste d'enchères n'a pas été mise à jour avec succès.");
    }
    
    [Theory]
    [InlineData("A-546", "Achat")]
    public async Task DeleteBidList(string account, string bidType)
    {
        var bidList = new BidEntity
        {
            Account = account,
            BidType = bidType,
            BidQuantity = 100,
            AskQuantity = null,
            CreationDate = DateTime.UtcNow
        };
        
        var isCreated = await _bidRepository.CreateAsync(bidList);
        Assert.True(isCreated, "La liste d'enchères n'a pas été créée avec succès.");
        
        var isDeleted = await _bidRepository.DeleteAsync(bidList);
        Assert.True(isDeleted, "La liste d'enchères n'a pas été suprimée avec succès.");
    }

    #endregion

    public void Dispose()
    {
        _dbContext.Database.EnsureDeleted();
        _dbContext.Dispose();
    }
}