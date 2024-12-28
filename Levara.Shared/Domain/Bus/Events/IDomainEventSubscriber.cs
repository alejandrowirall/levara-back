using System.Threading.Tasks;

namespace Levara.Shared.Domain.Bus.Events;

public interface IDomainEventSubscriber<TDomain> where TDomain : DomainEvent
{

    Task On(TDomain domainEvent);
}
