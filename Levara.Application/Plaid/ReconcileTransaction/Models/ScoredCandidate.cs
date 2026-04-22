namespace Levara.Application.Plaid.ReconcileTransaction.Models;

public class ScoredCandidate
{
    public ChargeCandidate Candidate { get; set; } = null!;
    public decimal Score { get; set; }
    public MatchDetails Details { get; set; } = null!;
}
