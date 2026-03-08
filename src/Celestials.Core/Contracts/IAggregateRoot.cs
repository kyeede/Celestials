namespace Celestials.Core.Contracts;

public interface IAggregateRoot
{
    IReadOnlyList<IDomainEvent> DomainEvents { get; }
    bool HasDomainEvents { get; }
    void ClearDomainEvents();
}
