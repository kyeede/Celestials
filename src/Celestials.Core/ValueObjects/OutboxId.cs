namespace Celestials.Core.ValueObjects;

using System.Diagnostics;
using System.Globalization;
using Celestials.Core.Contracts;
using Celestials.Core.Exceptions;

[DebuggerDisplay("{DebuggerDisplay,nq}")]
public readonly record struct OutboxId : IValueObject<Guid>
{
    public Guid Value { get; }

    public bool IsEmpty => Value == Guid.Empty;

    public OutboxId(Guid value)
    {
        if (value == Guid.Empty)
        {
            throw new InvalidIdentifierException(nameof(value), "OutboxId cannot be empty.");
        }

        Value = value;
    }

    public static OutboxId NewId() => new(Guid.NewGuid());

    public static implicit operator Guid(OutboxId id) => id.Value;

    public static explicit operator OutboxId(Guid value) => new(value);

    public override string ToString() => Value.ToString("D", CultureInfo.InvariantCulture);

    private string DebuggerDisplay => $"OutboxId: {Value}";
}
