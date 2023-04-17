using TappWeb.Data;
using TappWeb.Users.Types;

namespace TappWeb.Users.Data;

public interface IUserRepository
{
    public List<UserRecord> GetAll();
    public UserRecord GetByReference(Guid reference);
    public void Add(UserRecord user);
}

public sealed class UserRepository : IUserRepository
{
    private readonly TappDbContext _tappDb;

    public UserRepository(TappDbContext tappDb)
    {
        _tappDb = tappDb;
    }
    
    public List<UserRecord> GetAll()
    {
        return _tappDb.Users.ToList();
    }

    public UserRecord GetByReference(Guid reference)
    {
        return _tappDb.Users.SingleOrDefault(x => x.Reference == reference);
    }

    public void Add(UserRecord user)
    {
        _tappDb.Users.Add(user);
        _tappDb.SaveChanges();
    }
}