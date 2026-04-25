using Celestials.Core.Entities.Groups;
using Celestials.Core.Repositories;
using Celestials.Core.Utilities.Paging;
using Microsoft.EntityFrameworkCore;

namespace Celestials.Infrastructure.Persistence.Repositories;

internal sealed class GroupRoleRepository(AppDbContext dbContext) : Repository<GroupRole>(dbContext), IGroupRoleRepository
{
    public async Task<GroupRole?> GetByRoleAsync(ulong groupId, ulong roleId, CancellationToken cancellationToken = default)
    {
        return await DbSet.FirstOrDefaultAsync(r => r.GroupId == groupId && r.RoleId == roleId, cancellationToken).ConfigureAwait(false);
    }

    public async Task<bool> IsAssignedAsync(ulong groupId, ulong roleId, CancellationToken cancellationToken = default)
    {
        return await DbSet.AnyAsync(r => r.GroupId == groupId && r.RoleId == roleId, cancellationToken).ConfigureAwait(false);
    }

    public Task<PagedResult<GroupRole>> PageByGroupAsync(ulong groupId, PageRequest request, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(request);
        return PageAsync(r => r.GroupId == groupId, request, cancellationToken);
    }
}
