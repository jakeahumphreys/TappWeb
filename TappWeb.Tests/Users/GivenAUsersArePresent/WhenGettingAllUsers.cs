using TappWeb.Users;
using TappWeb.Users.Types;

namespace TappWeb.Tests.Users.GivenAUsersArePresent;

[TestFixture]
[Parallelizable]
public sealed class WhenGettingAllUsers
{
    private List<UserRecord> _result;

    [OneTimeSetUp]
    public async Task Setup()
    {
        var subject = new UserService(UserTestHelper.GetTestRepository());
        _result = await subject.GetAllUsers();
    }
    
    [Test]
    public void ThenTheExpectedNumberOfUsersIsReturned()
    {
        Assert.That(_result, Has.Count.EqualTo(1));
    }
}