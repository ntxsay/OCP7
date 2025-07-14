using Microsoft.EntityFrameworkCore;
using P7CreateRestApi.Converters;
using P7CreateRestApi.Data;
using P7CreateRestApi.DataTransferObject;
using P7CreateRestApi.Models.Entities;

namespace P7CreateRestApi.Repositories;

public interface IUserRepository : IDataRepository<UserEntity>
{
    public UserEntity? FindByUserName(string userName);
    public Task<UserEntity?> FindByUserNameAsync(string userName);
    public User? FindResultByUserName(string userName);
    public Task<User?> FindResultByUserNameAsync(string userName);
    public Task<List<User>> ReadResultAllAsync();
    public Task<User?> ReadResultAsync(int id);
}

public class UserRepository : DataRepository<UserEntity>, IUserRepository
{
    public UserRepository(LocalDbContext context, ILogger<DataRepository<UserEntity>> logger) : base(context, logger)
    {
        
    }
    
    public UserEntity? FindByUserName(string userName)
    {
        var result= DbContext.Users
            .FirstOrDefault(user => user.UserName == userName);
        if (result == null)
        {
            Logger.LogWarning($"L'utilisateur avec le nom '{userName}' n'a pas été trouvé.");
            return null;
        }
        
        return result;
    }

    public async Task<UserEntity?> FindByUserNameAsync(string userName)
    {
        var result = await DbContext.Users
            .FirstOrDefaultAsync(user => user.UserName == userName);
        if (result == null)
        {
            Logger.LogWarning($"L'utilisateur avec le nom '{userName}' n'a pas été trouvé.");
            return null;
        }
        
        return result;
    }
    
    public User? FindResultByUserName(string userName)
    {
        var user = FindByUserName(userName);
        return user?.Convert();
    }

    public async Task<User?> FindResultByUserNameAsync(string userName)
    {
        var user = await FindByUserNameAsync(userName);
        return user?.Convert();
    }
    
    public async Task<List<User>> ReadResultAllAsync()
    {
        var results = await ReadAllAsync();
        return results.Select(s => s.Convert()).ToList();
    }
    
    public async Task<User?> ReadResultAsync(int id)
    {
        var result = await ReadAsync(id);
        return result?.Convert();
    }

}