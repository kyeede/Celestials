namespace Celestials.Core.ValueObjects.Identifiers;

using System.Diagnostics;
using System.Globalization;
using Celestials.Core.Contracts;

[DebuggerDisplay("{DebuggerDisplay,nq}")]
public readonly record struct GuildId : IStronglyTyped<GuildId, ulong>
{
    public ulong Value
    {
        get
        {
            if (field is 0UL)
            {
                throw new InvalidOperationException("GuildId is not initialized.");
            }

            return field;
        }
    }

    public GuildId(ulong value)
    {
        if (value is 0UL)
        {
            throw new ArgumentException("GuildId cannot be empty.", nameof(value));
        }

        Value = value;
    }

    public static GuildId Empty => default;

    public static implicit operator ulong(GuildId id) => id.Value;

    public static explicit operator GuildId(ulong value) => new(value);

    public override string ToString() => Value.ToString(CultureInfo.InvariantCulture);

    private string DebuggerDisplay => $"{Value}";
}
