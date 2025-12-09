
namespace Levara.Shared.Domain.Bus.Events;

public class EventNotRegisteredError : Exception
{
    public EventNotRegisteredError(IDomainEvent domainEvent) : base(
        $"The event {domainEvent.Name} has not a suscriber associated")
    {
    }
}
