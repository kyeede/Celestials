using Celestials.Core.Entities.Guilds;
using Celestials.Core.Repositories;
using Celestials.Core.Utilities.Paging;
using Microsoft.EntityFrameworkCore;

namespace Celestials.Infrastructure.Persistence.Repositories;

internal sealed class GuildMemberRepository(AppDbContext dbContext) : Repository<GuildMember>(dbContext), IGuildMemberRepository
{
    public async Task<GuildMember?> GetByUserAsync(ulong guildId, ulong userId, CancellationToken cancellationToken = default)
    {
        return await DbSet.FirstOrDefaultAsync(m => m.GuildId == guildId && m.UserId == userId, cancellationToken).ConfigureAwait(false);
    }

    public async Task<bool> IsMemberAsync(ulong guildId, ulong userId, CancellationToken cancellationToken = default)
    {
        return await DbSet
            .AnyAsync(m => m.GuildId == guildId && m.UserId == userId && m.DeletedAt == null, cancellationToken)
            .ConfigureAwait(false);
    }

    public Task<PagedResult<GuildMember>> PageByGuildAsync(
        ulong guildId,
        PageRequest request,
        CancellationToken cancellationToken = default
    )
    {
        ArgumentNullException.ThrowIfNull(request);
        return PageAsync(m => m.GuildId == guildId && m.DeletedAt == null, request, cancellationToken);
    }
}
