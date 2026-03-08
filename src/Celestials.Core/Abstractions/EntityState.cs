namespace Celestials.Core.Abstractions;

public enum EntityState : byte
{
    Detached = 0,
    Unchanged = 1,
    Added = 2,
    Modified = 3,
    Deleted = 4,
}
