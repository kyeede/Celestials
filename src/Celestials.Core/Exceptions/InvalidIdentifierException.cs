namespace Celestials.Core.Exceptions;

public sealed class InvalidIdentifierException : DomainException
{
    public string? IdentifierName { get; }
    public object? AttemptedValue { get; }

    public InvalidIdentifierException()
        : base("The identifier is invalid.") { }

    public InvalidIdentifierException(string message)
        : base(message) { }

    public InvalidIdentifierException(string message, Exception innerException)
        : base(message, innerException) { }

    public InvalidIdentifierException(string identifierName, object? attemptedValue)
        : base($"Invalid value '{attemptedValue}' for identifier '{identifierName}'.")
    {
        IdentifierName = identifierName;
        AttemptedValue = attemptedValue;
    }
}
