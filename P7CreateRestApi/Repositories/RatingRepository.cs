using P7CreateRestApi.Data;
using P7CreateRestApi.Models.Entities;

namespace P7CreateRestApi.Repositories;

public interface IRatingRepository : IDataRepository<RatingEntity>
{
    
}

public class RatingRepository : DataRepository<RatingEntity>, IRatingRepository
{
    public RatingRepository(LocalDbContext context, ILogger<DataRepository<RatingEntity>> logger) : base(context, logger)
    {
        
    }
}