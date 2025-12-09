using Levara.Shared.Results;
using System.Threading.Tasks;

namespace Levara.Shared.Domain.Bus.Events;

public interface IDomainEventSubscriber<TDomain> where TDomain : IDomainEvent
{

    Task<OperationResult<bool>> On(TDomain domainEvent);
}
