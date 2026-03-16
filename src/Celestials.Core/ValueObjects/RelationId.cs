namespace Celestials.Core.ValueObjects;

using Celestials.Core.Contracts;

public readonly record struct RelationId : IStronlgyTypedId<Guid>
{
    public static readonly RelationId Empty = new(Guid.Empty);

    public Guid Id { get; }

    public RelationId(Guid id)
    {
        if (id == Guid.Empty)
        {
            throw new ArgumentException("RelationId cannot be empty.", nameof(id));
        }

        Id = id;
    }

    public static implicit operator Guid(RelationId relationId) => relationId.Id;

    public static implicit operator RelationId(Guid id) => new(id);
}
