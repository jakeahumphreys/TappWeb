using TappWeb.Users.Types;

namespace TappWeb.Users;

public interface IUserRepository
{
    public List<UserRecord> GetAll();
    public UserRecord GetByReference(Guid reference);
    public void Add(UserRecord user);
}

public sealed class UserRepository : IUserRepository
{
    private List<UserRecord> _users;

    public UserRepository()
    {
       _users = new List<UserRecord>();
    }

    public List<UserRecord> GetAll()
    {
        return _users;
    }

    public UserRecord GetByReference(Guid reference)
    {
        return _users.SingleOrDefault(x => x.Reference == reference);
    }

    public void Add(UserRecord user)
    {
        _users.Add(user);
    }
}