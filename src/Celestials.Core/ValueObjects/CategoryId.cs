namespace Celestials.Core.ValueObjects;

using Celestials.Core.Contracts;

public readonly record struct CategoryId : IStronlgyTypedId<ulong>
{
    public static readonly CategoryId Empty = new(0);

    public ulong Id { get; }

    public CategoryId(ulong id)
    {
        if (id is 0UL)
        {
            throw new ArgumentException("CategoryId cannot be empty.", nameof(id));
        }

        Id = id;
    }

    public static implicit operator ulong(CategoryId categoryId) => categoryId.Id;

    public static implicit operator CategoryId(ulong id) => new(id);
}
