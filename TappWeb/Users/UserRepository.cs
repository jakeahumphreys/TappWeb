using System.Data;
using TappWeb.Users.Types;
using ISession = NHibernate.ISession;

namespace TappWeb.Users;

public interface IUserRepository
{
    public List<UserRecord> GetAll();
    public UserRecord GetByReference(Guid reference);
    public void Add(UserRecord user);
}

public sealed class UserRepository : IUserRepository
{
    private readonly ISession _session;

    public UserRepository(ISession session)
    {
        _session = session;
    }

    public List<UserRecord> GetAll()
    {
        var users = new List<UserRecord>();
        using (var transaction = _session.BeginTransaction(IsolationLevel.ReadCommitted))
        {
            users = _session.QueryOver<UserRecord>().List().ToList();
        }

        return users;
    }

    public UserRecord GetByReference(Guid reference)
    {
        using (var transaction = _session.BeginTransaction(IsolationLevel.ReadCommitted))
        {
            return _session.Query<UserRecord>().SingleOrDefault(x => x.Reference == reference);
        }
    }

    public void Add(UserRecord user)
    {
        using (var transaction = _session.BeginTransaction(IsolationLevel.ReadCommitted))
        {
            _session.Save(user);
            transaction.Commit();
        }
    }
}