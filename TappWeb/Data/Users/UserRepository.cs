using Microsoft.EntityFrameworkCore;
using TappWeb.Data.Users.Types;

namespace TappWeb.Data.Users;

public interface IUserRepository
{
    public Task<List<UserRecord>> GetAll();
    public Task<UserRecord> GetByUsername(string username);
    public Task<UserRecord> GetByReference(Guid reference);
    public Task Add(UserRecord user);
    public Task Remove(UserRecord user);
}

public sealed class UserRepository : IUserRepository
{
    private readonly TappDbContext _tappDb;

    public UserRepository(TappDbContext tappDb)
    {
        _tappDb = tappDb;
    }
    
    public async Task<List<UserRecord>> GetAll()
    {
        return await _tappDb.Users.ToListAsync();
    }

    public async Task<UserRecord> GetByUsername(string username)
    {
        return await _tappDb.Users.SingleOrDefaultAsync(x => x.Username == username);
    }

    public async Task<UserRecord> GetByReference(Guid reference)
    {
        return await _tappDb.Users.SingleOrDefaultAsync(x => x.Reference == reference);
    }

    public async Task Add(UserRecord user)
    {
        await _tappDb.Users.AddAsync(user);
        await _tappDb.SaveChangesAsync();
    }

    public async Task Remove(UserRecord user)
    {
        _tappDb.Users.Remove(user);
        await _tappDb.SaveChangesAsync();
    }
}