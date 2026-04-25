using Celestials.Core.Abstractions;
using Celestials.Core.Entities.Guilds;
using Celestials.Core.Utilities.Paging;

namespace Celestials.Core.Repositories;

public interface IGuildMemberRepository : IRepository<GuildMember>
{
    Task<GuildMember?> GetByUserAsync(ulong guildId, ulong userId, CancellationToken cancellationToken = default);

    Task<bool> IsMemberAsync(ulong guildId, ulong userId, CancellationToken cancellationToken = default);

    Task<PagedResult<GuildMember>> PageByGuildAsync(ulong guildId, PageRequest request, CancellationToken cancellationToken = default);
}
