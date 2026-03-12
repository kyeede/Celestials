namespace Celestials.Core.ValueObjects;

using System.Diagnostics;
using System.Globalization;
using Celestials.Core.Contracts;
using Celestials.Core.Exceptions;

[DebuggerDisplay("{DebuggerDisplay,nq}")]
public readonly record struct EventId : IValueObject<Guid>
{
    public Guid Value { get; }

    public bool IsEmpty => Value == Guid.Empty;

    public EventId(Guid value)
    {
        if (value == Guid.Empty)
        {
            throw new InvalidIdentifierException(nameof(value), "EventId cannot be empty.");
        }

        Value = value;
    }

    public static EventId NewId() => new(Guid.NewGuid());

    public static implicit operator Guid(EventId id) => id.Value;

    public static explicit operator EventId(Guid value) => new(value);

    public override string ToString() => Value.ToString("D", CultureInfo.InvariantCulture);

    private string DebuggerDisplay => $"EventId: {Value}";
}
