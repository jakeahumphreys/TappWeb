using System.Reflection;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Tool.hbm2ddl;

namespace TappWeb;

public static class DatabaseHandler
{
    public static ISessionFactory CreateSessionFactoryForPostgres(string connectionString)
    {
        var configuration = Fluently.Configure()
            .Database(PostgreSQLConfiguration.PostgreSQL82.ConnectionString(connectionString))
            .Mappings(m => m.FluentMappings.AddFromAssembly(Assembly.GetExecutingAssembly())
                .Conventions.Add(FluentNHibernate.Conventions.Helpers.DefaultLazy.Never()))
            .BuildConfiguration();

        var exporter = new SchemaExport(configuration);
        exporter.Execute(true, true, false);

        return configuration.BuildSessionFactory();
    }
}