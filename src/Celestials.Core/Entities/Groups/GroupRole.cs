using Celestials.Core.Abstractions;

namespace Celestials.Core.Entities.Groups;

public sealed class GroupRole : IEntity<ulong>, ICreatable
{
    public ulong Id { get; }
    public ulong GroupId { get; }
    public ulong RoleId { get; }

    public DateTimeOffset CreatedAt { get; private set; }
    public ulong CreatedBy { get; private set; }

    private GroupRole() { }

    public GroupRole(ulong id, ulong groupId, ulong roleId, DateTimeOffset createdAt, ulong createdBy)
    {
        Id = id;
        GroupId = groupId;
        RoleId = roleId;
        CreatedAt = createdAt;
        CreatedBy = createdBy;
    }
}
