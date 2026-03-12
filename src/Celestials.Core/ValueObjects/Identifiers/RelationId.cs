namespace Celestials.Core.ValueObjects.Identifiers;

using System.Diagnostics;
using System.Globalization;
using Celestials.Core.Contracts;

[DebuggerDisplay("{DebuggerDisplay,nq}")]
public readonly record struct RelationId : IStronglyTyped<RelationId, Guid>
{
    public Guid Value
    {
        get
        {
            if (field == Guid.Empty)
            {
                throw new InvalidOperationException("RelationId is not initialized.");
            }

            return field;
        }
    }

    public RelationId(Guid value)
    {
        if (value == Guid.Empty)
        {
            throw new ArgumentException("RelationId cannot be empty.", nameof(value));
        }

        Value = value;
    }

    public static RelationId Empty => default;

    public static RelationId New() => new(Guid.NewGuid());

    public static implicit operator Guid(RelationId id) => id.Value;

    public static explicit operator RelationId(Guid value) => new(value);

    public override string ToString() => Value.ToString("D", CultureInfo.InvariantCulture);

    private string DebuggerDisplay => $"{Value}";
}
