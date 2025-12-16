using System.ComponentModel;

namespace Levara.Domain.Enum;

public enum PlaidReconciliationStatus
{
    [Description("Pending")]
    Pending = 0,

    [Description("AutoApplied")]
    AutoApplied = 1,

    [Description("UserConfirmed")]
    UserConfirmed = 2,

    [Description("Rejected")]
    Rejected = 3,

    [Description("Superseded")]
    Superseded = 4
}
