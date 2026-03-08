namespace Celestials.Core.Errors;

public enum ErrorType : byte
{
    None = 0,
    Failure = 1,
    Validation = 2,
    Conflict = 3,
    Policy = 4,
    Unauthorized = 5,
    Forbidden = 6,
    Locked = 7,
    NotFound = 8,
    Deleted = 9,
    Throttled = 10,
    Integration = 11,
    Infrastructure = 12,
    System = 13,
}
