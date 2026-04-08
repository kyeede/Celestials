namespace Celestials.Core.Entities;

public interface IEntity<TId>
    where TId : IEquatable<TId>
{
    TId Id { get; }
}
