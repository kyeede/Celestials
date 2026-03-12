namespace Celestials.Core.ValueObjects.Identifiers;

using System.Diagnostics;
using System.Globalization;
using Celestials.Core.Contracts;

[DebuggerDisplay("{DebuggerDisplay,nq}")]
public readonly record struct RoleId : IStronglyTyped<RoleId, ulong>
{
    public ulong Value
    {
        get
        {
            if (field is 0UL)
            {
                throw new InvalidOperationException("RoleId is not initialized.");
            }

            return field;
        }
    }

    public RoleId(ulong value)
    {
        if (value is 0UL)
        {
            throw new ArgumentException("RoleId cannot be empty.", nameof(value));
        }

        Value = value;
    }

    public static RoleId Empty => default;

    public static implicit operator ulong(RoleId id) => id.Value;

    public static explicit operator RoleId(ulong value) => new(value);

    public override string ToString() => Value.ToString(CultureInfo.InvariantCulture);

    private string DebuggerDisplay => $"{Value}";
}
