using Boilerplate.Shared.Results;

namespace Boilerplate.Shared.Domain.Bus.Queries;

public interface IQueryHandler<TQuery, TResponse> where TQuery : Query<TResponse>
{
    Task<OperationResult<TResponse>> Handle(TQuery query);
}
