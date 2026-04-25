using Celestials.Core.Abstractions;

namespace Celestials.Core.Entities.Groups;

public sealed class Group : IEntity<ulong>, IAuditable
{
    private readonly List<GroupMember> _members = [];
    private readonly List<GroupRole> _roles = [];

    public ulong Id { get; }
    public ulong GuildId { get; }
    public ulong OwnerId { get; private set; }

    public string Name { get; private set; }
    public string? Description { get; private set; }

    public DateTimeOffset CreatedAt { get; private set; }
    public DateTimeOffset? UpdatedAt { get; private set; }
    public DateTimeOffset? DeletedAt { get; private set; }

    public ulong CreatedBy { get; private set; }
    public ulong? UpdatedBy { get; private set; }
    public ulong? DeletedBy { get; private set; }

    public IReadOnlyList<GroupMember> Members => _members;
    public IReadOnlyList<GroupRole> Roles => _roles;

    private Group()
    {
        Name = string.Empty;
    }

    public Group(ulong id, ulong guildId, ulong ownerId, string name, string? description, DateTimeOffset createdAt, ulong createdBy)
    {
        Id = id;
        GuildId = guildId;
        OwnerId = ownerId;
        Name = name;
        Description = description;
        CreatedAt = createdAt;
        CreatedBy = createdBy;
    }
}
