namespace Celestials.Core.ValueObjects;

using System.Diagnostics;
using System.Globalization;
using Celestials.Core.Contracts;
using Celestials.Core.Exceptions;

[DebuggerDisplay("{DebuggerDisplay,nq}")]
public readonly record struct UserId : IValueObject<ulong>
{
    public ulong Value { get; }

    public bool IsEmpty => Value is 0UL;

    public UserId(ulong value)
    {
        if (value is 0UL)
        {
            throw new InvalidIdentifierException(nameof(value), "UserId cannot be empty.");
        }

        Value = value;
    }

    public static implicit operator ulong(UserId id) => id.Value;

    public static explicit operator UserId(ulong value) => new(value);

    public override string ToString() => Value.ToString(CultureInfo.InvariantCulture);

    private string DebuggerDisplay => $"UserId: {Value}";
}
