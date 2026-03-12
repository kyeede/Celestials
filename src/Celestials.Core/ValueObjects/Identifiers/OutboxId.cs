namespace Celestials.Core.ValueObjects.Identifiers;

using System.Diagnostics;
using System.Globalization;
using Celestials.Core.Contracts;

[DebuggerDisplay("{DebuggerDisplay,nq}")]
public readonly record struct OutboxId : IStronglyTyped<OutboxId, Guid>
{
    public Guid Value
    {
        get
        {
            if (field == Guid.Empty)
            {
                throw new InvalidOperationException("OutboxId is not initialized.");
            }

            return field;
        }
    }

    public OutboxId(Guid value)
    {
        if (value == Guid.Empty)
        {
            throw new ArgumentException("OutboxId cannot be empty.", nameof(value));
        }

        Value = value;
    }

    public static OutboxId Empty => default;

    public static OutboxId New() => new(Guid.NewGuid());

    public static implicit operator Guid(OutboxId id) => id.Value;

    public static explicit operator OutboxId(Guid value) => new(value);

    public override string ToString() => Value.ToString("D", CultureInfo.InvariantCulture);

    private string DebuggerDisplay => $"{Value}";
}
