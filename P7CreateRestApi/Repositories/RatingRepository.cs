using P7CreateRestApi.Converters;
using P7CreateRestApi.Data;
using P7CreateRestApi.Models.Entities;
using P7CreateRestApi.ViewModels;

namespace P7CreateRestApi.Repositories;

public interface IRatingRepository : IDataRepository<RatingEntity>
{
    public Task<List<Rating>> ReadResultAllAsync();
    public Task<Rating?> ReadResultAsync(int id);
}

public class RatingRepository : DataRepository<RatingEntity>, IRatingRepository
{
    public RatingRepository(LocalDbContext context, ILogger<DataRepository<RatingEntity>> logger) : base(context, logger)
    {
        
    }
    
    public async Task<List<Rating>> ReadResultAllAsync()
    {
        var results = await ReadAllAsync();
        return results.Select(s => s.Convert()).ToList();
    }
    
    public async Task<Rating?> ReadResultAsync(int id)
    {
        var result = await ReadAsync(id);
        return result?.Convert();
    }
}