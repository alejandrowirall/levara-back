
using Levara.Domain.DAL.Repositories;
using Levara.Shared.Domain.Bus.Queries;
using Levara.Shared.Results;

namespace Levara.Application.MaintenanceTypes.Get;

public class GetMaintenanceTypeQueryHandler : IQueryHandler<GetMaintenanceTypeQuery, IEnumerable<GetMaintenanceTypeQueryResponse>>
{
    private readonly IMaintenanceTypeRepository _maintenanceTypeRepository;
    public GetMaintenanceTypeQueryHandler(IMaintenanceTypeRepository maintenanceTypeRepository) 
    {
        _maintenanceTypeRepository = maintenanceTypeRepository;
    }
    public async Task<OperationResult<IEnumerable<GetMaintenanceTypeQueryResponse>>> Handle(GetMaintenanceTypeQuery query)
    {

        var maintananceTypeQuery = _maintenanceTypeRepository.GetAll()
                                                             .OrderByDescending(mt => mt.Description)
                                                             .Select(mt => new GetMaintenanceTypeQueryResponse(mt));

    

        var response = await _maintenanceTypeRepository.ToListAsync(maintananceTypeQuery);


        return OperationResult<IEnumerable<GetMaintenanceTypeQueryResponse>>.SuccessResult(response);

    }
}


