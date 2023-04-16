using FluentNHibernate.Mapping;

namespace TappWeb.Users.Types;

public class UserRecord
{
    public int Id { get; set; }
    public Guid Reference { get; set; }
    public string Firstname { get; set; }
    public string Lastname { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public List<Permission> Permissions { get; set; }
    public bool IsActive { get; set; }
}

public class UserRecordMap : ClassMap<UserRecord>
{
    public UserRecordMap()
    {
        Table("UserRecords"); // Set the table name

        Id(x => x.Id).GeneratedBy.Identity(); // Map the Id property as the primary key with an auto-generated identity value

        Map(x => x.Reference).Not.Nullable(); // Map the Reference property as a Guid column, which is not nullable
        Map(x => x.Firstname).Not.Nullable(); // Map the Firstname property as a string column, which is not nullable
        Map(x => x.Lastname).Not.Nullable(); // Map the Lastname property as a string column, which is not nullable
        Map(x => x.Username).Not.Nullable(); // Map the Username property as a string column, which is not nullable
        Map(x => x.Email).Not.Nullable(); // Map the Email property as a string column, which is not nullable
        Map(x => x.Password).Not.Nullable(); // Map the Password property as a string column, which is not nullable
        Map(x => x.IsActive).Not.Nullable(); // Map the IsActive property as a bool column, which is not nullable

        HasMany(x => x.Permissions) // Map the Permissions property as a collection of Permission objects
            .Cascade.AllDeleteOrphan() // Cascade delete-orphan for associated Permission objects
            .Inverse() // Use inverse mapping to optimize performance
            .LazyLoad() // Enable lazy loading for the Permissions collection
            .KeyColumn("UserId"); // Set the foreign key column to "UserId" in the Permission table
    }
}