using P7CreateRestApi.Converters;
using P7CreateRestApi.Data;
using P7CreateRestApi.DataTransferObject;
using P7CreateRestApi.Models.Entities;

namespace P7CreateRestApi.Repositories;

public interface ICurvePointRepository : IDataRepository<CurvePointEntity>
{
    public Task<List<CurvePoint>> ReadResultAllAsync();
    public Task<CurvePoint?> ReadResultAsync(int id);
}

public class CurvePointRepository : DataRepository<CurvePointEntity>, ICurvePointRepository
{
    public CurvePointRepository(LocalDbContext context, ILogger<DataRepository<CurvePointEntity>> logger) : base(context, logger)
    {
        
    }
    
    public async Task<List<CurvePoint>> ReadResultAllAsync()
    {
        var results = await ReadAllAsync();
        return results.Select(s => s.Convert()).ToList();
    }
    
    public async Task<CurvePoint?> ReadResultAsync(int id)
    {
        var result = await ReadAsync(id);
        return result?.Convert();
    }
}