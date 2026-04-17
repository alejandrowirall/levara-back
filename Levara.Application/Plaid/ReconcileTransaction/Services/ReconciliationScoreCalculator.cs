using Levara.Application.Plaid.ReconcileTransaction.Models;
using Levara.Domain.Models;
using Newtonsoft.Json;

namespace Levara.Application.Plaid.ReconcileTransaction.Services;

public class ReconciliationScoreCalculator
{
    public const decimal SCORE_THRESHOLD = 50m;
    public const decimal AUTO_APPLY_THRESHOLD = 90m;
    public const decimal AMOUNT_TOLERANCE_PERCENT = 10m;
    public const decimal EXACT_TAG_SCORE = 50m;
    public const decimal EXACT_AMOUNT_SCORE = 50m;
    public const int TOP_CANDIDATES_COUNT = 5;
    public const int MAX_RECONCILIATION_PASSES = 3;

    public decimal CalculateMatchScore(PlaidTransaction plaidTx, ChargeCandidate candidate, out MatchDetails details)
    {
        details = new MatchDetails();

        // 1. Score de Tags (máx 50%)
        var tags = candidate.MatchTags ?? new List<string>();
        if (tags.Count > 0)
        {
            var matchedTags = tags.Where(tag =>
                plaidTx.Description.Contains(tag, StringComparison.OrdinalIgnoreCase)).ToList();

            details.MatchedTags = matchedTags;
            details.UnmatchedTags = tags.Except(matchedTags).ToList();

            if (matchedTags.Count == tags.Count)
                details.TagScore = EXACT_TAG_SCORE;
            else if (matchedTags.Count > 0)
                details.TagScore = (matchedTags.Count / (decimal)tags.Count) * EXACT_TAG_SCORE;
        }

        // 2. Score de Amount (máx 50%, solo si candidate tiene Amount)
        if (candidate.Amount.HasValue)
        {
            var expectedAmount = Math.Abs(candidate.Amount.Value);
            var actualAmount = Math.Abs(plaidTx.Amount);

            details.AmountDifference = Math.Abs(expectedAmount - actualAmount);
            details.AmountDifferencePercent = expectedAmount > 0
                ? (details.AmountDifference / expectedAmount) * 100
                : 0;

            if (details.AmountDifference == 0)
            {
                details.AmountScore = EXACT_AMOUNT_SCORE;
                details.AmountWithinThreshold = true;
            }
            else if (details.AmountDifferencePercent <= AMOUNT_TOLERANCE_PERCENT)
            {
                details.AmountWithinThreshold = true;
                details.AmountPenalty = (details.AmountDifferencePercent / AMOUNT_TOLERANCE_PERCENT) * 10m;
                details.AmountScore = EXACT_AMOUNT_SCORE - details.AmountPenalty;
            }
            else
            {
                details.AmountWithinThreshold = false;
                details.AmountScore = 0m;
                details.AmountPenalty = EXACT_AMOUNT_SCORE;
            }

            return details.TagScore + details.AmountScore;
        }
        else
        {
            // Sin Amount → matching puro por tags (0-100%)
            details.AmountScore = 0m;
            details.AmountWithinThreshold = false;
            return details.TagScore * 2;
        }
    }

    public PlaidReconciliation CreatePlaidReconciliation(PlaidTransaction plaidTx, ScoredCandidate scoredCandidate)
    {
        var candidate = scoredCandidate.Candidate;
        var details = scoredCandidate.Details;

        return new PlaidReconciliation
        {
            PlaidTransactionId = plaidTx.Id,
            RecurringChargeId = candidate.RecurringChargeId,
            TransactionId = candidate.TransactionId,
            MatchPercentage = scoredCandidate.Score,
            TagMatchScore = details.TagScore,
            AmountMatchScore = details.AmountScore,
            ExpectedAmount = candidate.Amount ?? plaidTx.Amount,
            ActualAmount = plaidTx.Amount,
            AmountDifference = details.AmountDifference,
            AmountDifferencePercent = details.AmountDifferencePercent,
            AmountThreshold = AMOUNT_TOLERANCE_PERCENT,
            AmountPenalty = details.AmountPenalty,
            AmountWithinThreshold = details.AmountWithinThreshold,
            ConfiguredTags = JsonConvert.SerializeObject(candidate.MatchTags ?? new List<string>()),
            MatchedTagsList = JsonConvert.SerializeObject(details.MatchedTags),
            UnmatchedTagsList = JsonConvert.SerializeObject(details.UnmatchedTags),
            PlaidDescription = plaidTx.Description,
            HasExactAmountMatch = details.AmountScore == EXACT_AMOUNT_SCORE,
            HasExactTagMatch = details.TagScore == EXACT_TAG_SCORE,
            TagsMatched = details.MatchedTags.Count,
            TotalTags = candidate.MatchTags?.Count ?? 0,
            MatchReason = GetMatchReason(details),
            MatchedDescription = candidate.Description,
            MatchedAmount = candidate.Amount ?? plaidTx.Amount,
            MatchedDate = candidate.ChargeDate,
            RecurringChargeName = candidate.RecurringChargeId.HasValue
                ? $"RC-{candidate.RecurringChargeId}"
                : $"TX-{candidate.TransactionId}"
        };
    }

    public List<ScoredCandidate> ScoreAndFilter(PlaidTransaction plaidTx, List<ChargeCandidate> candidates)
    {
        return candidates
            .Select(candidate => new ScoredCandidate
            {
                Candidate = candidate,
                Score = CalculateMatchScore(plaidTx, candidate, out var details),
                Details = details
            })
            .Where(sc => sc.Score >= SCORE_THRESHOLD)
            .OrderByDescending(sc => sc.Score)
            .ThenBy(sc => sc.Candidate.ChargeDate)
            .ToList();
    }

    public List<ScoredCandidate> TakeTop5WithTies(List<ScoredCandidate> items)
    {
        if (items.Count <= TOP_CANDIDATES_COUNT)
            return items;

        var top5 = items.Take(TOP_CANDIDATES_COUNT).ToList();
        var fifthScore = top5.Last().Score;

        var ties = items.Skip(TOP_CANDIDATES_COUNT)
            .Where(item => item.Score == fifthScore)
            .ToList();

        top5.AddRange(ties);
        return top5;
    }

    public static string GetMatchReason(MatchDetails details)
    {
        var reasons = new List<string>();

        if (details.TagScore == EXACT_TAG_SCORE)
            reasons.Add("Exact tags");
        else if (details.TagScore > 0)
            reasons.Add($"Partial tags ({details.MatchedTags.Count}/{details.MatchedTags.Count + details.UnmatchedTags.Count})");

        if (details.AmountScore == EXACT_AMOUNT_SCORE)
            reasons.Add("exact amount");
        else if (details.AmountWithinThreshold)
            reasons.Add($"similar amount ({details.AmountDifferencePercent:F1}% diff)");

        return string.Join(" + ", reasons);
    }
}
