using Levara.Shared.Domain.Bus.Events;
using System.Reflection;
using Newtonsoft.Json;


namespace Levara.Shared.Infrastructure.Bus.Events;

public class DomainEventJsonDeserializer
{
    private readonly DomainEventsInformation information;

    public DomainEventJsonDeserializer(DomainEventsInformation information)
    {
        this.information = information;
    }

    public DomainEvent Deserialize(string body)
    {
        var eventData = JsonConvert.DeserializeObject<Dictionary<string, Dictionary<string, object>>>(body);

        var data = eventData["data"];
        var attributes = JsonConvert.DeserializeObject<Dictionary<string, string>>(data["attributes"].ToString());

        var domainEventType = information.ForName((string)data["type"]);

        var instance = (DomainEvent)Activator.CreateInstance(domainEventType);

        var domainEvent = (DomainEvent)domainEventType
            .GetTypeInfo()
            .GetDeclaredMethod(nameof(DomainEvent.FromPrimitives))
            .Invoke(instance, new object[]
            {
                int.Parse(attributes["id"]),
                attributes,
                new Guid(data["id"].ToString()),
                (DateTime)data["occurred_on"]
            });

        return domainEvent;
    }
}
