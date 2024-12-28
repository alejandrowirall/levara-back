
using Levara.Domain.DAL.Repositories;
using Levara.Domain.Models;
using Levara.Shared.Domain.Bus.Events;
using Levara.Shared.Infrastructure.Bus.Events;


namespace Levara.WebApi.Infrastructure.Bus.Events
{
    public class AmazonEventBrige : IEventBus
    {
        private readonly IDomainEventPrimitiveRepository _domainEventPrimitiveRepository;
        private List<DomainEvent> _domainEvents;
        public AmazonEventBrige(IDomainEventPrimitiveRepository domainEventPrimitiveRepository)
        {
            _domainEventPrimitiveRepository = domainEventPrimitiveRepository;
            _domainEvents = new();
        }
        public void Add(List<DomainEvent> events)
        {
            if (events == null)
                return;

            if (_domainEvents == null)
                _domainEvents = new List<DomainEvent>();

            _domainEvents = _domainEvents.Concat(events).ToList();
        }

        public async Task SaveAsync()
        {
            if (_domainEvents == null)
                return;

            List<DomainEventPrimitive> domainEventPrimitives = new();
            foreach (var domainEvent in _domainEvents)
            {
                domainEventPrimitives.Add(new DomainEventPrimitive(domainEvent));
            }

            await _domainEventPrimitiveRepository.AddAsync(domainEventPrimitives);
        }

        public async Task PublishAsync(List<DomainEvent> domainEvents)
        {
            foreach (var domainEvent in domainEvents)
            {
                var serializedDomainEvent = DomainEventJsonSerializer.Serialize(domainEvent);
                Console.WriteLine(serializedDomainEvent);
            }
            
        }
    }
}
