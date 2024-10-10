using Microsoft.Extensions.DependencyInjection;
using Boilerplate.Shared.Domain.Bus.Commands;
using Boilerplate.Shared.Results;

namespace Boilerplate.Shared.Infrastructure.Bus.Commands;

public class InMemoryCommandBus : ICommandBus
{
    private readonly IServiceProvider _serviceProvider;

    public InMemoryCommandBus(IServiceProvider serviceProvider)
    {
        this._serviceProvider = serviceProvider;
    }

    public async Task<OperationResult<TResponse>> Dispatch<TResponse>(Command<TResponse> command)
    {
        using var scope = _serviceProvider.CreateScope();

        Type commandHandlerType = typeof(ICommandHandler<,>).MakeGenericType(command.GetType(), typeof(TResponse));

        dynamic handler = scope.ServiceProvider.GetService(commandHandlerType);

        if (handler == null) throw new CommandNotRegisteredError<TResponse>(command);

        return await handler.Handle((dynamic)command);
    }
}
