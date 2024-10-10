
using Boilerplate.Shared.Results;

namespace Boilerplate.Shared.Domain.Bus.Commands;

public interface ICommandHandler<TCommand, TResponse> where TCommand : Command<TResponse>
{
    Task<OperationResult<TResponse>> Handle(TCommand command);
}
