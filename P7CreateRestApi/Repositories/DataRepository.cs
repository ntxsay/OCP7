using P7CreateRestApi.Data;

namespace P7CreateRestApi.Repositories;

public interface IDataRepository<T> where T : class
{
    public Task CreateAsync(T item);
    public Task<T?> ReadAsync(int id);
    public Task UpdateAsync(T item);
    public Task DeleteAsync(T item);
}

public abstract class DataRepository<T> : IDataRepository<T> where T : class
{
    private readonly LocalDbContext _dbContext;
    
    public DataRepository(LocalDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task CreateAsync(T model)
    {
        await _dbContext.Set<T>().AddAsync(model);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<T?> ReadAsync(int id)
    {
        return await _dbContext.Set<T>().FindAsync(id);
    }

    public async Task UpdateAsync(T model)
    {
        _dbContext.Set<T>().Update(model);
        await _dbContext.SaveChangesAsync();
    }
    
    public async Task DeleteAsync(T entity)
    {
        _dbContext.Set<T>().Remove(entity);
        await _dbContext.SaveChangesAsync();
    }
}