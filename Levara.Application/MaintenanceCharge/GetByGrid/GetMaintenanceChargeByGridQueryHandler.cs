
using Levara.Domain.DAL.Repositories;
using Levara.Domain.Models;
using Levara.Shared.Domain.Bus.Queries;
using Levara.Shared.Results;

namespace Levara.Application.MaintenancesCharges.GetByGrid;

public class GetMaintenanceChargeByGridQueryHandler : IQueryHandler<GetMaintenanceChargeByGridQuery, PagedList<GetMaintenanceChargeByGridQueryResponse>>
{
    private readonly ITransactionRepository _transactionRepository;
    private readonly IMaintenanceChargeRepository _maintenanceChargeRepository;
    public GetMaintenanceChargeByGridQueryHandler(ITransactionRepository transactionRepository, IMaintenanceChargeRepository maintenanceChargeRepository) 
    {
        _transactionRepository = transactionRepository;
        _maintenanceChargeRepository = maintenanceChargeRepository;
    }
    public async Task<OperationResult<PagedList<GetMaintenanceChargeByGridQueryResponse>>> Handle(GetMaintenanceChargeByGridQuery query)
    {

        var transactionQuery = _maintenanceChargeRepository.GetAll()
                                               .Where(t => t.Maintenance.PropertyId == query.PropertyId!.Value || (t.Maintenance.Property.OwnerId == query.OwnerId!.Value))
                                               .OrderByDescending(p => p.CreatedDate)
                                               .Select(p => new GetMaintenanceChargeByGridQueryResponse(p));

        var response = await _transactionRepository.ToListPagedAsync(transactionQuery, query.PageNumber!.Value, query.PageSize!.Value);


        return OperationResult<PagedList<GetMaintenanceChargeByGridQueryResponse>>.SuccessResult(response);

    }
}


