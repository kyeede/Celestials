namespace Celestials.Core.ValueObjects.Identifiers;

using System.Diagnostics;
using System.Globalization;
using Celestials.Core.Contracts;

[DebuggerDisplay("{DebuggerDisplay,nq}")]
public readonly record struct EventId : IStronglyTyped<EventId, Guid>
{
    public Guid Value
    {
        get
        {
            if (field == Guid.Empty)
            {
                throw new InvalidOperationException("EventId is not initialized.");
            }

            return field;
        }
    }

    public EventId(Guid value)
    {
        if (value == Guid.Empty)
        {
            throw new ArgumentException("EventId cannot be empty.", nameof(value));
        }

        Value = value;
    }

    public static EventId Empty => default;

    public static EventId New() => new(Guid.NewGuid());

    public static implicit operator Guid(EventId id) => id.Value;

    public static explicit operator EventId(Guid value) => new(value);

    public override string ToString() => Value.ToString("D", CultureInfo.InvariantCulture);

    private string DebuggerDisplay => $"{Value}";
}
