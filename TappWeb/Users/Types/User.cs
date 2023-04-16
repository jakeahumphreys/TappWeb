namespace TappWeb.Users.Types;

public class User
{
    public string Firstname { get; set; }
    public string Lastname { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public List<Permission> Permissions { get; set; }
    public bool IsActive { get; set; }
}