using Boilerplate.Shared.Results;

namespace Boilerplate.Shared.Domain.Bus.Queries;

public interface IQueryBus
{
    Task<OperationResult<TResponse>> Ask<TResponse>(Query<TResponse> request);
}
