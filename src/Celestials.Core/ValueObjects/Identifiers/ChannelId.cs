namespace Celestials.Core.ValueObjects.Identifiers;

using System.Diagnostics;
using System.Globalization;
using Celestials.Core.Contracts;

[DebuggerDisplay("{DebuggerDisplay,nq}")]
public readonly record struct ChannelId : IStronglyTyped<ChannelId, ulong>
{
    public ulong Value
    {
        get
        {
            if (field is 0UL)
            {
                throw new InvalidOperationException("ChannelId is not initialized.");
            }

            return field;
        }
    }

    public ChannelId(ulong value)
    {
        if (value is 0UL)
        {
            throw new ArgumentException("ChannelId cannot be empty.", nameof(value));
        }

        Value = value;
    }

    public static ChannelId Empty => default;

    public static implicit operator ulong(ChannelId id) => id.Value;

    public static explicit operator ChannelId(ulong value) => new(value);

    public override string ToString() => Value.ToString(CultureInfo.InvariantCulture);

    private string DebuggerDisplay => $"{Value}";
}
