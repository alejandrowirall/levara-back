using Levara.Domain.Contexts;
using Levara.Domain.DAL.Repositories;
using Levara.Domain.Models;
using Levara.Shared.Domain.Bus.Events;

namespace Levara.DAL.Repositories;

public class DomainEventPrimitiveRepository : Repository<DomainEventPrimitive>, IDomainEventPrimitiveRepository
{
    public DomainEventPrimitiveRepository(UnitOfWork unitOfWork,
        IUserContext userContext) : base(unitOfWork, userContext)
    {

    }

    public async Task AddAsync(List<DomainEvent> domainEvents)
    {
        List<DomainEventPrimitive> domainEventPrimitives = new();
        foreach (var domainEvent in domainEvents)
        {
            domainEventPrimitives.Add(new DomainEventPrimitive(domainEvent));
        }

        await AddAsync(domainEventPrimitives);
    }
}
