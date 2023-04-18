using TappWeb.Data.Users.Types;

namespace TappWeb.Authentication;

public sealed class UserSession
{
    public string Name { get; set; }
    public string Email { get; set; }
    public string Role { get; set; }
}