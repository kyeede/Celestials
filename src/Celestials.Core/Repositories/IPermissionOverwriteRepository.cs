using Celestials.Core.Abstractions;
using Celestials.Core.Entities.Permissions;
using Celestials.Core.Utilities.Paging;

namespace Celestials.Core.Repositories;

public interface IPermissionOverwriteRepository : IRepository<PermissionOverwrite>
{
    Task<PermissionOverwrite?> GetByTargetAsync(
        ulong guildId,
        ulong groupId,
        PermissionScope scope,
        CancellationToken cancellationToken = default
    );

    Task<bool> ExistsByTargetAsync(ulong guildId, ulong groupId, PermissionScope scope, CancellationToken cancellationToken = default);

    Task<PagedResult<PermissionOverwrite>> PageByGroupAsync(
        ulong guildId,
        ulong groupId,
        PageRequest request,
        CancellationToken cancellationToken = default
    );
}
