namespace Celestials.Core.Exceptions;

using Celestials.Core.Abstractions;

public sealed class InvalidStateException : DomainException
{
    public EntityState State { get; }

    public InvalidStateException()
        : base("The entity state is invalid.") { }

    public InvalidStateException(string message)
        : base(message) { }

    public InvalidStateException(string message, Exception innerException)
        : base(message, innerException) { }

    public InvalidStateException(EntityState state)
        : base($"The entity state '{state}' is invalid.")
    {
        State = state;
    }
}
