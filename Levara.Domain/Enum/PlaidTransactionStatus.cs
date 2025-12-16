
using System.ComponentModel;

namespace Levara.Domain.Enum;

public enum PlaidTransactionStatus
{
    [Description("Created")]
    Created = 0,

    [Description("NoMatch")]
    NoMatch = 1,

    [Description("NeedReview")]
    NeedReview = 2,

    [Description("PersonalPayment")]
    PersonalPayment = 3,

    [Description("FeeBank")]
    FeeBank = 4,

    [Description("Reconciled")]
    Reconciled = 5,

    [Description("AutoReconciled")]
    AutoReconciled = 6,

    [Description("Error")]
    Error = 7
}
