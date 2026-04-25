using Celestials.Core.Abstractions;

namespace Celestials.Core.Entities.Guilds;

public sealed class Guild : IEntity<ulong>, IAuditable
{
    public ulong Id { get; }
    public string Name { get; private set; }
    public string? IconUrl { get; private set; }

    public DateTimeOffset CreatedAt { get; private set; }
    public DateTimeOffset? UpdatedAt { get; private set; }
    public DateTimeOffset? DeletedAt { get; private set; }

    public ulong CreatedBy { get; private set; }
    public ulong? UpdatedBy { get; private set; }
    public ulong? DeletedBy { get; private set; }

    private Guild()
    {
        Name = string.Empty;
    }

    public Guild(ulong id, string name, string? iconUrl, DateTimeOffset createdAt, ulong createdBy)
    {
        Id = id;
        Name = name;
        IconUrl = iconUrl;
        CreatedAt = createdAt;
        CreatedBy = createdBy;
    }
}
