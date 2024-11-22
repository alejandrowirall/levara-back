using Levara.Domain.Contexts;

namespace Levara.WebApi.Infrastructure.Security;

public class WebContextIdentifier : IContextIdentifier
{
    private readonly ContextIdentifier _contextIdentifier;
    public WebContextIdentifier(ContextIdentifier contextIdentifier) 
    {
        _contextIdentifier = contextIdentifier;
    }
    public string CorrelationId 
    { 
        get 
        {
            return _contextIdentifier.CorrelationId;
        } 
    }

    public string IdempotencyId 
    { 
        get 
        {
            return _contextIdentifier.IdempotencyId;
        } 
    }

    public string RequestId 
    { 
        get 
        {
            return _contextIdentifier.RequestId;
        } 
    }
}

public class ContextIdentifier
{
    public string CorrelationId { get; set; } = string.Empty;

    public string IdempotencyId { get; set; } = string.Empty;

    public string RequestId { get; set; } = string.Empty;
}


