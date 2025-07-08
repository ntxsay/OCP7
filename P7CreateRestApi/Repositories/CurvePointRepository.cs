using P7CreateRestApi.Data;
using P7CreateRestApi.Models.Entities;

namespace P7CreateRestApi.Repositories;

public interface ICurvePointRepository : IDataRepository<CurvePointEntity>
{
    
}

public class CurvePointRepository : DataRepository<CurvePointEntity>, ICurvePointRepository
{
    public CurvePointRepository(LocalDbContext context) : base(context)
    {
        
    }
}