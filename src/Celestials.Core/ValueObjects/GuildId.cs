namespace Celestials.Core.ValueObjects;

using Celestials.Core.Contracts;

public readonly record struct GuildId : IStronlgyTypedId<ulong>
{
    public static readonly GuildId Empty = new(0);

    public ulong Id { get; }

    public GuildId(ulong id)
    {
        if (id is 0UL)
        {
            throw new ArgumentException("GuildId cannot be empty.", nameof(id));
        }

        Id = id;
    }

    public static implicit operator ulong(GuildId guildId) => guildId.Id;

    public static implicit operator GuildId(ulong id) => new(id);
}
