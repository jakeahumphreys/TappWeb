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
    public List<UserRecord> GetAll()
    {
        throw new NotImplementedException();
    }

    public UserRecord GetByReference(Guid reference)
    {
        throw new NotImplementedException();

    }

    public void Add(UserRecord user)
    {
        throw new NotImplementedException();

    }
}