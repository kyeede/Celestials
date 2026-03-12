namespace Celestials.Core.Errors;

public enum ErrorType : byte
{
    None = 0,

    Validation = 1,
    NotFound = 2,
    Conflict = 3,
    Unauthorized = 4,
    Forbidden = 5,
    Internal = 6,
}
