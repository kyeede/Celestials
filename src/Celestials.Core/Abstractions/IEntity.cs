namespace Celestials.Core.Abstractions;

public interface IEntity<TId>
    where TId : IEquatable<TId>
{
    TId Id { get; }
}
