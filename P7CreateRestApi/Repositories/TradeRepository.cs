using P7CreateRestApi.Data;
using P7CreateRestApi.Models.Entities;

namespace P7CreateRestApi.Repositories;

public interface ITradeRepository : IDataRepository<TradeEntity>
{
    
}

public class TradeRepository : DataRepository<TradeEntity>, ITradeRepository
{
    public TradeRepository(LocalDbContext context, ILogger<DataRepository<TradeEntity>> logger) : base(context, logger)
    {
        
    }
}