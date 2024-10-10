
using Boilerplate.Shared.Results;

namespace Boilerplate.Shared.Domain.Bus.Commands;

public interface ICommandBus
{
    Task<OperationResult<TResponse>> Dispatch<TResponse>(Command<TResponse> command);
}
