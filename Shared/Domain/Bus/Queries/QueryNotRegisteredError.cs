namespace Levara.Shared.Domain.Bus.Queries;

public class QueryNotRegisteredError<TResponse> : Exception
{
    public QueryNotRegisteredError(Query<TResponse> query) : base(
        $"The query {query} has not a query handler associated")
    {
    }
}
