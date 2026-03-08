namespace Celestials.Core.Identifiers;

using System.Diagnostics;
using System.Globalization;
using Celestials.Core.Contracts;
using Celestials.Core.Exceptions;

[DebuggerDisplay("{DebuggerDisplay,nq}")]
public readonly record struct ChannelId : IStronglyTypedId<ulong>
{
    public ulong Value { get; }

    public ChannelId(ulong value)
    {
        if (value is 0UL)
        {
            throw new InvalidIdentifierException(nameof(ChannelId), value);
        }

        Value = value;
    }

    public static implicit operator ulong(ChannelId id) => id.Value;

    public static explicit operator ChannelId(ulong value) => new(value);

    public override string ToString() => Value.ToString(CultureInfo.InvariantCulture);

    private string DebuggerDisplay => $"{nameof(ChannelId)}: {Value}";
}
