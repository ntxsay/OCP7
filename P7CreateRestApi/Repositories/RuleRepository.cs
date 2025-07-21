using System.Data;
using P7CreateRestApi.Converters;
using P7CreateRestApi.Data;
using P7CreateRestApi.Models.Entities;
using P7CreateRestApi.ViewModels;

namespace P7CreateRestApi.Repositories;

public interface IRuleRepository : IDataRepository<RuleEntity>
{
    public Task<List<RuleName>> ReadResultAllAsync();
    public Task<RuleName?> ReadResultAsync(int id);
}

public class RuleRepository : DataRepository<RuleEntity>, IRuleRepository
{
    public RuleRepository(LocalDbContext context, ILogger<DataRepository<RuleEntity>> logger) : base(context, logger)
    {
        
    }
    
    public async Task<List<RuleName>> ReadResultAllAsync()
    {
        var results = await ReadAllAsync();
        return results.Select(s => s.Convert()).ToList();
    }
    
    public async Task<RuleName?> ReadResultAsync(int id)
    {
        var result = await ReadAsync(id);
        return result?.Convert();
    }
}