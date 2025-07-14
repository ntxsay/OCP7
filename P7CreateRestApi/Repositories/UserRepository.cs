using Microsoft.EntityFrameworkCore;
using P7CreateRestApi.Data;
using P7CreateRestApi.DataTransferObject;
using P7CreateRestApi.Models.Entities;

namespace P7CreateRestApi.Repositories;

public interface IUserRepository : IDataRepository<UserEntity>
{
    public UserEntity? FindByUserName(string userName);
    public Task<UserEntity?> FindByUserNameAsync(string userName);
}

public class UserRepository : DataRepository<UserEntity>, IUserRepository
{
    public UserRepository(LocalDbContext context, ILogger<DataRepository<UserEntity>> logger) : base(context, logger)
    {
        
    }
    
    public UserEntity? FindByUserName(string userName)
    {
        return DbContext.Users
            .FirstOrDefault(user => user.UserName == userName);
    }

    public async Task<UserEntity?> FindByUserNameAsync(string userName)
    {
        return await DbContext.Users
            .FirstOrDefaultAsync(user => user.UserName == userName);
    }
}