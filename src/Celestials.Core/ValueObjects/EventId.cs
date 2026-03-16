namespace Celestials.Core.ValueObjects;

using Celestials.Core.Contracts;

public readonly record struct EventId : IStronlgyTypedId<Guid>
{
    public static readonly EventId Empty = new(Guid.Empty);

    public Guid Id { get; }

    public EventId(Guid id)
    {
        if (id == Guid.Empty)
        {
            throw new ArgumentException("EventId cannot be empty.", nameof(id));
        }

        Id = id;
    }

    public static implicit operator Guid(EventId eventId) => eventId.Id;

    public static implicit operator EventId(Guid id) => new(id);
}
