using Celestials.Core.Entities.Groups;
using Celestials.Core.Repositories;
using Celestials.Core.Utilities.Paging;
using Microsoft.EntityFrameworkCore;

namespace Celestials.Infrastructure.Persistence.Repositories;

internal sealed class GroupMemberRepository(AppDbContext dbContext) : Repository<GroupMember>(dbContext), IGroupMemberRepository
{
    public async Task<GroupMember?> GetByUserAsync(ulong groupId, ulong userId, CancellationToken cancellationToken = default)
    {
        return await DbSet.FirstOrDefaultAsync(m => m.GroupId == groupId && m.UserId == userId, cancellationToken).ConfigureAwait(false);
    }

    public async Task<bool> IsMemberAsync(ulong groupId, ulong userId, CancellationToken cancellationToken = default)
    {
        return await DbSet.AnyAsync(m => m.GroupId == groupId && m.UserId == userId, cancellationToken).ConfigureAwait(false);
    }

    public Task<PagedResult<GroupMember>> PageByGroupAsync(
        ulong groupId,
        PageRequest request,
        CancellationToken cancellationToken = default
    )
    {
        ArgumentNullException.ThrowIfNull(request);
        return PageAsync(m => m.GroupId == groupId, request, cancellationToken);
    }
}
