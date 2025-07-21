using P7CreateRestApi.Converters;
using P7CreateRestApi.Data;
using P7CreateRestApi.Models.Entities;
using P7CreateRestApi.ViewModels;

namespace P7CreateRestApi.Repositories;

public interface ITradeRepository : IDataRepository<TradeEntity>
{
    public Task<List<Trade>> ReadResultAllAsync();
    public Task<Trade?> ReadResultAsync(int id);
}

public class TradeRepository : DataRepository<TradeEntity>, ITradeRepository
{
    public TradeRepository(LocalDbContext context, ILogger<DataRepository<TradeEntity>> logger) : base(context, logger)
    {
        
    }
    
    public async Task<List<Trade>> ReadResultAllAsync()
    {
        var results = await ReadAllAsync();
        return results.Select(s => s.Convert()).ToList();
    }
    
    public async Task<Trade?> ReadResultAsync(int id)
    {
        var result = await ReadAsync(id);
        return result?.Convert();
    }
}