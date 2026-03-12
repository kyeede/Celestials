namespace Celestials.Core.ValueObjects.Identifiers;

using System.Diagnostics;
using System.Globalization;
using Celestials.Core.Contracts;

[DebuggerDisplay("{DebuggerDisplay,nq}")]
public readonly record struct PermissionId : IStronglyTyped<PermissionId, ulong>
{
    public ulong Value
    {
        get
        {
            if (field is 0UL)
            {
                throw new InvalidOperationException("PermissionId is not initialized.");
            }

            return field;
        }
    }

    public PermissionId(ulong value)
    {
        if (value is 0UL)
        {
            throw new ArgumentException("PermissionId cannot be empty.", nameof(value));
        }

        Value = value;
    }

    public static PermissionId Empty => default;

    public static implicit operator ulong(PermissionId id) => id.Value;

    public static explicit operator PermissionId(ulong value) => new(value);

    public override string ToString() => Value.ToString(CultureInfo.InvariantCulture);

    private string DebuggerDisplay => $"{Value}";
}
