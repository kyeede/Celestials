namespace Celestials.Core.ValueObjects;

using Celestials.Core.Contracts;

public readonly record struct GroupId : IStronlgyTypedId<Guid>
{
    public static readonly GroupId Empty = new(Guid.Empty);

    public Guid Id { get; }

    public GroupId(Guid id)
    {
        if (id == Guid.Empty)
        {
            throw new ArgumentException("GroupId cannot be empty.", nameof(id));
        }

        Id = id;
    }

    public static implicit operator Guid(GroupId groupId) => groupId.Id;

    public static implicit operator GroupId(Guid id) => new(id);
}
