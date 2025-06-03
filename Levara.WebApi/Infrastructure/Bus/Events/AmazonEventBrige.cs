using Amazon.EventBridge;
using Amazon.EventBridge.Model;
using Levara.Shared.Domain.Bus.Events;
using Newtonsoft.Json;

namespace Levara.WebApi.Infrastructure.Bus.Events;

public class AmazonEventBrige : IEventBus
{
    private readonly IAmazonEventBridge _eventBridgeClient;
    private readonly ILogger<AmazonEventBrige> _logger;

    private const string EventBusName = "default";
    public AmazonEventBrige(IAmazonEventBridge eventBridgeClient,
        ILogger<AmazonEventBrige> logger)
    {
        _eventBridgeClient = eventBridgeClient;
        _logger = logger;
    }

    public async Task PublishAsync(List<IDomainEvent> domainEvents)
    {

        if (domainEvents == null || !domainEvents.Any())
            return;


        var batches = domainEvents.Select((x, i) => new { Index = i, Value = x })
                                  .GroupBy(x => x.Index / 10)
                                  .Select(x => x.Select(v => v.Value).ToList());

        foreach (var batch in batches)
        {
            await PublishBatchAsync(batch);
        }
    }

    private async Task PublishBatchAsync(List<IDomainEvent> domainEvents)
    {
        try
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
                _logger.LogError("Failed to publish some events. FailedEntryCount: {FailedEntryCount}", response.FailedEntryCount);
                return;
            }

            _logger.LogInformation("Successfully published {EventCount} events to Amazon EventBridge.", entries.Count);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while publishing events to Amazon EventBridge.");

        }
    }
}
