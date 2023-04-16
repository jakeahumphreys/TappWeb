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
    public UserRecord CreateUser();
}

public class UserBuilder : IUserBuilder
{
    private readonly UserRecord _userRecord;

    public UserBuilder()
    {
        _userRecord = new UserRecord();
        _userRecord.Id = Guid.NewGuid();
    }

    public UserBuilder WithUsername(string username)
    {
        _userRecord.Username = username;
        return this;
    }

    public UserBuilder WithFirstname(string firstname)
    {
        _userRecord.Firstname = firstname;
        return this;
    }

    public UserBuilder WithLastname(string lastname)
    {
        _userRecord.Lastname = lastname;
        return this;
    }

    public UserBuilder WithEmail(string email)
    {
        _userRecord.Email = email;
        return this;
    }

    public UserBuilder WithPassword(string password)
    {
        _userRecord.Password = password;
        return this;
    }

    public UserBuilder WithActiveStatus(bool isActive)
    {
        _userRecord.IsActive = isActive;
        return this;
    }

    public UserBuilder WithPermissions(List<Permission> permissions)
    {
        _userRecord.Permissions = permissions;
        return this;
    }


    public UserRecord CreateUser()
    {
        return _userRecord;
    }
}