
namespace Levara.Shared.Domain.Bus.Events;

public interface IDomainEventSubscriberBase
{
    Task On(DomainEvent @event);
}
