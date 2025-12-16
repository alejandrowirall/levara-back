using System.ComponentModel;

namespace Levara.Domain.Enum;

public enum ReconciliationTriggerType
{
    [Description("Manual")]
    Manual = 0,

    [Description("PlaidSync")]
    PlaidSync = 1,

    [Description("Scheduled")]
    Scheduled = 2
}
