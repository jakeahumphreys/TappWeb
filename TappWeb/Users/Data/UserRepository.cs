﻿using Microsoft.EntityFrameworkCore;
using TappWeb.Data;
using TappWeb.Users.Types;

namespace TappWeb.Users.Data;

public interface IUserRepository
{
    public Task<List<UserRecord>> GetAll();
    public Task<UserRecord> GetByReference(Guid reference);
    public Task Add(UserRecord user);
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

    public async Task<UserRecord> GetByReference(Guid reference)
    {
        return await _tappDb.Users.SingleOrDefaultAsync(x => x.Reference == reference);
    }

    public async Task Add(UserRecord user)
    {
        await _tappDb.Users.AddAsync(user);
        await _tappDb.SaveChangesAsync();
    }
}