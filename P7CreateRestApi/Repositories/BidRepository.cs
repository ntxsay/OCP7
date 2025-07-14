using P7CreateRestApi.Data;
using P7CreateRestApi.Models.Entities;

namespace P7CreateRestApi.Repositories;

public interface IBidRepository : IDataRepository<BidEntity>
{
    
}

public class BidRepository : DataRepository<BidEntity>, IBidRepository
{
    public BidRepository(LocalDbContext context, ILogger<DataRepository<BidEntity>> logger) : base(context, logger)
    {
        
    }
}