

using Levara.Shared.Domain.Bus.Events;
using System.ComponentModel.DataAnnotations;

namespace Levara.Domain.Models;

public class DomainEventPrimitive : Entity
{
    public DomainEventPrimitive()
    {

    }

    public DomainEventPrimitive(DomainEvent domainEvent)
    {
        EventId = domainEvent.EventId;
        EntityId = domainEvent.EntityId;
        Name = domainEvent.EventName();
        Body = domainEvent.ToPrimitives();
    }

    public Guid EventId { get; set; }
    public int EntityId { get; set; }

    [Required]
    [Length(1, 200)]
    public string Name { get; set; }
    public Dictionary<string, string> Body { get; set; }
}
