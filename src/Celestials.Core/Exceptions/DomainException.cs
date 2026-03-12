namespace Celestials.Core.Exceptions;

using Celestials.Core.Errors;

public sealed class DomainException : Exception
{
    private const string DefaultMessage = "A domain error has occurred.";

    public Error? Error { get; }

    public DomainException()
        : base(DefaultMessage) { }

    public DomainException(string message)
        : base(message) { }

    public DomainException(string message, Exception innerException)
        : base(message, innerException) { }

    public DomainException(Error error)
        : base(error.Message)
    {
        Error = error;
    }

    public DomainException(Error error, Exception innerException)
        : base(error.Message, innerException)
    {
        Error = error;
    }
}
