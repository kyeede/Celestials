namespace Celestials.Core.Utilities.Paging;

public sealed class PagedResult<T>
{
    public IReadOnlyList<T> Items { get; }

    public int TotalCount { get; }
    public int PageNumber { get; }
    public int PageSize { get; }

    public int TotalPages => (TotalCount + PageSize - 1) / PageSize;
    public bool HasPrevious => PageNumber is > 1;
    public bool HasNext => PageNumber < TotalPages;

    public PagedResult(IReadOnlyList<T> items, int totalCount, PageRequest request)
    {
        ArgumentNullException.ThrowIfNull(items, nameof(items));

        Items = items;
        TotalCount = totalCount;
        PageNumber = request.PageNumber;
        PageSize = request.PageSize;
    }

    public static PagedResult<T> Empty(PageRequest request)
    {
        return new([], 0, request);
    }
}
