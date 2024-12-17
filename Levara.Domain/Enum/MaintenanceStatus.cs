
using System.ComponentModel;

namespace Levara.Domain.Enum;

public enum MaintenanceStatus
{
    [Description("Pending")]
    Pending = 1,

    [Description("In Progress")]
    InProgress = 2,

    [Description("Completed")]
    Completed = 3,

    [Description("Canceled")]
    Canceled = 4
}
