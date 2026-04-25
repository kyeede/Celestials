using Celestials.Core.Abstractions;
using Celestials.Core.Entities.Permissions;

namespace Celestials.Core.Entities.Guilds;

public sealed class GuildMember : IEntity<ulong>, IAuditable
{
    private readonly List<ulong> _roles = [];

    public ulong Id { get; }
    public ulong GuildId { get; }
    public ulong UserId { get; }

    public PermissionFlags Permissions { get; private set; }

    public DateTimeOffset CreatedAt { get; private set; }
    public DateTimeOffset? UpdatedAt { get; private set; }
    public DateTimeOffset? DeletedAt { get; private set; }

    public ulong CreatedBy { get; private set; }
    public ulong? UpdatedBy { get; private set; }
    public ulong? DeletedBy { get; private set; }

    public IReadOnlyList<ulong> Roles => _roles;

    private GuildMember() { }

    public GuildMember(ulong id, ulong guildId, ulong userId, PermissionFlags permissions, DateTimeOffset createdAt, ulong createdBy)
    {
        Id = id;
        GuildId = guildId;
        UserId = userId;
        Permissions = permissions;
        CreatedAt = createdAt;
        CreatedBy = createdBy;
    }
}
