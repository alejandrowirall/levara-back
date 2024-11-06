using Levara.Shared.Results;

namespace Levara.Shared.Domain.Bus.Queries;

public interface IQueryBus
{
    Task<OperationResult<TResponse>> Ask<TResponse>(Query<TResponse> request);
}
