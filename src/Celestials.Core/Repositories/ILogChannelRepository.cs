using Celestials.Core.Abstractions;
using Celestials.Core.Entities.Channels;
using Celestials.Core.Utilities.Paging;

namespace Celestials.Core.Repositories;

public interface ILogChannelRepository : IRepository<LogChannel>
{
    Task<LogChannel?> GetGlobalAsync(ulong guildId, CancellationToken cancellationToken = default);

    Task<LogChannel?> GetByGroupAsync(ulong guildId, ulong groupId, CancellationToken cancellationToken = default);

    Task<bool> GlobalExistsAsync(ulong guildId, CancellationToken cancellationToken = default);

    Task<bool> GroupChannelExistsAsync(ulong guildId, ulong groupId, CancellationToken cancellationToken = default);

    Task<PagedResult<LogChannel>> PageByGuildAsync(ulong guildId, PageRequest request, CancellationToken cancellationToken = default);
}
