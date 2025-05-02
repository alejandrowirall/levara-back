using Microsoft.Extensions.DependencyInjection;
using Levara.Shared.Domain.Bus.Events;
using Levara.Shared.Results;

namespace Levara.Shared.Infrastructure.Bus.Commands;

public class DomainEventConsumer : IDomainEventConsumer
{
    private readonly IServiceProvider _serviceProvider;

    public DomainEventConsumer(IServiceProvider serviceProvider)
    {
        this._serviceProvider = serviceProvider;
    }

    public async Task<OperationResult<bool>> Consume(IDomainEvent domainEvent)
    {
        using var scope = _serviceProvider.CreateScope();

        Type domainEventSubscriberType = typeof(IDomainEventSubscriber<>).MakeGenericType(domainEvent.GetType());

        dynamic? suscriber = scope.ServiceProvider.GetService(domainEventSubscriberType);

        if (suscriber == null) throw new EventNotRegisteredError(domainEvent);

        return await suscriber.On((dynamic)domainEvent);
    }
}
