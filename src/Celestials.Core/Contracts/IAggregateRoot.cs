namespace Celestials.Core.Contracts;

public interface IAggregateRoot
{
    IReadOnlyCollection<IDomainEvent> DomainEvents { get; }

    bool HasDomainEvents();
    void ClearDomainEvents();
}
