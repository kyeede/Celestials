using Celestials.Core.Abstractions;

namespace Celestials.Core.Entities.Permissions;

public sealed class PermissionOverwrite : IEntity<ulong>, IAuditable
{
    public ulong Id { get; }
    public ulong GuildId { get; }
    public ulong GroupId { get; }

    public PermissionScope Scope { get; private set; }
    public PermissionFlags Allowed { get; private set; }
    public PermissionFlags Denied { get; private set; }

    public DateTimeOffset CreatedAt { get; private set; }
    public DateTimeOffset? UpdatedAt { get; private set; }
    public DateTimeOffset? DeletedAt { get; private set; }

    public ulong CreatedBy { get; private set; }
    public ulong? UpdatedBy { get; private set; }
    public ulong? DeletedBy { get; private set; }

    private PermissionOverwrite() { }

    public PermissionOverwrite(
        ulong id,
        ulong guildId,
        ulong groupId,
        PermissionScope scope,
        PermissionFlags allowed,
        PermissionFlags denied,
        DateTimeOffset createdAt,
        ulong createdBy
    )
    {
        Id = id;
        GuildId = guildId;
        GroupId = groupId;
        Scope = scope;
        Allowed = allowed;
        Denied = denied;
        CreatedAt = createdAt;
        CreatedBy = createdBy;
    }
}
