

namespace Levara.Shared.Domain.Bus.Events;

public interface IDomainEvent
{
    public Guid EventId { get; set; }
    public string Name { get; set; }
    public int? EntityId { get; set; }
    public DateTime OccurredOn { get; set; }
    public Dictionary<string, object> Data { get; set; }
}
