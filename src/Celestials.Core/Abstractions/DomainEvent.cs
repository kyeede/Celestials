namespace Celestials.Core.Abstractions;

using Celestials.Core.Contracts;
using Celestials.Core.ValueObjects;

public sealed record DomainEvent : IDomainEvent
{
    public EventId Id { get; }
    public DateTimeOffset OccurredAt { get; }

    public DomainEvent(DateTimeOffset occurredAt)
    {
        Id = new EventId(Guid.NewGuid());
        OccurredAt = occurredAt;
    }

    public DomainEvent(EventId id, DateTimeOffset occurredAt)
    {
        Id = id;
        OccurredAt = occurredAt;
    }
}
