
using Levara.Shared.Results;

namespace Levara.Shared.Domain.Bus.Commands;

public interface ICommandHandler<TCommand, TResponse> where TCommand : Command<TResponse>
{
    Task<OperationResult<TResponse>> Handle(TCommand command);
}
