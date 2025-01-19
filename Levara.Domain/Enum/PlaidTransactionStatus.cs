
using System.ComponentModel;

namespace Levara.Domain.Enum;

public enum PlaidTransactionStatus
{
    [Description("Created")]
    Created = 1,

    [Description("NeedReview")]
    NeedReview = 2,

    [Description("PersonalPayment")]
    PersonalPayment = 3,

    [Description("FeeBank")]
    FeeBank = 4,

    [Description("RelevantTransaction")]
    RelevantTransaction = 5
}
