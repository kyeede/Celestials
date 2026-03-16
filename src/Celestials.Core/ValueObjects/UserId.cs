namespace Celestials.Core.ValueObjects;

using Celestials.Core.Contracts;

public readonly record struct UserId : IStronlgyTypedId<ulong>
{
    public static readonly UserId Empty = new(0);

    public ulong Id { get; }

    public UserId(ulong id)
    {
        if (id is 0UL)
        {
            throw new ArgumentException("UserId cannot be empty.", nameof(id));
        }

        Id = id;
    }

    public static implicit operator ulong(UserId userId) => userId.Id;

    public static implicit operator UserId(ulong id) => new(id);
}
