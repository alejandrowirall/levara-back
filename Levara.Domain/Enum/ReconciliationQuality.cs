using System.ComponentModel;

namespace Levara.Domain.Enum;

public enum ReconciliationQuality
{
    [Description("No Matches")]
    NoMatches = 0,

    [Description("Low Confidence")]
    LowConfidence = 1,      // Matches con score < 70%

    [Description("Medium Confidence")]
    MediumConfidence = 2,   // Al menos un match con score 70-89%

    [Description("High Confidence")]
    HighConfidence = 3,     // Al menos un match con score ≥ 90%

    [Description("Auto Reconciled")]
    AutoReconciled = 4      // Un único match con score ≥ 90%
}
