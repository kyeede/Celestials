namespace Celestials.Core.ValueObjects;

using System.Diagnostics;
using System.Globalization;
using Celestials.Core.Contracts;
using Celestials.Core.Exceptions;

[DebuggerDisplay("{DebuggerDisplay,nq}")]
public readonly record struct GroupId : IValueObject<Guid>
{
    public Guid Value { get; }

    public bool IsEmpty => Value == Guid.Empty;

    public GroupId(Guid value)
    {
        if (value == Guid.Empty)
        {
            throw new InvalidIdentifierException(nameof(value), "GroupId cannot be empty.");
        }

        Value = value;
    }

    public static GroupId NewId() => new(Guid.NewGuid());

    public static implicit operator Guid(GroupId id) => id.Value;

    public static explicit operator GroupId(Guid value) => new(value);

    public override string ToString() => Value.ToString("D", CultureInfo.InvariantCulture);

    private string DebuggerDisplay => $"GroupId: {Value}";
}
