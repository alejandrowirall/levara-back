using Levara.Shared.Domain.Bus.Events;
using Newtonsoft.Json;

namespace Levara.Shared.Infrastructure.Bus.Events
{
    public static class DomainEventJsonSerializer
    {
        public static string Serialize(DomainEvent domainEvent)
        {
            if (domainEvent == null) return "";

            var attributes = domainEvent.ToPrimitives();

            attributes.Add("id", domainEvent.EntityId.ToString());

            return JsonConvert.SerializeObject(new Dictionary<string, Dictionary<string, object>>
            {
                {
                    "data", new Dictionary<string, object>
                    {
                        {"id", domainEvent.EventId},
                        {"type", domainEvent.EventName()},
                        {"occurred_on", domainEvent.OccurredOn},
                        {"attributes", attributes}
                    }
                },
                {"meta", new Dictionary<string, object>()}
            });
        }
    }
}
