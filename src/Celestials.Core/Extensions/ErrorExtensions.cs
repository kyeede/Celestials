namespace Celestials.Core.Extensions;

using Celestials.Core.Errors;

public static class ErrorExtensions
{
    extension(ErrorType type)
    {
        public Error ToError(string message)
        {
            return type switch
            {
                ErrorType.None => Error.None,
                ErrorType.Failure => new(type, ErrorCodes.Unexpected, message),
                ErrorType.Validation => new(type, ErrorCodes.Validation, message),
                ErrorType.Conflict => new(type, ErrorCodes.Conflict, message),
                ErrorType.Policy => new(type, ErrorCodes.Policy, message),
                ErrorType.Unauthorized => new(type, ErrorCodes.Unauthorized, message),
                ErrorType.Forbidden => new(type, ErrorCodes.Forbidden, message),
                ErrorType.Locked => new(type, ErrorCodes.Locked, message),
                ErrorType.NotFound => new(type, ErrorCodes.NotFound, message),
                ErrorType.Deleted => new(type, ErrorCodes.Deleted, message),
                ErrorType.Throttled => new(type, ErrorCodes.Throttled, message),
                ErrorType.Integration => new(type, ErrorCodes.Integration, message),
                ErrorType.Infrastructure => new(type, ErrorCodes.Infrastructure, message),
                ErrorType.System => new(type, ErrorCodes.System, message),
                _ => new(ErrorType.Failure, ErrorCodes.Unexpected, message),
            };
        }
    }

    extension(string message)
    {
        public Error AsNotFound()
        {
            return Error.NotFound(message);
        }

        public Error AsValidation()
        {
            return Error.Validation(message);
        }

        public Error AsConflict()
        {
            return Error.Conflict(message);
        }

        public Error AsFailure()
        {
            return Error.Failure(message);
        }

        public Error AsForbidden()
        {
            return Error.Forbidden(message);
        }

        public Error AsUnauthorized()
        {
            return Error.Unauthorized(message);
        }
    }
}
