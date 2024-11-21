
namespace Levara.Domain.Models;

public class CursorPagedList<T>
{
    public IEnumerable<T> Items { get; }
    public int? NextCursor { get; }

    public CursorPagedList(IEnumerable<T> items, int? nextCursor)
    {
        Items = items;
        NextCursor = nextCursor;
    }
}
