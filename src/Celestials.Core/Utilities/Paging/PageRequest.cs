namespace Celestials.Core.Utilities.Paging;

public sealed class PageRequest
{
    public static readonly PageRequest Default = new(1, DEFAULT_PAGE_SIZE);

    public const int MIN_PAGE_SIZE = 1;
    public const int MAX_PAGE_SIZE = 100;
    public const int DEFAULT_PAGE_SIZE = 20;

    public int PageNumber { get; }
    public int PageSize { get; }

    public int Skip => checked((PageNumber - 1) * PageSize);
    public int Take => PageSize;

    public PageRequest(int pageNumber, int pageSize)
    {
        if (pageNumber is < 1)
        {
            throw new ArgumentOutOfRangeException(nameof(pageNumber), "Page number must be greater than or equal to 1.");
        }

        if (pageSize is < MIN_PAGE_SIZE or > MAX_PAGE_SIZE)
        {
            throw new ArgumentOutOfRangeException(nameof(pageSize), $"Page size must be between {MIN_PAGE_SIZE} and {MAX_PAGE_SIZE}.");
        }

        PageNumber = pageNumber;
        PageSize = pageSize;
    }
}
