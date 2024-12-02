
using System.ComponentModel;

namespace Levara.Domain.Enum;

public enum LeaseStatus
{
    [Description("UploadDocumentation")]
    UploadDocumentation = 1,

    [Description("SigningContract")]
    SigningContract = 2,

    [Description("ApplyCondo")]
    ApplyCondo = 3,

    [Description("ApproveCondo")]
    ApproveCondo = 4,

    [Description("Possession")]
    Possession = 5
}
