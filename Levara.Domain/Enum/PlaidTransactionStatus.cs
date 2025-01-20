
using System.ComponentModel;

namespace Levara.Domain.Enum;

public enum PlaidTransactionStatus
{
    [Description("Created")]
    Created = 0,

    [Description("NeedReview")]
    NeedReview = 1,

    [Description("PersonalPayment")]
    PersonalPayment = 2,

    [Description("FeeBank")]
    FeeBank = 3,

    [Description("RelevantTransaction")]
    RelevantTransaction = 4
}
