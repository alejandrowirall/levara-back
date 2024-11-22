
namespace Levara.Domain.Contexts;

public interface IContextIdentifier
{
    public string CorrelationId { get; }

    public string IdempotencyId { get; }

    public string RequestId { get; }

}
