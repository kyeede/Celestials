using Celestials.Infrastructure.Persistence;
using DotNetEnv;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Celestials.Infrastructure.Design;

public sealed class MySqlDbFactory : IDesignTimeDbContextFactory<MySqlDbContext>
{
    public MySqlDbContext CreateDbContext(string[] args)
    {
        Env.Load();

        var connectionString = Environment.GetEnvironmentVariable("DB_CONNECTION");

        var optionsBuilder = new DbContextOptionsBuilder<MySqlDbContext>();
        optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));

        return new MySqlDbContext(optionsBuilder.Options);
    }
}
