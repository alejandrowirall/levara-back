using Levara.Shared.Domain.Bus.Queries;
using Microsoft.Extensions.DependencyInjection;
using Levara.Shared.Results;

namespace Levara.Shared.Infrastructure.Bus.Query;

public class InMemoryQueryBus: IQueryBus
{
    private readonly IServiceProvider _serviceProvider;

    public InMemoryQueryBus(IServiceProvider serviceProvider)
    {
        this._serviceProvider = serviceProvider;
    }

    public async Task<OperationResult<TResponse>> Ask<TResponse>(Query<TResponse> request)
    {
        using var scope = _serviceProvider.CreateScope();

        Type queryHandlerType = typeof(IQueryHandler<,>).MakeGenericType(request.GetType(), typeof(TResponse));

        dynamic handler = scope.ServiceProvider.GetService(queryHandlerType);

        if (handler == null) throw new QueryNotRegisteredError<TResponse>(request);

        return await handler.Handle((dynamic)request);
    }
}
