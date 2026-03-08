namespace Celestials.Core.Identifiers;

using System.Diagnostics;
using System.Globalization;
using Celestials.Core.Contracts;
using Celestials.Core.Exceptions;

[DebuggerDisplay("{DebuggerDisplay,nq}")]
public readonly record struct PermissionId : IStronglyTypedId<Guid>
{
    public Guid Value { get; }

    public PermissionId(Guid value)
    {
        if (value == Guid.Empty)
        {
            throw new InvalidIdentifierException(nameof(PermissionId), value);
        }

        Value = value;
    }

    public static implicit operator Guid(PermissionId id) => id.Value;

    public static explicit operator PermissionId(Guid value) => new(value);

    public override string ToString() => Value.ToString("D", CultureInfo.InvariantCulture);

    private string DebuggerDisplay => $"{nameof(PermissionId)}: {Value}";
}
