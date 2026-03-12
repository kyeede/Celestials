namespace Celestials.Core.ValueObjects.Identifiers;

using System.Diagnostics;
using System.Globalization;
using Celestials.Core.Contracts;

[DebuggerDisplay("{DebuggerDisplay,nq}")]
public readonly record struct CategoryId : IStronglyTyped<CategoryId, ulong>
{
    public ulong Value
    {
        get
        {
            if (field is 0UL)
            {
                throw new InvalidOperationException("CategoryId is not initialized.");
            }

            return field;
        }
    }

    public CategoryId(ulong value)
    {
        if (value is 0UL)
        {
            throw new ArgumentException("CategoryId cannot be empty.", nameof(value));
        }

        Value = value;
    }

    public static CategoryId Empty => default;

    public static implicit operator ulong(CategoryId id) => id.Value;

    public static explicit operator CategoryId(ulong value) => new(value);

    public override string ToString() => Value.ToString(CultureInfo.InvariantCulture);

    private string DebuggerDisplay => $"{Value}";
}
