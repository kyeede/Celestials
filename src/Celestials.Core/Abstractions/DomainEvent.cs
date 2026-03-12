namespace Celestials.Core.Abstractions;

using Celestials.Core.Contracts;
using Celestials.Core.ValueObjects.Identifiers;

public abstract record DomainEvent : IDomainEvent
{
    public EventId Id { get; }
    public DateTimeOffset OccurredAt { get; }

    protected DomainEvent(DateTimeOffset occurredAt)
    {
        Id = EventId.New();
        OccurredAt = occurredAt;
    }

    protected DomainEvent(EventId id, DateTimeOffset occurredAt)
    {
        Id = id;
        OccurredAt = occurredAt;
    }
}
