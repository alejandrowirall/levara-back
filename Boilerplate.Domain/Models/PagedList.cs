namespace Boilerplate.Domain.Models;

public class PagedList<T>
{
    public int CurrentPage { get; }
    public int TotalPages { get; }
    public int PageSize { get; }
    public int TotalCount { get; }

    public bool HasPreviousPage => CurrentPage > 1;
    public bool HasNextPage => CurrentPage < TotalPages;
    public int? NextPageNumber => HasNextPage ? CurrentPage + 1 : null;
    public int? PreviousPageNumber => HasPreviousPage ? CurrentPage - 1 : null;

    public IEnumerable<T> Items { get; }

    public PagedList(IEnumerable<T> items, int count, int pageNumber, int pageSize)
    {
        TotalCount = count;
        PageSize = pageSize;
        CurrentPage = pageNumber;
        TotalPages = (int)Math.Ceiling(count / (double)pageSize);

        Items = items;
    }
}
