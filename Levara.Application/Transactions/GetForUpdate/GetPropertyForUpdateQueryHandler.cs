using Levara.Domain.Contexts;
using Levara.Domain.DAL.Repositories;
using Levara.Shared.Domain.Bus.Queries;
using Levara.Shared.Results;

namespace Levara.Application.Transactions.GetForUpdate;

public class GetTransactionForUpdateQueryHandler : IQueryHandler<GetTransactionForUpdateQuery, GetTransactionForUpdateQueryResponse>
{
    private readonly IUserContext _userContext;
    private readonly ITransactionRepository _transactionRepository;
    public GetTransactionForUpdateQueryHandler(IUserContext userContext,
        ITransactionRepository transactionRepository) 
    {
        _userContext = userContext;
        _transactionRepository = transactionRepository;
    }
    public async Task<OperationResult<GetTransactionForUpdateQueryResponse>> Handle(GetTransactionForUpdateQuery query)
    {
        var transactionQuery = _transactionRepository.GetAll()
                                               .Where(p => p.Id == query.Id!.Value)
                                               .Select(p => new TransactionUpdateQueryResponse(p));

        TransactionUpdateQueryResponse? transaction = await _transactionRepository.FirstOrDefaultAsync(transactionQuery);
        if (transaction == null)
            return OperationResult<GetTransactionForUpdateQueryResponse>.ErrorResult(new ErrorDetails(404, "Not found"));

        if (_userContext.IsOwner && transaction.OwnerId != _userContext.OwnerId!.Value)
            return OperationResult<GetTransactionForUpdateQueryResponse>.ErrorResult(new ErrorDetails(403, "The owner does not have permissions to update this property."));

        GetTransactionForUpdateQueryResponse response = new(transaction);
        
        return OperationResult<GetTransactionForUpdateQueryResponse>.SuccessResult(response);

    }
}
