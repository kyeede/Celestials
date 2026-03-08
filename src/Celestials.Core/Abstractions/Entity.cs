namespace Celestials.Core.Abstractions;

public abstract class Entity<TId> : AuditableEntity, IEquatable<Entity<TId>>
    where TId : struct, IEquatable<TId>
{
    private int? _hashCode;

    public TId Id { get; protected set; }

    protected Entity(TId id)
    {
        if (EqualityComparer<TId>.Default.Equals(id, default))
        {
            throw new ArgumentException("Entity ID cannot be the default value.", nameof(id));
        }

        Id = id;
    }

    protected Entity() { }

    public bool GetIsTransient()
    {
        return EqualityComparer<TId>.Default.Equals(Id, default);
    }

    public bool Equals(Entity<TId>? other)
    {
        if (other is null)
        {
            return false;
        }

        if (ReferenceEquals(this, other))
        {
            return true;
        }

        if (GetType() != other.GetType())
        {
            return false;
        }

        if (GetIsTransient() || other.GetIsTransient())
        {
            return false;
        }

        return EqualityComparer<TId>.Default.Equals(Id, other.Id);
    }

    public sealed override bool Equals(object? obj)
    {
        return obj is Entity<TId> other && Equals(other);
    }

    public sealed override int GetHashCode()
    {
        if (GetIsTransient())
        {
            return base.GetHashCode();
        }

        return _hashCode ??= HashCode.Combine(GetType(), Id);
    }

    public static bool operator ==(Entity<TId>? left, Entity<TId>? right)
    {
        return left?.Equals(right) ?? (right is null);
    }

    public static bool operator !=(Entity<TId>? left, Entity<TId>? right)
    {
        return !(left == right);
    }
}
