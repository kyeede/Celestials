namespace Celestials.Core.Identifiers;

using System.Diagnostics;
using System.Globalization;
using Celestials.Core.Contracts;
using Celestials.Core.Exceptions;

[DebuggerDisplay("{DebuggerDisplay,nq}")]
public readonly record struct RelationId : IStronglyTypedId<Guid>
{
    public Guid Value { get; }

    public RelationId(Guid value)
    {
        if (value == Guid.Empty)
        {
            throw new InvalidIdentifierException(nameof(RelationId), value);
        }

        Value = value;
    }

    public static implicit operator Guid(RelationId id) => id.Value;

    public static explicit operator RelationId(Guid value) => new(value);

    public override string ToString() => Value.ToString("D", CultureInfo.InvariantCulture);

    private string DebuggerDisplay => $"{nameof(RelationId)}: {Value}";
}
