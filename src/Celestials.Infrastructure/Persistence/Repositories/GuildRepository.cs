using Celestials.Core.Entities.Guilds;
using Celestials.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Celestials.Infrastructure.Persistence.Repositories;

internal sealed class GuildRepository(AppDbContext dbContext) : Repository<Guild>(dbContext), IGuildRepository
{
    public async Task<Guild?> GetByGuildIdAsync(ulong guildId, CancellationToken cancellationToken = default)
    {
        return await DbSet.FirstOrDefaultAsync(g => g.Id == guildId, cancellationToken).ConfigureAwait(false);
    }
}
