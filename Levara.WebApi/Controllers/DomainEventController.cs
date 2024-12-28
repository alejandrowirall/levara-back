using Levara.Domain.Authentication;
using Levara.Shared.Domain.Bus.Events;
using Levara.Shared.Infrastructure.Bus.Events;
using Levara.WebApi.Infrastructure.Attributes;
using Microsoft.AspNetCore.Mvc;

namespace Levara.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AuthorizeAnyRoles(Roles.Admin)]
    public class DomainEventController : ControllerBase
    {
        private readonly DomainEventJsonDeserializer _domainEventJsonDeserializer;
        private readonly IServiceProvider _serviceProvider;
        public DomainEventController(DomainEventJsonDeserializer domainEventJsonDeserializer,
            IServiceProvider serviceProvider)
        {
            _domainEventJsonDeserializer = domainEventJsonDeserializer;
            _serviceProvider = serviceProvider;
        }


        [HttpPost]
        public async Task<IActionResult> Process(object request)
        {

            var domainEvent = _domainEventJsonDeserializer.Deserialize(request.ToString());
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
