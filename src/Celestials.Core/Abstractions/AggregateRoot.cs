namespace Celestials.Core.Abstractions;

using Celestials.Core.Contracts;

public abstract class AggregateRoot<TId> : Entity<TId>, IAggregateRoot
    where TId : struct, IEquatable<TId>
{
    private readonly List<IDomainEvent> _domainEvents = [];

    protected AggregateRoot(TId id)
        : base(id) { }

    protected AggregateRoot() { }

    public IReadOnlyCollection<IDomainEvent> DomainEvents => _domainEvents.AsReadOnly();

    public void AddDomainEvent(IDomainEvent @event)
    {
        ArgumentNullException.ThrowIfNull(@event);
        _domainEvents.Add(@event);
    }

    public void ClearDomainEvents() => _domainEvents.Clear();
}
