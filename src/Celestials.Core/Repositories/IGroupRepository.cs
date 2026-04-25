using Celestials.Core.Abstractions;
using Celestials.Core.Entities.Groups;
using Celestials.Core.Utilities.Paging;

namespace Celestials.Core.Repositories;

public interface IGroupRepository : IRepository<Group>
{
    Task<Group?> GetByIdWithDetailsAsync(ulong id, CancellationToken cancellationToken = default);

    Task<Group?> GetByNameAsync(ulong guildId, string name, CancellationToken cancellationToken = default);

    Task<bool> ExistsByNameAsync(ulong guildId, string name, CancellationToken cancellationToken = default);

    Task<PagedResult<Group>> PageByGuildAsync(ulong guildId, PageRequest request, CancellationToken cancellationToken = default);

    Task<PagedResult<Group>> PageByOwnerAsync(
        ulong guildId,
        ulong ownerId,
        PageRequest request,
        CancellationToken cancellationToken = default
    );
}
