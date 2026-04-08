namespace Celestials.Core.Errors;

public enum ErrorType : byte
{
    None,
    Unknown,
    BadRequest,
    Unauthorized,
    Forbidden,
    NotFound,
    TooManyRequests,
    InternalServerError,
    ServiceUnavailable,
}
