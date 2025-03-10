
using Levara.Domain.DAL.Repositories;
using Levara.Domain.Models;
using Levara.Shared.Domain.Bus.Queries;
using Levara.Shared.Results;

namespace Levara.Application.MaintenancePayments.GetByGrid;

public class GetMaintenancePaymentByGridQueryHandler : IQueryHandler<GetMaintenancePaymentByGridQuery, PagedList<GetMaintenancePaymentByGridQueryResponse>>
{
    private readonly ITransactionRepository _transactionRepository;
    private readonly IMaintenancePaymentRepository _maintenancePaymentRepository;
    public GetMaintenancePaymentByGridQueryHandler(ITransactionRepository transactionRepository, IMaintenancePaymentRepository maintenancePaymentRepository) 
    {
        _transactionRepository = transactionRepository;
        _maintenancePaymentRepository = maintenancePaymentRepository;
    }
    public async Task<OperationResult<PagedList<GetMaintenancePaymentByGridQueryResponse>>> Handle(GetMaintenancePaymentByGridQuery query)
    {

        var transactionQuery = _maintenancePaymentRepository.GetAll()
                                               .Where(t => t.Maintenance.PropertyId == query.PropertyId!.Value || (t.Maintenance.Property.OwnerId == query.OwnerId!.Value))
                                               .OrderByDescending(p => p.CreatedDate)
                                               .Select(p => new GetMaintenancePaymentByGridQueryResponse(p));

        var response = await _transactionRepository.ToListPagedAsync(transactionQuery, query.PageNumber!.Value, query.PageSize!.Value);


        return OperationResult<PagedList<GetMaintenancePaymentByGridQueryResponse>>.SuccessResult(response);

    }
}


