﻿using TappWeb.Users;
using TappWeb.Users.Types;

namespace TappWeb.Tests.Users.GivenAUsersArePresent;

[TestFixture]
[Parallelizable]
public sealed class WhenGettingAllUsers
{
    private List<UserRecord> _result;

    [OneTimeSetUp]
    public void Setup()
    {
        var subject = new UserService(UserTestHelper.GetTestRepository());
        _result = subject.GetAllUsers();
    }
    
    [Test]
    public void ThenTheExpectedNumberOfUsersIsReturned()
    {
        Assert.That(_result, Has.Count.EqualTo(1));
    }
}