
using System.ComponentModel;

namespace Levara.Domain.Enum;

public enum TransactionStatus
{
    [Description("Incoming")]
    Incoming = 1,

    [Description("Verified")]
    Verified = 2,

    [Description("Dismiss")]
    dismiss = 3,

    [Description("Pending Verification")]
    PendingVerification = 4
}
