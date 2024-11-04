
using Levara.Shared.Results;

namespace Levara.Shared.Domain.Bus.Commands;

public interface ICommandBus
{
    Task<OperationResult<TResponse>> Dispatch<TResponse>(Command<TResponse> command);
}
