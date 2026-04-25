using Microsoft.EntityFrameworkCore;

namespace Celestials.Infrastructure.Persistence;

public sealed class MySqlDbContext : AppDbContext
{
    public MySqlDbContext(DbContextOptions<MySqlDbContext> options)
        : base(options) { }
}
