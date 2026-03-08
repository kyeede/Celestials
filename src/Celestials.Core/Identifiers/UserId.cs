namespace Celestials.Core.Identifiers;

using System.Diagnostics;
using System.Globalization;
using Celestials.Core.Contracts;
using Celestials.Core.Exceptions;

[DebuggerDisplay("{DebuggerDisplay,nq}")]
public readonly record struct UserId : IStronglyTypedId<ulong>
{
    public ulong Value { get; }

    public UserId(ulong value)
    {
        if (value is 0UL)
        {
            throw new InvalidIdentifierException(nameof(UserId), value);
        }

        Value = value;
    }

    public static implicit operator ulong(UserId id) => id.Value;

    public static explicit operator UserId(ulong value) => new(value);

    public override string ToString() => Value.ToString(CultureInfo.InvariantCulture);

    private string DebuggerDisplay => $"{nameof(UserId)}: {Value}";
}
