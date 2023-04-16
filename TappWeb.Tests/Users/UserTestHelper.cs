using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities.Interfaces;
using Moq;
using TappWeb.Users;
using TappWeb.Users.Types;

namespace TappWeb.Tests.Users;

public static class UserTestHelper
{
    public static IUserRepository GetTestRepository()
    {
        var testUser = new UserBuilder()
            .WithReference(Guid.Parse("5d9ce4f8-9d57-43ca-8d81-6d518617f7dc"))
            .WithUsername("TestMan")
            .WithFirstname("Test")
            .WithLastname("Man")
            .WithEmail("testman@test.com")
            .WithPassword("test123")
            .WithActiveStatus(true)
            .CreateUser();
        
        var userRepository = new Mock<IUserRepository>();
        userRepository.Setup(x => x.GetAll())
            .Returns(new List<UserRecord>(1)
            {
                testUser
            });

        userRepository.Setup(x => x.GetByReference(It.Is<Guid>(y => y == Guid.Parse("5d9ce4f8-9d57-43ca-8d81-6d518617f7dc"))))
            .Returns(testUser);

        return userRepository.Object;
    }
}