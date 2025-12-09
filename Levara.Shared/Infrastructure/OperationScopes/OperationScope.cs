
namespace Levara.Shared.Infrastructure.OperationScopes;

public enum OperationScopeType
{
    Default,
    Background
}

public class OperationScope
{
    public OperationScope()
    {
        this.Current = OperationScopeType.Default;
    }

    public OperationScopeType Current { get; set; }
}
