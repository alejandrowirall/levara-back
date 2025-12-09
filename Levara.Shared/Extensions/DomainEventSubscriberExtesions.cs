using Levara.Shared.Domain.Bus.Events;
using Levara.Shared.Infrastructure.Bus.Commands;
using Levara.Shared.Infrastructure.Bus.Events;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Levara.Shared.Extensions;

public static class DomainEventSubscriberExtesions
{
    public static IServiceCollection AddSubscriberServices(this IServiceCollection services,
    Assembly assembly)
    {
        var eventsType = AppDomain.CurrentDomain.GetAssemblies()
                                                .SelectMany(x => x.GetTypes())
                                                .Where(x => !x.IsAbstract && typeof(IDomainEvent).IsAssignableFrom(x)).ToList();

        foreach (var eventType in eventsType ?? Enumerable.Empty<Type>())
        {
            var subscriberType = typeof(IDomainEventSubscriber<>).MakeGenericType(eventType);

            var subscribersType = assembly.ExportedTypes.Select(t => t.GetTypeInfo())
                                                        .Where(t => t.IsClass && !t.IsAbstract && subscriberType.IsAssignableFrom(t)).ToList();

            foreach (var subsType in subscribersType ?? Enumerable.Empty<Type>())
            {
                services.AddScoped(subsType);
                services.AddScoped(subscriberType, subsType);
            }
        }

        services.AddSingleton<DomainEventsInformation>();
        services.AddSingleton<DomainEventJsonDeserializer>();
        services.AddScoped<IDomainEventConsumer, DomainEventConsumer>();

        return services;
    }
}
