using Celestials.Core.Abstractions;

namespace Celestials.Core.Entities.Channels;

public sealed class LogChannel : IEntity<ulong>, IAuditable
{
    public ulong Id { get; }

    public ulong GuildId { get; }
    public ulong ChannelId { get; }
    public ulong? GroupId { get; private set; }

    public ChannelScope Scope { get; private set; }
    public ChannelFlags Flags { get; private set; }

    public DateTimeOffset CreatedAt { get; private set; }
    public DateTimeOffset? UpdatedAt { get; private set; }
    public DateTimeOffset? DeletedAt { get; private set; }

    public ulong CreatedBy { get; private set; }
    public ulong? UpdatedBy { get; private set; }
    public ulong? DeletedBy { get; private set; }

    private LogChannel() { }

    public LogChannel(
        ulong id,
        ulong guildId,
        ulong channelId,
        ulong? groupId,
        ChannelScope scope,
        ChannelFlags flags,
        DateTimeOffset createdAt,
        ulong createdBy
    )
    {
        Id = id;
        GuildId = guildId;
        ChannelId = channelId;
        GroupId = groupId;
        Scope = scope;
        Flags = flags;
        CreatedAt = createdAt;
        CreatedBy = createdBy;
    }
}
