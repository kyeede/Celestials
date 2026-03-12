namespace Celestials.Core.Abstractions;

public abstract class Entity<TId> : AuditableEntity
    where TId : struct, IEquatable<TId>
{
    public TId Id { get; }

    protected Entity()
    {
        EntityState = EntityState.Added;
    }

    protected Entity(TId id)
    {
        Id = id;
        EntityState = EntityState.Added;
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

        return Id.Equals(other.Id);
    }

    public sealed override bool Equals(object? obj)
    {
        return Equals(obj as Entity<TId>);
    }

    public override int GetHashCode()
    {
        return Id.GetHashCode();
    }

    public static bool operator ==(Entity<TId>? left, Entity<TId>? right)
    {
        if (left is null)
        {
            return right is null;
        }

        return left.Equals(right);
    }

    public static bool operator !=(Entity<TId>? left, Entity<TId>? right)
    {
        return !(left == right);
    }
}
