namespace Celestials.Core.Identifiers;

using System.Diagnostics;
using System.Globalization;
using Celestials.Core.Contracts;
using Celestials.Core.Exceptions;

[DebuggerDisplay("{DebuggerDisplay,nq}")]
public readonly record struct GroupId : IStronglyTypedId<Guid>
{
    public Guid Value { get; }

    public GroupId(Guid value)
    {
        if (value == Guid.Empty)
        {
            throw new InvalidIdentifierException(nameof(GroupId), value);
        }

        Value = value;
    }

    public static implicit operator Guid(GroupId id) => id.Value;

    public static explicit operator GroupId(Guid value) => new(value);

    public override string ToString() => Value.ToString("D", CultureInfo.InvariantCulture);

    private string DebuggerDisplay => $"{nameof(GroupId)}: {Value}";
}
