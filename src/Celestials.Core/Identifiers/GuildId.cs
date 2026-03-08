namespace Celestials.Core.Identifiers;

using System.Diagnostics;
using System.Globalization;
using Celestials.Core.Contracts;
using Celestials.Core.Exceptions;

[DebuggerDisplay("{DebuggerDisplay,nq}")]
public readonly record struct GuildId : IStronglyTypedId<ulong>
{
    public ulong Value { get; }

    public GuildId(ulong value)
    {
        if (value is 0UL)
        {
            throw new InvalidIdentifierException(nameof(GuildId), value);
        }

        Value = value;
    }

    public static implicit operator ulong(GuildId id) => id.Value;

    public static explicit operator GuildId(ulong value) => new(value);

    public override string ToString() => Value.ToString(CultureInfo.InvariantCulture);

    private string DebuggerDisplay => $"{nameof(GuildId)}: {Value}";
}
