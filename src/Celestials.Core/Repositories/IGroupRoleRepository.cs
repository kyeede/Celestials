using Celestials.Core.Abstractions;
using Celestials.Core.Entities.Groups;
using Celestials.Core.Utilities.Paging;

namespace Celestials.Core.Repositories;

public interface IGroupRoleRepository : IRepository<GroupRole>
{
    Task<GroupRole?> GetByRoleAsync(ulong groupId, ulong roleId, CancellationToken cancellationToken = default);

    Task<bool> IsAssignedAsync(ulong groupId, ulong roleId, CancellationToken cancellationToken = default);

    Task<PagedResult<GroupRole>> PageByGroupAsync(ulong groupId, PageRequest request, CancellationToken cancellationToken = default);
}
