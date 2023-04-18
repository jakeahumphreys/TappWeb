using Moq;
using TappWeb.Common.Helpers;
using TappWeb.Data.Users;
using TappWeb.Data.Users.Types;

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
            .WithActiveStatus(true)
            .CreateUser();
        
        var userRepository = new Mock<IUserRepository>();
        userRepository.Setup(x => x.GetAll())
            .ReturnsAsync(new List<UserRecord>(1)
            {
                testUser
            });

        userRepository.Setup(x => x.GetByReference(It.Is<Guid>(y => y == Guid.Parse("5d9ce4f8-9d57-43ca-8d81-6d518617f7dc"))))
            .ReturnsAsync(testUser);

        return userRepository.Object;
    }
}