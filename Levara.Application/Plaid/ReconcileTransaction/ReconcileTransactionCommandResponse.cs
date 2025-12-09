
using Levara.Domain.Enum;

namespace Levara.Application.Plaid.ReconcileTransaction;

public class ReconcileTransactionCommandResponse
{
    public ReconcileTransactionCommandResponse(int plaidId)
    {
        PlaidId = plaidId;
    }

    public ReconcileTransactionCommandResponse(int plaidId, TransactionType transactionType, int matchTransactionId)
    {
        PlaidId = plaidId;
        TransactionType = transactionType;
        MatchTransactionId = matchTransactionId;
    }
    public int PlaidId { get; }
    public TransactionType? TransactionType { get; }
    public int? MatchTransactionId { get; }
}
