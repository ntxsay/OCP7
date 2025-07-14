using P7CreateRestApi.Converters;
using P7CreateRestApi.Data;
using P7CreateRestApi.DataTransferObject;
using P7CreateRestApi.Models.Entities;

namespace P7CreateRestApi.Repositories;

public interface IBidRepository : IDataRepository<BidEntity>
{
    public Task<List<BidList>> ReadResultAllAsync();
    public Task<BidList?> ReadResultAsync(int id);
}

public class BidRepository : DataRepository<BidEntity>, IBidRepository
{
    public BidRepository(LocalDbContext context, ILogger<DataRepository<BidEntity>> logger) : base(context, logger)
    {
        
    }
    
    public async Task<List<BidList>> ReadResultAllAsync()
    {
        var results = await ReadAllAsync();
        return results.Select(s => s.Convert()).ToList();
    }
    
    public async Task<BidList?> ReadResultAsync(int id)
    {
        var result = await ReadAsync(id);
        return result?.Convert();
    }
}