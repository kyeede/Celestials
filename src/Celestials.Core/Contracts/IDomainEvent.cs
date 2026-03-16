namespace Celestials.Core.Contracts;

using Celestials.Core.ValueObjects;

public interface IDomainEvent
{
    EventId Id { get; }
    DateTimeOffset OccurredAt { get; }
}
