using TappWeb.Users.Types;

namespace TappWeb.Users;

public interface IUserBuilder
{
    public UserBuilder WithUsername(string username);
    public UserBuilder WithFirstname(string firstname);
    public UserBuilder WithLastname(string lastname);
    public UserBuilder WithEmail(string email);
    public UserBuilder WithPassword(string password);
    public UserBuilder WithActiveStatus(bool isActive);
    public UserBuilder WithPermissions(List<Permission> permissions);
    public User CreateUser();
}

public class UserBuilder : IUserBuilder
{
    private readonly User _user;

    public UserBuilder()
    {
        _user = new User();
    }

    public UserBuilder WithUsername(string username)
    {
        _user.Username = username;
        return this;
    }

    public UserBuilder WithFirstname(string firstname)
    {
        _user.Firstname = firstname;
        return this;
    }

    public UserBuilder WithLastname(string lastname)
    {
        _user.Lastname = lastname;
        return this;
    }

    public UserBuilder WithEmail(string email)
    {
        _user.Email = email;
        return this;
    }

    public UserBuilder WithPassword(string password)
    {
        _user.Password = password;
        return this;
    }

    public UserBuilder WithActiveStatus(bool isActive)
    {
        _user.IsActive = isActive;
        return this;
    }

    public UserBuilder WithPermissions(List<Permission> permissions)
    {
        _user.Permissions = permissions;
        return this;
    }


    public User CreateUser()
    {
        return _user;
    }
}