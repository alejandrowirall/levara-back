
using Levara.Domain.DAL.Repositories;
using Levara.Domain.Models;
using Levara.Shared.Domain.Bus.Queries;
using Levara.Shared.Results;

namespace Levara.Application.Maintenances.GetByGrid;

public class GetMaintenanceByGridQueryHandler : IQueryHandler<GetMaintenanceByGridQuery, PagedList<GetMaintenanceByGridQueryResponse>>
{
    private readonly IMaintenanceRepository _maintenanceRepository;
    public GetMaintenanceByGridQueryHandler(ITransactionRepository transactionRepository, IMaintenanceRepository maintenanceRepository) 
    {
        _maintenanceRepository = maintenanceRepository;
    }
    public async Task<OperationResult<PagedList<GetMaintenanceByGridQueryResponse>>> Handle(GetMaintenanceByGridQuery query)
    {

        var maintananceQuery = _maintenanceRepository.GetAllWithMaintananceType()
                                .Where(t => (query.PropertyId.HasValue && t.PropertyId == query.PropertyId.Value) ||
                                (query.OwnerId.HasValue && t.Property.OwnerId == query.OwnerId.Value))
                                .OrderByDescending(p => p.CreatedDate)
                                .Select(p => new GetMaintenanceByGridQueryResponse(p));

    

        var response = await _maintenanceRepository.ToListPagedAsync(maintananceQuery, query.PageNumber!.Value, query.PageSize!.Value);


        return OperationResult<PagedList<GetMaintenanceByGridQueryResponse>>.SuccessResult(response);

    }
}


