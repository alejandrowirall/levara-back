
using System.ComponentModel;

namespace Levara.Domain.Enum;

public enum TransactionStatus
{
    [Description("Unpaid")]
    Unpaid = 1,

    [Description("PartiallyPaid")]
    PartiallyPaid = 2,

    [Description("Paid")]
    Paid = 3,

    [Description("Confirmed")]
    Confirmed = 4,
}
