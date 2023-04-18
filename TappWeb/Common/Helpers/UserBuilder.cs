using TappWeb.Data.Users.Types;

namespace TappWeb.Common.Helpers;

public interface IUserBuilder
{
    public UserBuilder WithReference(Guid reference);
    public UserBuilder WithUsername(string username);
    public UserBuilder WithFirstname(string firstname);
    public UserBuilder WithLastname(string lastname);
    public UserBuilder WithEmail(string email);
    public UserBuilder WithPassword(string password);
    public UserBuilder WithActiveStatus(bool isActive);
    public UserRecord CreateUser();
}

public class UserBuilder : IUserBuilder
{
    private readonly UserRecord _userRecord;

    public UserBuilder()
    {
        _userRecord = new UserRecord();
    }

    public UserBuilder WithReference(Guid reference)
    {
        _userRecord.Reference = reference;
        return this;
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
    
    public UserRecord CreateUser()
    {
        return _userRecord;
    }
}