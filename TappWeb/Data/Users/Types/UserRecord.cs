namespace TappWeb.Data.Users.Types;

public class UserRecord
{
    public int Id { get; set; }
    public Guid Reference { get; set; }
    public string Firstname { get; set; }
    public string Lastname { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }
    public byte[] PasswordSalt { get; set; }
    public byte[] PasswordHash { get; set; }
    public bool IsActive { get; set; }
}