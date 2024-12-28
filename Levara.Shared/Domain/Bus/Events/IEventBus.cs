
namespace Levara.Shared.Domain.Bus.Events;

public interface IEventBus
{
    Task PublishAsync(List<DomainEvent> events);
}
