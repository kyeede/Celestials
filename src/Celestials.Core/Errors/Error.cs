namespace Celestials.Core.Errors;

public readonly record struct Error
{
    public static readonly Error None = new(ErrorType.None, string.Empty);

    public ErrorType Type { get; }
    public string Message { get; }

    public bool IsNone => Type is ErrorType.None;

    public Error(ErrorType type, string message)
    {
        Type = type;
        Message = message;
    }

    public static implicit operator bool(Error error) => error.Type is not ErrorType.None;

    public override string ToString() => $"{Type}: {Message}";
}
