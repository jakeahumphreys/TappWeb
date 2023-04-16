using FluentNHibernate.Mapping;

namespace TappWeb.Users.Types;

public abstract class Permission
{
    public int Id { get; set; }
    public string Key { get; set; }
    public bool Value { get; set; }
    public UserRecord User { get; set; }
}

public class PermissionMap : ClassMap<Permission>
{
    public PermissionMap()
    {
        Table("Permissions"); // Set the table name

        Id(x => x.Id).GeneratedBy.Identity(); // Map the Id property as the primary key with a GuidComb generator

        Map(x => x.Key).Not.Nullable(); // Map the Key property as a string column, which is not nullable
        Map(x => x.Value).Not.Nullable(); // Map the Value property as a bool column, which is not nullable

        References(x => x.User) // Map the User property as a reference to a UserRecord object
            .Column("UserId") // Set the foreign key column to "UserId" in the Permissions table
            .LazyLoad(); // Enable lazy loading for the User reference
    }
}
