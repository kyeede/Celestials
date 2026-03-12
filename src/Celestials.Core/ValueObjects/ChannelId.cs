namespace Celestials.Core.ValueObjects;

using System.Diagnostics;
using System.Globalization;
using Celestials.Core.Contracts;
using Celestials.Core.Exceptions;

[DebuggerDisplay("{DebuggerDisplay,nq}")]
public readonly record struct ChannelId : IValueObject<ulong>
{
    public ulong Value { get; }

    public bool IsEmpty => Value is 0UL;

    public ChannelId(ulong value)
    {
        if (value is 0UL)
        {
            throw new InvalidIdentifierException(nameof(value), "ChannelId cannot be empty.");
        }

        Value = value;
    }

    public static implicit operator ulong(ChannelId id) => id.Value;

    public static explicit operator ChannelId(ulong value) => new(value);

    public override string ToString() => Value.ToString(CultureInfo.InvariantCulture);

    private string DebuggerDisplay => $"ChannelId: {Value}";
}
