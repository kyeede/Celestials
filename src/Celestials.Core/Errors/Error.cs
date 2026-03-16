namespace Celestials.Core.Errors;

public readonly record struct Error
{
    public static readonly Error None = new(ErrorType.None, string.Empty, string.Empty);

    public ErrorType Type { get; }
    public string Code { get; }
    public string Message { get; }

    public bool IsNone => Type is ErrorType.None;

    public Error(ErrorType type, string code, string message)
    {
        Type = type;
        Code = code;
        Message = message;
    }

    public static implicit operator bool(Error error) => !error.IsNone;

    public override string ToString() => $"{Type}: {Code} - {Message}";
}
