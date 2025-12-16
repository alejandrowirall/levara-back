using Levara.Domain.DAL.Repositories;
using Levara.Domain.Enum;
using Levara.Domain.Models;
using Levara.Shared.Domain.Bus.Queries;
using Levara.Shared.Domain.Models;
using Levara.Shared.Extensions;
using Levara.Shared.Results;

namespace Levara.Application.Plaid.GetForUpdate;

public class GetPlaidTransactionForUpdateQueryHandler : IQueryHandler<GetPlaidTransactionForUpdateQuery, GetPlaidTransactionForUpdateQueryResponse>
{
    private readonly IPlaidRepository _plaidRepository;
    private readonly ITransactionApplicationRepository _transactionApplicationRepository;
    private readonly IPlaidReconciliationRepository _plaidReconciliationRepository;
    public GetPlaidTransactionForUpdateQueryHandler(IPlaidRepository plaidRepository,
        ITransactionApplicationRepository transactionApplicationRepository,
        IPlaidReconciliationRepository plaidReconciliationRepository)
    {
        _plaidRepository = plaidRepository;
        _transactionApplicationRepository = transactionApplicationRepository;
        _plaidReconciliationRepository = plaidReconciliationRepository;
    }
    public async Task<OperationResult<GetPlaidTransactionForUpdateQueryResponse>> Handle(GetPlaidTransactionForUpdateQuery query)
    {
        var plaidTxQuery = _plaidRepository.GetAll()
                                           .Where(p => p.Id == query.PlaidId!.Value &&
                                                       p.OwnerBankAccount.OwnerId == query.OwnerId!);

        PlaidTransaction? plaidTx = await _plaidRepository.FirstOrDefaultAsync(plaidTxQuery);
        if (plaidTx == null)
            return OperationResult<GetPlaidTransactionForUpdateQueryResponse>.ErrorResult(new ErrorDetails(404, "Not found"));

        if (plaidTx.Status == PlaidTransactionStatus.Reconciled || plaidTx.Status == PlaidTransactionStatus.AutoReconciled)
            return await GetByRelevantTransaction(plaidTx);

        PliadTransactionUpdate pliadTransactionUpdate = new(plaidTx);

        List<ListModel> statuses = EnumExtensions.ToListModel<PlaidTransactionStatus>();

        if (plaidTx.Status != PlaidTransactionStatus.Created)
        {
            statuses = [.. statuses.Where(s => s.Id != (int)PlaidTransactionStatus.Created)];
        }

        if (plaidTx.Status != PlaidTransactionStatus.NeedReview)
        {
            statuses = [.. statuses.Where(s => s.Id != (int)PlaidTransactionStatus.NeedReview)];
        }

        if (plaidTx.Status != PlaidTransactionStatus.AutoReconciled)
        {
            statuses = [.. statuses.Where(s => s.Id != (int)PlaidTransactionStatus.AutoReconciled)];
        }

        if (plaidTx.Status != PlaidTransactionStatus.Error)
        {
            statuses = [.. statuses.Where(s => s.Id != (int)PlaidTransactionStatus.Error)];
        }

        GetPlaidTransactionForUpdateQueryResponse response = new(pliadTransactionUpdate,
                                                                 statuses);

        return OperationResult<GetPlaidTransactionForUpdateQueryResponse>.SuccessResult(response);

    }

    public async Task<OperationResult<GetPlaidTransactionForUpdateQueryResponse>> GetByRelevantTransaction(PlaidTransaction plaidTx)
    {
        PliadTransactionUpdate pliadTransactionUpdate = new(plaidTx);

        var transactionApplicationQuery = _transactionApplicationRepository.GetAllFull()
                                                                           .Where(ta => ta.Payment.PlaidTransactionId == plaidTx.Id);

        var transactionApplication = await _transactionApplicationRepository.FirstOrDefaultAsync(transactionApplicationQuery);
        if (transactionApplication == null)
            return OperationResult<GetPlaidTransactionForUpdateQueryResponse>.ErrorResult(new ErrorDetails(404, $"Not found Transaction Application by PlaidTransactionId {plaidTx.Id}"));


        var plaidReconciliation = 
            await  _plaidReconciliationRepository.FirstOrDefaultAsync(pr => pr.PlaidTransactionId == plaidTx.Id &&
                                                                            pr.TransactionId == transactionApplication.ChargeTransactionId &&
                                                                            (pr.Status == PlaidReconciliationStatus.AutoApplied || 
                                                                             pr.Status == PlaidReconciliationStatus.UserConfirmed));

        PliadTransactionCharge pliadTransactionCharge = new(transactionApplication, plaidReconciliation?.MatchPercentage);

        GetPlaidTransactionForUpdateQueryResponse response = new(pliadTransactionUpdate,
                                                                 [new() { Id = (int)plaidTx.Status, Text = EnumExtensions.GetEnumDescription(plaidTx.Status) }],
                                                                 pliadTransactionCharge);

        return OperationResult<GetPlaidTransactionForUpdateQueryResponse>.SuccessResult(response);
    }
}
