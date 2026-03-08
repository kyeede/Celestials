namespace Celestials.Core.Abstractions;

using Celestials.Core.Exceptions;

public abstract class TrackableEntity
{
    public EntityState State { get; private set; }

    protected TrackableEntity()
    {
        State = EntityState.Detached;
    }

    public bool IsAdded => State is EntityState.Added;
    public bool IsModified => State is EntityState.Modified;
    public bool IsDeleted => State is EntityState.Deleted;
    public bool IsAttached => State is EntityState.Unchanged or EntityState.Modified;

    protected void MarkAsModified()
    {
        if (State is EntityState.Detached)
        {
            throw new InvalidStateException(EntityState.Detached);
        }

        if (State is EntityState.Deleted)
        {
            throw new InvalidStateException(EntityState.Deleted);
        }

        if (State is EntityState.Unchanged)
        {
            State = EntityState.Modified;
        }
    }

    internal void MarkAsAttached()
    {
        if (State is not EntityState.Detached)
        {
            throw new InvalidStateException(EntityState.Detached);
        }

        State = EntityState.Unchanged;
    }

    internal void MarkAsAdded()
    {
        if (State is not EntityState.Detached)
        {
            throw new InvalidStateException(EntityState.Detached);
        }

        State = EntityState.Added;
    }

    internal void MarkAsDeleted()
    {
        if (State is EntityState.Detached)
        {
            throw new InvalidStateException(EntityState.Detached);
        }

        if (State is EntityState.Added)
        {
            throw new InvalidStateException(EntityState.Added);
        }

        State = EntityState.Deleted;
    }

    internal void MarkAsDetached()
    {
        if (State is EntityState.Added)
        {
            throw new InvalidStateException(EntityState.Added);
        }

        if (State is EntityState.Modified)
        {
            throw new InvalidStateException(EntityState.Modified);
        }

        if (State is EntityState.Deleted)
        {
            throw new InvalidStateException(EntityState.Deleted);
        }

        State = EntityState.Detached;
    }
}
