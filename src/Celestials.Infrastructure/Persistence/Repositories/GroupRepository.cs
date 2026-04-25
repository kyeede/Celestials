using Celestials.Core.Entities.Groups;
using Celestials.Core.Repositories;
using Celestials.Core.Utilities.Paging;
using Microsoft.EntityFrameworkCore;

namespace Celestials.Infrastructure.Persistence.Repositories;

internal sealed class GroupRepository(AppDbContext dbContext) : Repository<Group>(dbContext), IGroupRepository
{
    public async Task<Group?> GetByIdWithDetailsAsync(ulong id, CancellationToken cancellationToken = default)
    {
        return await DbSet
            .Include(g => g.Members)
            .Include(g => g.Roles)
            .FirstOrDefaultAsync(g => g.Id == id, cancellationToken)
            .ConfigureAwait(false);
    }

    public async Task<Group?> GetByNameAsync(ulong guildId, string name, CancellationToken cancellationToken = default)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(name);

        return await DbSet.FirstOrDefaultAsync(g => g.GuildId == guildId && g.Name == name, cancellationToken).ConfigureAwait(false);
    }

    public async Task<bool> ExistsByNameAsync(ulong guildId, string name, CancellationToken cancellationToken = default)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(name);

        return await DbSet
            .AnyAsync(g => g.GuildId == guildId && g.Name == name && g.DeletedAt == null, cancellationToken)
            .ConfigureAwait(false);
    }

    public Task<PagedResult<Group>> PageByGuildAsync(ulong guildId, PageRequest request, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(request);
        return PageAsync(g => g.GuildId == guildId && g.DeletedAt == null, request, cancellationToken);
    }

    public Task<PagedResult<Group>> PageByOwnerAsync(
        ulong guildId,
        ulong ownerId,
        PageRequest request,
        CancellationToken cancellationToken = default
    )
    {
        ArgumentNullException.ThrowIfNull(request);
        return PageAsync(g => g.GuildId == guildId && g.OwnerId == ownerId && g.DeletedAt == null, request, cancellationToken);
    }
}
