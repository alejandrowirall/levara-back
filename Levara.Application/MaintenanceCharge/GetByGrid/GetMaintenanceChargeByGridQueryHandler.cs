using Levara.Domain.DAL.Repositories;
using Levara.Domain.Models;
using Levara.Shared.Domain.Bus.Queries;
using Levara.Shared.Results;

namespace Levara.Application.MaintenancesCharges.GetByGrid;

public class GetMaintenanceChargeByGridQueryHandler : IQueryHandler<GetMaintenanceChargeByGridQuery, PagedList<GetMaintenanceChargeByGridQueryResponse>>
{
    private readonly IMaintenanceChargeRepository _maintenanceChargeRepository;
    public GetMaintenanceChargeByGridQueryHandler(IMaintenanceChargeRepository maintenanceChargeRepository) 
    {
        _maintenanceChargeRepository = maintenanceChargeRepository;
    }
    public async Task<OperationResult<PagedList<GetMaintenanceChargeByGridQueryResponse>>> Handle(GetMaintenanceChargeByGridQuery query)
    {

        var maintenanceChargeQuery = _maintenanceChargeRepository.GetAllFull();

        if (query.PropertyId.HasValue)
            maintenanceChargeQuery = maintenanceChargeQuery.Where(t => t.Maintenance.PropertyId == query.PropertyId!.Value);

        if (query.OwnerId.HasValue)
            maintenanceChargeQuery = maintenanceChargeQuery.Where(t => t.Maintenance.Property.OwnerId == query.OwnerId!.Value);

        if (query.Statuses != null && query.Statuses.Any())
            maintenanceChargeQuery = maintenanceChargeQuery.Where(t => query.Statuses.Contains(t.Status));

        var responseQuery = maintenanceChargeQuery.OrderByDescending(e => e.CreatedDate)
                                                  .Select(e => new GetMaintenanceChargeByGridQueryResponse(e));

        var response = await _maintenanceChargeRepository.ToListPagedAsync(responseQuery, query.PageNumber!.Value, query.PageSize!.Value);


        return OperationResult<PagedList<GetMaintenanceChargeByGridQueryResponse>>.SuccessResult(response);

    }
}


