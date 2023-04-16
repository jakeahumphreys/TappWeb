using TappWeb.Users.Types;

namespace TappWeb.Users;

public interface IUserService
{
    public void AddUser(UserRecord user);
    public List<UserRecord> GetAllUsers();
    public UserRecord GetByReference(Guid reference);
}

public sealed class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public List<UserRecord> GetAllUsers()
    {
        return _userRepository.GetAll();
    }

    public UserRecord GetByReference(Guid reference)
    {
        return _userRepository.GetByReference(reference);
    }

    public void AddUser(UserRecord user)
    {
        _userRepository.Add(user);
    }
}