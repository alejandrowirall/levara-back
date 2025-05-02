using Amazon.EventBridge;
using Amazon.EventBridge.Model;
using Levara.Shared.Domain.Bus.Events;
using Newtonsoft.Json;

namespace Levara.WebApi.Infrastructure.Bus.Events;

public class AmazonEventBrige : IEventBus
{
    private readonly IAmazonEventBridge _eventBridgeClient;
    private const string EventBusName = "default";
    public AmazonEventBrige(IAmazonEventBridge eventBridgeClient)
    {
        _eventBridgeClient = eventBridgeClient;
    }

    public async Task PublishAsync(List<IDomainEvent> domainEvents)
    {

        List<PutEventsRequestEntry> entries = new();
        foreach (var domainEvent in domainEvents)
        {
            var serializedDomainEvent = JsonConvert.SerializeObject(domainEvent);

            PutEventsRequestEntry entry = new()
            {
                EventBusName = EventBusName,
                Source = "levara.function",
                DetailType = domainEvent.Name,
                Detail = serializedDomainEvent,
                Time = DateTime.UtcNow

            };

            entries.Add(entry);
        }

        var eventRequest = new PutEventsRequest
        {
            Entries = entries
        };

        var response = await _eventBridgeClient.PutEventsAsync(eventRequest);

        if (response.FailedEntryCount > 0)
        {
            throw new Exception("Failed to publish some events.");
        }

        Console.WriteLine("Event published successfully!");

    }
}
