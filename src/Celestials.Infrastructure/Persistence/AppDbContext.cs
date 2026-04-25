using Celestials.Core.Entities.Channels;
using Celestials.Core.Entities.Groups;
using Celestials.Core.Entities.Guilds;
using Celestials.Core.Entities.Permissions;
using Microsoft.EntityFrameworkCore;

namespace Celestials.Infrastructure.Persistence;

public abstract class AppDbContext : DbContext
{
    protected AppDbContext(DbContextOptions options)
        : base(options) { }

    public DbSet<Group> Groups => Set<Group>();
    public DbSet<GroupMember> GroupMembers => Set<GroupMember>();
    public DbSet<GroupRole> GroupRoles => Set<GroupRole>();

    public DbSet<Guild> Guilds => Set<Guild>();
    public DbSet<GuildMember> GuildMembers => Set<GuildMember>();

    public DbSet<LogChannel> LogChannels => Set<LogChannel>();

    public DbSet<PermissionOverwrite> PermissionOverwrites => Set<PermissionOverwrite>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        ArgumentNullException.ThrowIfNull(modelBuilder);

        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
    }
}
