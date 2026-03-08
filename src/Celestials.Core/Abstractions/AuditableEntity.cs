namespace Celestials.Core.Abstractions;

using Celestials.Core.Identifiers;

public abstract class AuditableEntity : TrackableEntity
{
    public DateTimeOffset CreatedAt { get; private set; }
    public UserId CreatedBy { get; private set; }

    public DateTimeOffset? LastModifiedAt { get; private set; }
    public UserId? LastModifiedBy { get; private set; }

    public DateTimeOffset? DeletedAt { get; private set; }
    public UserId? DeletedBy { get; private set; }

    public bool IsSoftDeleted => DeletedAt.HasValue;

    protected AuditableEntity() { }

    protected void MarkModified(UserId userId, DateTimeOffset timestamp)
    {
        LastModifiedAt = timestamp;
        LastModifiedBy = userId;
        MarkAsModified();
    }

    internal void MarkCreated(UserId userId, DateTimeOffset timestamp)
    {
        CreatedAt = timestamp;
        CreatedBy = userId;
        MarkAsAdded();
    }

    internal void MarkDeleted(UserId userId, DateTimeOffset timestamp)
    {
        DeletedAt = timestamp;
        DeletedBy = userId;
        MarkAsDeleted();
    }
}
