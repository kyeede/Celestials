namespace Celestials.Core.Abstractions;

public abstract class Entity<TId>
    where TId : struct, IEquatable<TId>
{
    public TId Id { get; protected set; }

    protected Entity(TId id)
    {
        if (id.Equals(default))
        {
            throw new ArgumentException("Id cannot be the default value.", nameof(id));
        }

        Id = id;
    }

    protected Entity() { }

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

        return EqualityComparer<TId>.Default.Equals(Id, other.Id);
    }

    public override bool Equals(object? obj) => Equals(obj as Entity<TId>);

    public override int GetHashCode() => Id.GetHashCode();

    public static bool operator ==(Entity<TId>? left, Entity<TId>? right) => Equals(left, right);

    public static bool operator !=(Entity<TId>? left, Entity<TId>? right) => !Equals(left, right);
}
