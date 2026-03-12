namespace Celestials.Core.Errors;

using System.Diagnostics;

[DebuggerDisplay("{GetDebuggerDisplay(),nq}")]
public readonly record struct Error
{
    public static readonly Error None = new(ErrorType.None, string.Empty, string.Empty);

    public ErrorType Type { get; }
    public string Code { get; }
    public string Message { get; }

    public Error(ErrorType type, string code, string message)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(code);
        ArgumentException.ThrowIfNullOrWhiteSpace(message);

        Type = type;
        Code = code;
        Message = message;
    }

    public override string ToString() => $"{Type}: {Code} - {Message}";

    public static Error Validation(string code, string message) =>
        new(ErrorType.Validation, code, message);

    public static Error NotFound(string code, string message) =>
        new(ErrorType.NotFound, code, message);

    public static Error Conflict(string code, string message) =>
        new(ErrorType.Conflict, code, message);

    public static Error Unauthorized(string code, string message) =>
        new(ErrorType.Unauthorized, code, message);

    public static Error Forbidden(string code, string message) =>
        new(ErrorType.Forbidden, code, message);

    public static Error Internal(string code, string message) =>
        new(ErrorType.Internal, code, message);

    public static Error Timeout(string code, string message) =>
        new(ErrorType.Timeout, code, message);

    public static Error Dependency(string code, string message) =>
        new(ErrorType.Dependency, code, message);

    public static implicit operator bool(Error error) => error.Type is not ErrorType.None;

    private string GetDebuggerDisplay() => $"{Type}: {Code} - {Message}";
}
