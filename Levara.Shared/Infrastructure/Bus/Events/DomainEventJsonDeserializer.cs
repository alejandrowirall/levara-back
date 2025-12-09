using Levara.Shared.Domain.Bus.Events;
using Newtonsoft.Json;


namespace Levara.Shared.Infrastructure.Bus.Events;

public class DomainEventJsonDeserializer
{
    private readonly DomainEventsInformation information;

    public DomainEventJsonDeserializer(DomainEventsInformation information)
    {
        this.information = information;
    }

    public IDomainEvent Deserialize(string body)
    {
        Dictionary<string, object> domainEventKv = JsonConvert.DeserializeObject<Dictionary<string, object>>(body);


        string nameEvent = domainEventKv.TryGetValue("Name", out var name) ? (string)name : string.Empty;
        if (string.IsNullOrEmpty(nameEvent))
        {
            nameEvent = domainEventKv.TryGetValue("name", out var nameLower) ? (string)nameLower : string.Empty;
        }

        var domainEventType = information.ForName(nameEvent);

        var domainEvent = JsonConvert.DeserializeObject(body, domainEventType);

        return (IDomainEvent)domainEvent;
    }
}
