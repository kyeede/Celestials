using Celestials.Core.Entities.Permissions;
using Celestials.Core.Repositories;
using Celestials.Core.Utilities.Paging;
using Microsoft.EntityFrameworkCore;

namespace Celestials.Infrastructure.Persistence.Repositories;

internal sealed class PermissionOverwriteRepository(AppDbContext dbContext)
    : Repository<PermissionOverwrite>(dbContext),
        IPermissionOverwriteRepository
{
    public async Task<PermissionOverwrite?> GetByTargetAsync(
        ulong guildId,
        ulong groupId,
        PermissionScope scope,
        CancellationToken cancellationToken = default
    )
    {
        return await DbSet
            .FirstOrDefaultAsync(o => o.GuildId == guildId && o.GroupId == groupId && o.Scope == scope, cancellationToken)
            .ConfigureAwait(false);
    }

    public async Task<bool> ExistsByTargetAsync(
        ulong guildId,
        ulong groupId,
        PermissionScope scope,
        CancellationToken cancellationToken = default
    )
    {
        return await DbSet
            .AnyAsync(o => o.GuildId == guildId && o.GroupId == groupId && o.Scope == scope && o.DeletedAt == null, cancellationToken)
            .ConfigureAwait(false);
    }

    public Task<PagedResult<PermissionOverwrite>> PageByGroupAsync(
        ulong guildId,
        ulong groupId,
        PageRequest request,
        CancellationToken cancellationToken = default
    )
    {
        ArgumentNullException.ThrowIfNull(request);
        return PageAsync(o => o.GuildId == guildId && o.GroupId == groupId && o.DeletedAt == null, request, cancellationToken);
    }
}
