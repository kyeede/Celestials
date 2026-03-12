namespace Celestials.Core.Abstractions;

using Celestials.Core.Errors;
using Celestials.Core.Results;
using Celestials.Core.ValueObjects.Identifiers;

public abstract class AuditableEntity
{
    public EntityState EntityState { get; protected set; }

    public DateTimeOffset CreatedAt { get; set; }
    public UserId CreatedBy { get; set; }

    public DateTimeOffset? UpdatedAt { get; set; }
    public UserId? UpdatedBy { get; set; }

    public DateTimeOffset? DeletedAt { get; set; }
    public UserId? DeletedBy { get; set; }

    public bool IsDeleted => EntityState is EntityState.Deleted;

    protected AuditableEntity()
    {
        EntityState = EntityState.Unchanged;
    }

    protected virtual Result MarkAsModified(UserId modifiedBy, DateTimeOffset modifiedAt)
    {
        if (IsDeleted)
        {
            return Result.Failure(
                Error.Conflict("Entity.Deleted", "Cannot modify a deleted entity.")
            );
        }

        if (EntityState is not EntityState.Added)
        {
            EntityState = EntityState.Modified;
        }

        UpdatedBy = modifiedBy;
        UpdatedAt = modifiedAt;

        return Result.Success();
    }

    internal Result MarkAsAdded(UserId addedBy, DateTimeOffset addedAt)
    {
        if (IsDeleted)
        {
            return Result.Failure(
                Error.Conflict("Entity.Lifecycle", "Cannot add an entity marked as deleted.")
            );
        }

        EntityState = EntityState.Added;
        CreatedBy = addedBy;
        CreatedAt = addedAt;

        return Result.Success();
    }

    internal Result MarkAsDeleted(UserId deletedBy, DateTimeOffset deletedAt)
    {
        if (EntityState is EntityState.Added)
        {
            return Result.Failure(
                Error.Validation(
                    "Entity.Lifecycle",
                    "Discard unsaved new entities instead of deleting them."
                )
            );
        }

        EntityState = EntityState.Deleted;
        DeletedBy = deletedBy;
        DeletedAt = deletedAt;

        return Result.Success();
    }

    internal Result MarkAsUnchanged()
    {
        if (IsDeleted)
        {
            return Result.Failure(
                Error.Conflict("Entity.State", "Deleted entities cannot return to unchanged state.")
            );
        }

        EntityState = EntityState.Unchanged;
        return Result.Success();
    }
}
