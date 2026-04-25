using Celestials.Core.Abstractions;
using Celestials.Core.Entities.Guilds;

namespace Celestials.Core.Repositories;

public interface IGuildRepository : IRepository<Guild>
{
    Task<Guild?> GetByGuildIdAsync(ulong guildId, CancellationToken cancellationToken = default);
}
