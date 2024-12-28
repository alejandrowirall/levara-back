using Levara.Domain.Models;
using Levara.Shared.Domain.Bus.Events;

namespace Levara.Domain.DAL.Repositories;

public interface IDomainEventPrimitiveRepository : IRepository<DomainEventPrimitive>
{
    Task AddAsync(List<DomainEvent> domainEvents);
}
