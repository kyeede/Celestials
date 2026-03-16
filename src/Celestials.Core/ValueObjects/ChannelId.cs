namespace Celestials.Core.ValueObjects;

using Celestials.Core.Contracts;

public readonly record struct ChannelId : IStronlgyTypedId<ulong>
{
    public static readonly ChannelId Empty = new(0);

    public ulong Id { get; }

    public ChannelId(ulong id)
    {
        if (id is 0UL)
        {
            throw new ArgumentException("ChannelId cannot be empty.", nameof(id));
        }

        Id = id;
    }

    public static implicit operator ulong(ChannelId channelId) => channelId.Id;

    public static implicit operator ChannelId(ulong id) => new(id);
}
