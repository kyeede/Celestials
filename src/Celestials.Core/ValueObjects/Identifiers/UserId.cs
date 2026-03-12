namespace Celestials.Core.ValueObjects.Identifiers;

using System.Diagnostics;
using System.Globalization;
using Celestials.Core.Contracts;

[DebuggerDisplay("{DebuggerDisplay,nq}")]
public readonly record struct UserId : IStronglyTyped<UserId, ulong>
{
    public ulong Value
    {
        get
        {
            if (field is 0UL)
            {
                throw new InvalidOperationException("UserId is not initialized.");
            }

            return field;
        }
    }

    public UserId(ulong value)
    {
        if (value is 0UL)
        {
            throw new ArgumentException("UserId cannot be empty.", nameof(value));
        }

        Value = value;
    }

    public static UserId Empty => default;

    public static implicit operator ulong(UserId id) => id.Value;

    public static explicit operator UserId(ulong value) => new(value);

    public override string ToString() => Value.ToString(CultureInfo.InvariantCulture);

    private string DebuggerDisplay => $"{Value}";
}
