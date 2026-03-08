namespace Celestials.Core.Identifiers;

using System.Diagnostics;
using System.Globalization;
using Celestials.Core.Contracts;
using Celestials.Core.Exceptions;

[DebuggerDisplay("{DebuggerDisplay,nq}")]
public readonly record struct EventId : IStronglyTypedId<Guid>
{
    public Guid Value { get; }

    public EventId(Guid value)
    {
        if (value == Guid.Empty)
        {
            throw new InvalidIdentifierException(nameof(EventId), value);
        }

        Value = value;
    }

    public static implicit operator Guid(EventId id) => id.Value;

    public static explicit operator EventId(Guid value) => new(value);

    public override string ToString() => Value.ToString("D", CultureInfo.InvariantCulture);

    private string DebuggerDisplay => $"{nameof(EventId)}: {Value}";
}
