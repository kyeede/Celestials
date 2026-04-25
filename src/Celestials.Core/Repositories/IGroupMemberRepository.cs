using Celestials.Core.Abstractions;
using Celestials.Core.Entities.Groups;
using Celestials.Core.Utilities.Paging;

namespace Celestials.Core.Repositories;

public interface IGroupMemberRepository : IRepository<GroupMember>
{
    Task<GroupMember?> GetByUserAsync(ulong groupId, ulong userId, CancellationToken cancellationToken = default);

    Task<bool> IsMemberAsync(ulong groupId, ulong userId, CancellationToken cancellationToken = default);

    Task<PagedResult<GroupMember>> PageByGroupAsync(ulong groupId, PageRequest request, CancellationToken cancellationToken = default);
}
