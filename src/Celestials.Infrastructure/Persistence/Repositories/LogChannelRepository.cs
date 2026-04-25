using Celestials.Core.Entities.Channels;
using Celestials.Core.Repositories;
using Celestials.Core.Utilities.Paging;
using Microsoft.EntityFrameworkCore;

namespace Celestials.Infrastructure.Persistence.Repositories;

internal sealed class LogChannelRepository(AppDbContext dbContext) : Repository<LogChannel>(dbContext), ILogChannelRepository
{
    public async Task<LogChannel?> GetGlobalAsync(ulong guildId, CancellationToken cancellationToken = default)
    {
        return await DbSet
            .FirstOrDefaultAsync(c => c.GuildId == guildId && c.Scope == ChannelScope.Global, cancellationToken)
            .ConfigureAwait(false);
    }

    public async Task<LogChannel?> GetByGroupAsync(ulong guildId, ulong groupId, CancellationToken cancellationToken = default)
    {
        return await DbSet
            .FirstOrDefaultAsync(c => c.GuildId == guildId && c.GroupId == groupId && c.Scope == ChannelScope.Private, cancellationToken)
            .ConfigureAwait(false);
    }

    public async Task<bool> GlobalExistsAsync(ulong guildId, CancellationToken cancellationToken = default)
    {
        return await DbSet
            .AnyAsync(c => c.GuildId == guildId && c.Scope == ChannelScope.Global && c.DeletedAt == null, cancellationToken)
            .ConfigureAwait(false);
    }

    public async Task<bool> GroupChannelExistsAsync(ulong guildId, ulong groupId, CancellationToken cancellationToken = default)
    {
        return await DbSet
            .AnyAsync(
                c => c.GuildId == guildId && c.GroupId == groupId && c.Scope == ChannelScope.Private && c.DeletedAt == null,
                cancellationToken
            )
            .ConfigureAwait(false);
    }

    public Task<PagedResult<LogChannel>> PageByGuildAsync(ulong guildId, PageRequest request, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(request);
        return PageAsync(c => c.GuildId == guildId && c.DeletedAt == null, request, cancellationToken);
    }
}
