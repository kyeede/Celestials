namespace Celestials.Core.Identifiers;

using System.Diagnostics;
using System.Globalization;
using Celestials.Core.Contracts;
using Celestials.Core.Exceptions;

[DebuggerDisplay("{DebuggerDisplay,nq}")]
public readonly record struct RoleId : IStronglyTypedId<ulong>
{
    public ulong Value { get; }

    public RoleId(ulong value)
    {
        if (value is 0UL)
        {
            throw new InvalidIdentifierException(nameof(RoleId), value);
        }

        Value = value;
    }

    public static implicit operator ulong(RoleId id) => id.Value;

    public static explicit operator RoleId(ulong value) => new(value);

    public override string ToString() => Value.ToString(CultureInfo.InvariantCulture);

    private string DebuggerDisplay => $"{nameof(RoleId)}: {Value}";
}
