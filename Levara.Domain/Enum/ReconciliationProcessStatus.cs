using System.ComponentModel;

namespace Levara.Domain.Enum;

public enum ReconciliationProcessStatus
{
    [Description("Pending")]
    Pending = 0,

    [Description("Processing")]
    Processing = 1,

    [Description("Completed")]
    Completed = 2,

    [Description("Failed")]
    Failed = 3,

    [Description("Cancelled")]
    Cancelled = 4
}
