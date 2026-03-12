namespace Celestials.Core.Errors;

public readonly record struct Error
{
    public static readonly Error None = new(ErrorType.None, string.Empty);

    public ErrorType Type { get; }
    public string Message { get; }

    public bool IsError => Type != ErrorType.None;

    public Error(ErrorType type, string message)
    {
        Type = type;
        Message = message;
    }

    public override string ToString() => $"Error: {Type} - {Message}";

    public static implicit operator bool(Error error) => error.IsError;
}
