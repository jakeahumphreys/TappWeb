namespace TappWeb.Users.Types;

public abstract class Permission
{
    public string Id { get; set; }
    public string Key { get; set; }
    public bool Value { get; set; }
}