namespace Celestials.Core.Errors;

public readonly record struct Error
{
    public static readonly Error None = new(ErrorType.None, string.Empty, string.Empty);

    public ErrorType Type { get; init; }
    public string Code { get; init; }
    public string Message { get; init; }

    public bool IsNone => Type is ErrorType.None;

    public Error(ErrorType type, string code, string message)
    {
        Type = type;
        Code = code;
        Message = message;
    }

    public static Error Validation(string code, string message)
    {
        return new(ErrorType.Validation, code, message);
    }

    public static Error Permission(string code, string message)
    {
        return new(ErrorType.Permission, code, message);
    }

    public static Error NotFound(string code, string message)
    {
        return new(ErrorType.NotFound, code, message);
    }

    public static Error Conflict(string code, string message)
    {
        return new(ErrorType.Conflict, code, message);
    }

    public static Error RateLimited(string code, string message)
    {
        return new(ErrorType.RateLimited, code, message);
    }

    public static Error Timeout(string code, string message)
    {
        return new(ErrorType.Timeout, code, message);
    }

    public static Error Internal(string code, string message)
    {
        return new(ErrorType.Internal, code, message);
    }

    public override string ToString()
    {
        return this is { Type: ErrorType.None } ? nameof(None) : $"{Type}: {Code} - {Message}";
    }
}
