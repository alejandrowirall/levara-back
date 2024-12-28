using System.Threading.Tasks;

namespace Levara.Shared.Domain.Bus.Events;

public interface IDomainEventsConsumer
{
    Task Consume();
}
