namespace Celestials.Core.Contracts;

using Celestials.Core.ValueObjects.Identifiers;

public interface IDomainEvent
{
    EventId Id { get; }
    DateTimeOffset OccurredAt { get; }
}
