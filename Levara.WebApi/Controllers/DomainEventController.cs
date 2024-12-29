using Levara.Domain.Authentication;
using Levara.Shared.Domain.Bus.Events;
using Levara.Shared.Infrastructure.Bus.Events;
using Levara.WebApi.Infrastructure.Attributes;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace Levara.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AuthorizeAnyRoles(Roles.Admin)]
    public class DomainEventController : ControllerBase
    {
        private readonly DomainEventJsonDeserializer _domainEventJsonDeserializer;
        private readonly IServiceProvider _serviceProvider;
        private readonly ILogger<DomainEventController> _logger;
        public DomainEventController(DomainEventJsonDeserializer domainEventJsonDeserializer,
            IServiceProvider serviceProvider,
            ILogger<DomainEventController> logger)
        {
            _domainEventJsonDeserializer = domainEventJsonDeserializer;
            _serviceProvider = serviceProvider;
            _logger = logger;
        }


        [HttpPost]
        public async Task<IActionResult> Process([FromBody] EventRequest request)
        {
            _logger.LogInformation($"Request string: {request}");

            var domainEvent = _domainEventJsonDeserializer.Deserialize(request.Detail.GetRawText());
            var suscriberTypes = GetSubscriberTypes(domainEvent);
            foreach (var subscriberType in suscriberTypes)
            {
                using var scope = _serviceProvider.CreateScope();
                dynamic subscriber = scope.ServiceProvider.GetRequiredService(subscriberType);
                await subscriber.On((dynamic)domainEvent);
            }

            return Ok();
        }


        private static IEnumerable<Type> GetSubscriberTypes(DomainEvent @event)
        {
            var eventType = @event.GetType();
            var subscriberType = typeof(IDomainEventSubscriber<>).MakeGenericType(eventType);

            return AppDomain.CurrentDomain.GetAssemblies()
                                          .SelectMany(x => x.GetTypes())
                                          .Where(x => subscriberType.IsAssignableFrom(x));

        }
    }
}

public class EventRequest
{
    public string Version { get; set; }
    public string Id { get; set; }
    
    //public string DetailType { get; set; }
    public string Source { get; set; }
    public string Account { get; set; }
    public DateTime Time { get; set; }
    public string Region { get; set; }
    public List<string> Resources { get; set; }
    public JsonElement Detail { get; set; }
}
