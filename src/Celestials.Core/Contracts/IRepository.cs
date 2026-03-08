namespace Celestials.Core.Contracts;

using Celestials.Core.Abstractions;

public interface IRepository<TAggregate, TId>
    where TAggregate : AggregateRoot<TId>
    where TId : struct, IEquatable<TId>
{
    Task<TAggregate?> FindAsync(TId id, CancellationToken cancellationToken = default);
    void Add(TAggregate aggregate);
    void Remove(TAggregate aggregate);
}
