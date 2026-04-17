namespace Levara.Application.Plaid.ReconcileTransaction.Models;

public class MatchDetails
{
    public decimal TagScore { get; set; }
    public decimal AmountScore { get; set; }
    public List<string> MatchedTags { get; set; } = new();
    public List<string> UnmatchedTags { get; set; } = new();
    public decimal AmountDifference { get; set; }
    public decimal AmountDifferencePercent { get; set; }
    public decimal AmountPenalty { get; set; }
    public bool AmountWithinThreshold { get; set; }
}
