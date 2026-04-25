namespace Celestials.Core.Errors;

public enum ErrorType : byte
{
    None = 0,

    Validation = 1,
    Permission = 2,
    NotFound = 3,
    Conflict = 4,
    RateLimited = 5,
    Timeout = 6,
    Internal = 7,
}
