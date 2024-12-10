
using Levara.Domain.DAL;
using Levara.Domain.Enum;
using Levara.Shared.Extensions;
using Levara.Shared.Domain.Bus.Queries;
using Levara.Shared.Results;
using Levara.Domain.DAL.Repositories;

namespace Levara.Application.Plaid.GetForUpdate;

public class GetTransactionOwnerForUpdateQueryHandler : IQueryHandler<GetTransactionOwnerForUpdateQuery, GetTransactionOwnerForUpdateQueryResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IPlaidRepository _plaidRepository;
    public GetTransactionOwnerForUpdateQueryHandler(IUnitOfWork unitOfWork,
        IPlaidRepository plaidRepository) 
    {
        _unitOfWork = unitOfWork;
        _plaidRepository = plaidRepository;
    }
    public async Task<OperationResult<GetTransactionOwnerForUpdateQueryResponse>> Handle(GetTransactionOwnerForUpdateQuery query)
    {
        var transactionOwnerQuery = _plaidRepository.GetAll()
                                         .Where(o => o.Id == query.Id!.Value)
                                         .Select(t => new TransactionOwnerUpdateQueryResponse(t));

        TransactionOwnerUpdateQueryResponse? transactionOwner = await _plaidRepository.FirstOrDefaultAsync(transactionOwnerQuery);
        if (transactionOwner == null)
            return OperationResult<GetTransactionOwnerForUpdateQueryResponse>.ErrorResult(new ErrorDetails(404, "Not found"));

        GetTransactionOwnerForUpdateQueryResponse response = new(transactionOwner, 
                                                      EnumExtensions.ToListModel<PlaidTransactionStatus>((int)transactionOwner.Status));
        
        return OperationResult<GetTransactionOwnerForUpdateQueryResponse>.SuccessResult(response);

    }
}
