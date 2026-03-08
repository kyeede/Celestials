namespace Celestials.Core.Abstractions;

using Celestials.Core.Contracts;
using Celestials.Core.Identifiers;

public abstract record DomainEvent : IDomainEvent
{
    public EventId Id { get; }
    public DateTimeOffset OccurredAt { get; }

    protected DomainEvent()
    {
        Id = new EventId(Guid.NewGuid());
        OccurredAt = DateTimeOffset.UtcNow;
    }

    protected DomainEvent(EventId id, DateTimeOffset occurredAt)
    {
        Id = id;
        OccurredAt = occurredAt;
    }
}
