using Microsoft.EntityFrameworkCore;
using TappWeb.Data.Users.Types;

namespace TappWeb.Data;

public class TappDbContext : DbContext
{
    private readonly IConfiguration _configuration;

    public DbSet<UserRecord> Users { get; set; }

    public TappDbContext(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options) => options.UseNpgsql(_configuration.GetConnectionString("postgres"));
}