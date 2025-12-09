using Levara.Domain.DAL.Repositories;
using Levara.Shared.Domain.Bus.Queries;
using Levara.Shared.Results;

namespace Levara.Application.Plaid.GetReconcileByGrid;

public class GetReconcileByGridQueryHandler : IQueryHandler<GetReconcileByGridQuery, List<GetReconcileByGridQueryResponse>>
{
    private readonly IPlaidReconciliationRepository _plaidReconciliationRepository;

    public GetReconcileByGridQueryHandler(IPlaidReconciliationRepository plaidReconciliationRepository)
    {
        _plaidReconciliationRepository = plaidReconciliationRepository;
    }
    public async Task<OperationResult<List<GetReconcileByGridQueryResponse>>> Handle(GetReconcileByGridQuery query)
    {

        var plaidReconciliationQuery = _plaidReconciliationRepository.GetAllFull()
                                                                     .Where(pr => pr.PlaidTransactionId == query.PlaidId! &&
                                                                                  pr.PlaidTransaction.OwnerBankAccount.OwnerId == query.OwnerId!.Value);

        var plaidReconciliations = await _plaidReconciliationRepository.ToListAsync(plaidReconciliationQuery);

        List<GetReconcileByGridQueryResponse> response = new();
        foreach (var plaidReconciliation in plaidReconciliations)
        {
            response.Add(new GetReconcileByGridQueryResponse(plaidReconciliation));
        }

        return OperationResult<List<GetReconcileByGridQueryResponse>>.SuccessResult(response);
    }
}
