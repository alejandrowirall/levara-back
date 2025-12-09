using Levara.Shared.Domain.Bus.Events;

namespace Levara.Shared.Infrastructure.Bus.Events
{
    public class DomainEventsInformation
    {
        private readonly Dictionary<string, Type> IndexedDomainEvents = new Dictionary<string, Type>();

        public DomainEventsInformation()
        {
            GetDomainTypes().ForEach(eventType => IndexedDomainEvents.Add(eventType.Name, eventType));
        }

        public Type ForName(string name)
        {
            Type value;
            IndexedDomainEvents.TryGetValue(name, out value);
            return value;
        }

        public string ForClass(IDomainEvent domainEvent)
        {
            return IndexedDomainEvents.FirstOrDefault(x => x.Value.Equals(domainEvent.GetType())).Key;
        }

        private List<Type> GetDomainTypes()
        {
            var type = typeof(IDomainEvent);

            return AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(s => s.GetTypes())
                .Where(p => type.IsAssignableFrom(p) && !p.IsAbstract).ToList();
        }
    }
}
