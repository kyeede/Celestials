namespace Celestials.Core.ValueObjects;

using Celestials.Core.Contracts;

public readonly record struct RoleId : IStronlgyTypedId<ulong>
{
    public static readonly RoleId Empty = new(0);

    public ulong Id { get; }

    public RoleId(ulong id)
    {
        if (id is 0UL)
        {
            throw new ArgumentException("RoleId cannot be empty.", nameof(id));
        }

        Id = id;
    }

    public static implicit operator ulong(RoleId roleId) => roleId.Id;

    public static implicit operator RoleId(ulong id) => new(id);
}
