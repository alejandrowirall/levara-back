
using Levara.Shared.Results;

namespace Levara.Shared.Domain.Bus.Events;

public interface IDomainEventConsumer
{
    Task<OperationResult<bool>> Consume(IDomainEvent domainEvent);
}
