using TappWeb.Users.Types;

namespace TappWeb.Users;

public interface IUserService
{
    public void AddUser(UserRecord user);
    public List<UserRecord> GetAllUsers();
}

public sealed class UserService : IUserService
{
    private IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
        AddUser(new UserBuilder()
            .WithUsername("TestMan")
            .WithFirstname("Test")
            .WithLastname("Man")
            .WithEmail("testman@test.com")
            .WithPassword("test123")
            .WithActiveStatus(true)
            .CreateUser());
    }

    public List<UserRecord> GetAllUsers()
    {
        return _userRepository.GetAll();
    }
    
    public void AddUser(UserRecord user)
    {
        _userRepository.Add(user);
    }
}