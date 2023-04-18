using TappWeb.Data.Users.Types;
using TappWeb.Services.Users;
using TappWeb.Users;

namespace TappWeb.Tests.Users.GivenAUsersArePresent;

[TestFixture]
[Parallelizable]
public sealed class WhenGettingASingleUser
{
    private UserRecord _result;

    [OneTimeSetUp]
    public async Task Setup()
    {
        var subject = new UserService(UserTestHelper.GetTestRepository());
        _result = await subject.GetByReference(Guid.Parse("5d9ce4f8-9d57-43ca-8d81-6d518617f7dc"));
    }
    
    [Test]
    public void ThenTheExpectedUserIsReturned()
    {
        Assert.Multiple((() =>
        {
            Assert.That(_result.Firstname, Is.EqualTo("Test"));
            Assert.That(_result.Lastname, Is.EqualTo("Man"));
            Assert.That(_result.Email, Is.EqualTo("testman@test.com"));
            Assert.That(_result.Reference, Is.EqualTo(Guid.Parse("5d9ce4f8-9d57-43ca-8d81-6d518617f7dc")));
            Assert.That(_result.Password, Is.EqualTo("test123"));
            Assert.That(_result.IsActive, Is.True);
        }));
    }
}