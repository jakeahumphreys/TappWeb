using TappWeb.Data.Users;
using TappWeb.Data.Users.Types;

namespace TappWeb.Services.Users;

public interface IUserService
{
    public Task AddUser(UserRecord user);
    public Task<List<UserRecord>> GetAllUsers();
    public Task<UserRecord> GetByReference(Guid reference);
    public Task RemoveUser(UserRecord user);
}

public sealed class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<List<UserRecord>> GetAllUsers()
    {
        return await _userRepository.GetAll();
    }

    public async Task<UserRecord> GetByReference(Guid reference)
    {
        return await _userRepository.GetByReference(reference);
    }

    public async Task AddUser(UserRecord user)
    {
        await _userRepository.Add(user);
    }

    public async Task RemoveUser(UserRecord user)
    {
        await _userRepository.Remove(user);
    }
}