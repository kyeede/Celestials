namespace Celestials.Core.ValueObjects;

using System.Diagnostics;
using System.Globalization;
using Celestials.Core.Contracts;
using Celestials.Core.Exceptions;

[DebuggerDisplay("{DebuggerDisplay,nq}")]
public readonly record struct RelationId : IValueObject<Guid>
{
    public Guid Value { get; }

    public bool IsEmpty => Value == Guid.Empty;

    public RelationId(Guid value)
    {
        if (value == Guid.Empty)
        {
            throw new InvalidIdentifierException(nameof(value), "RelationId cannot be empty.");
        }

        Value = value;
    }

    public static RelationId NewId() => new(Guid.NewGuid());

    public static implicit operator Guid(RelationId id) => id.Value;

    public static explicit operator RelationId(Guid value) => new(value);

    public override string ToString() => Value.ToString("D", CultureInfo.InvariantCulture);

    private string DebuggerDisplay => $"RelationId: {Value}";
}
