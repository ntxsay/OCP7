using P7CreateRestApi.Data;
using P7CreateRestApi.Models.Entities;

namespace P7CreateRestApi.Repositories;

public interface IRuleRepository : IDataRepository<RuleEntity>
{
    
}

public class RuleRepository : DataRepository<RuleEntity>, IRuleRepository
{
    public RuleRepository(LocalDbContext context) : base(context)
    {
        
    }
}