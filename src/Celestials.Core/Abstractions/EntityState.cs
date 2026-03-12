namespace Celestials.Core.Abstractions;

public enum EntityState : byte
{
    Unchanged = 0,
    Added = 1,
    Modified = 2,
    Deleted = 3,
}
