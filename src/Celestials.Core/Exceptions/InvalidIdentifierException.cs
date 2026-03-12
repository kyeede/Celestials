namespace Celestials.Core.Exceptions;

public sealed class InvalidIdentifierException : ArgumentException
{
    private const string DefaultMessage = "The identifier is invalid.";

    public InvalidIdentifierException()
        : base(DefaultMessage) { }

    public InvalidIdentifierException(string paramName)
        : base($"The identifier '{paramName}' is invalid.", paramName) { }

    public InvalidIdentifierException(string paramName, string message)
        : base(message, paramName) { }

    public InvalidIdentifierException(string paramName, string message, Exception innerException)
        : base(message, paramName, innerException) { }

    public InvalidIdentifierException(string message, Exception innerException)
        : base(message, innerException) { }
}
