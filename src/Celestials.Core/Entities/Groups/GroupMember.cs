using Celestials.Core.Abstractions;
using Celestials.Core.Entities.Permissions;

namespace Celestials.Core.Entities.Groups;

public sealed class GroupMember : IEntity<ulong>, ICreatable
{
    public ulong Id { get; }
    public ulong UserId { get; }
    public ulong GroupId { get; }

    public PermissionFlags Permissions { get; private set; }

    public DateTimeOffset CreatedAt { get; private set; }
    public ulong CreatedBy { get; private set; }

    private GroupMember() { }

    public GroupMember(ulong id, ulong userId, ulong groupId, PermissionFlags permissions, DateTimeOffset createdAt, ulong createdBy)
    {
        Id = id;
        UserId = userId;
        GroupId = groupId;
        Permissions = permissions;
        CreatedAt = createdAt;
        CreatedBy = createdBy;
    }
}
