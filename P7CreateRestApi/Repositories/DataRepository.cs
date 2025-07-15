using Microsoft.EntityFrameworkCore;
using P7CreateRestApi.Data;

namespace P7CreateRestApi.Repositories;

public interface IDataRepository<T> where T : class
{
    public Task<bool> CreateAsync(T item);
    public Task<bool> CreateRangeAsync(params T[] model);
    public Task<List<T>> ReadAllAsync();
    public Task<T?> ReadAsync(int id);
    public Task<bool> UpdateAsync(T item);
    public Task<bool> DeleteAsync(int id);
    public Task<bool> DeleteAsync(T item);
}

public abstract class DataRepository<T> : IDataRepository<T> where T : class
{
    protected readonly LocalDbContext DbContext;
    protected readonly ILogger<DataRepository<T>> Logger;

    protected DataRepository(LocalDbContext dbContext, ILogger<DataRepository<T>> logger)
    {
        DbContext = dbContext;
        Logger = logger;
    }

    public async Task<bool> CreateAsync(T model)
    {
        try
        {
            await DbContext.Set<T>().AddAsync(model);
            await DbContext.SaveChangesAsync();
        }
        catch (Exception e)
        {
            Logger.LogError(e, "Erreur lors de la création de l'entité de type « {Name} » : {Message}", typeof(T).Name, e.Message);
            return false;
        }
        
        Logger.LogInformation("L'entité de type « {Name} » a été créée avec succès.", typeof(T).Name);
        return true;
    }
    
    public async Task<bool> CreateRangeAsync(params T[] model)
    {
        try
        {
            await DbContext.Set<T>().AddRangeAsync(model);
            await DbContext.SaveChangesAsync();
        }
        catch (Exception e)
        {
            Logger.LogError(e, "Erreur lors de la création de l'entité de type « {Name} » : {Message}", typeof(T).Name, e.Message);
            return false;
        }
        
        Logger.LogInformation("L'entité de type « {Name} » a été créée avec succès.", typeof(T).Name);
        return true;
    }

    public async Task<List<T>> ReadAllAsync()
    {
        return await DbContext.Set<T>().ToListAsync();
    }
    
    public async Task<T?> ReadAsync(int id)
    {
        var result = await DbContext.Set<T>().FindAsync(id);
        if (result == null) 
            Logger.LogWarning("L'entité de type « {Name} » avec l'id « {Id} » n'existe pas.", typeof(T).Name, id);
        
        return result;
    }

    public async Task<bool> UpdateAsync(T model)
    {
        try
        {
            DbContext.Set<T>().Update(model);
            await DbContext.SaveChangesAsync();
            Logger.LogInformation("L'entité de type « {Name} » a été mise à jour avec succès.", typeof(T).Name);
        }
        catch (Exception e)
        {
            Logger.LogError(e, "Erreur lors de la mise à jour de l'entité de type « {Name} » : {Message}", typeof(T).Name, e.Message);
            return false;
        }
        
        return true;
    }
    
    public async Task<bool> DeleteAsync(int id)
    {
        var entity = await ReadAsync(id);
        if (entity == null)
        {
            Logger.LogWarning("Impossible de supprimer l'entité de type « {Name} » avec l'id « {Id} » car elle n'existe pas.", typeof(T).Name, id);
            return false;
        }
        
        return await DeleteAsync(entity);
    }
    
    public async Task<bool> DeleteAsync(T entity)
    {
        try
        {
            DbContext.Set<T>().Remove(entity);
            await DbContext.SaveChangesAsync();
            Logger.LogInformation("L'entité de type « {Name} » a été supprimée avec succès.", typeof(T).Name);
        }
        catch (Exception e)
        {
            Logger.LogError(e, "Erreur lors de la suppression de l'entité de type « {Name} » : {Message}", typeof(T).Name, e.Message);
            return false;
        }
        
        return true;
    }
}