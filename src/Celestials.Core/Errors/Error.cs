namespace Celestials.Core.Errors;

public readonly record struct Error(ErrorType Type, string Code, string Message)
{
    public static readonly Error None = new(ErrorType.None, ErrorCodes.None, string.Empty);

    public static readonly Error NullValue = new(
        ErrorType.Failure,
        ErrorCodes.NullValue,
        "The specified result value is null."
    );

    public bool IsNone => Type is ErrorType.None;
    public bool IsFailure => !IsNone;

    public Error WithCode(string code)
    {
        return this with { Code = code };
    }

    public Error WithMessage(string message)
    {
        return this with { Message = message };
    }

    public static Error Failure(string message)
    {
        return new(ErrorType.Failure, ErrorCodes.Unexpected, message);
    }

    public static Error Validation(string message)
    {
        return new(ErrorType.Validation, ErrorCodes.Validation, message);
    }

    public static Error NotFound(string message)
    {
        return new(ErrorType.NotFound, ErrorCodes.NotFound, message);
    }

    public static Error Conflict(string message)
    {
        return new(ErrorType.Conflict, ErrorCodes.Conflict, message);
    }

    public static Error Unauthorized(string message)
    {
        return new(ErrorType.Unauthorized, ErrorCodes.Unauthorized, message);
    }

    public static Error Forbidden(string message)
    {
        return new(ErrorType.Forbidden, ErrorCodes.Forbidden, message);
    }

    public static Error Locked(string message)
    {
        return new(ErrorType.Locked, ErrorCodes.Locked, message);
    }

    public static Error Throttled(string message)
    {
        return new(ErrorType.Throttled, ErrorCodes.Throttled, message);
    }

    public static implicit operator Error(ErrorType type)
    {
        return new(type, ErrorCodes.None, string.Empty);
    }

    public override string ToString()
    {
        return $"[{Type}] {Code}: {Message}";
    }
}
