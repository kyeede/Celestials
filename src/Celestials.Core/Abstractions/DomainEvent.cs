namespace Celestials.Core.Abstractions;

using Celestials.Core.ValueObjects;

public abstract record DomainEvent
{
    public EventId Id { get; }
    public DateTimeOffset OccurredOn { get; }

    protected DomainEvent()
    {
        Id = EventId.NewId();
        OccurredOn = DateTimeOffset.UtcNow;
    }

    protected DomainEvent(EventId id, DateTimeOffset occurredOn)
    {
        Id = id;
        OccurredOn = occurredOn;
    }
}
