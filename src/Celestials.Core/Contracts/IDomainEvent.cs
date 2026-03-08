namespace Celestials.Core.Contracts;

using Celestials.Core.Identifiers;

public interface IDomainEvent
{
    EventId Id { get; }
    DateTimeOffset OccurredAt { get; }
}
