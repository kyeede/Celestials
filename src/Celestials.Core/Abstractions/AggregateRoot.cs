namespace Celestials.Core.Abstractions;

using Celestials.Core.Contracts;

public abstract class AggregateRoot<TId> : Entity<TId>, IAggregateRoot
    where TId : struct, IEquatable<TId>
{
    private readonly List<IDomainEvent> _domainEvents = [];

    public IReadOnlyCollection<IDomainEvent> DomainEvents => _domainEvents.AsReadOnly();

    protected AggregateRoot(TId id)
        : base(id) { }

    protected AggregateRoot() { }

    protected void AddDomainEvent(IDomainEvent domainEvent)
    {
        ArgumentNullException.ThrowIfNull(domainEvent);
        _domainEvents.Add(domainEvent);
    }

    public bool HasDomainEvents() => _domainEvents is not { Count: 0 };

    public void ClearDomainEvents() => _domainEvents.Clear();
}
