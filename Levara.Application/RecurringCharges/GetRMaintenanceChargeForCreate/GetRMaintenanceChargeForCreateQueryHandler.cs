using Levara.Domain.DAL.Repositories;
using Levara.Domain.Enum;
using Levara.Shared.Domain.Bus.Queries;
using Levara.Shared.Domain.Models;
using Levara.Shared.Extensions;
using Levara.Shared.Results;

namespace Levara.Application.RecurringCharges.GetRMaintenanceChargeForCreate;


public class GetMaintenanceChargeForCreateQueryHandler : IQueryHandler<GetRMaintenanceChargeForCreateQuery, GetRMaintenanceChargeForCreateQueryResponse>
{
    private readonly IPropertyRepository _propertyRepository;
    private readonly IMaintenanceTypeRepository _maintenanceTypeRepository;
    public GetMaintenanceChargeForCreateQueryHandler(IPropertyRepository propertyRepository,
        IMaintenanceTypeRepository maintenanceTypeRepository)
    {
        _propertyRepository = propertyRepository;
        _maintenanceTypeRepository = maintenanceTypeRepository;
    }
    public async Task<OperationResult<GetRMaintenanceChargeForCreateQueryResponse>> Handle(GetRMaintenanceChargeForCreateQuery query)
    {
        var propertyQuery = _propertyRepository.GetAllWithAddress()
                                               .Where(l => l.Id == query.PropertyId);

        var property = await _propertyRepository.FirstOrDefaultAsync(propertyQuery);
        if (property == null)
            return OperationResult<GetRMaintenanceChargeForCreateQueryResponse>.ErrorResult(
                new ErrorDetails(404, $"Property with id {query.PropertyId} not found"));

        var maintenanceTypeQuery = _maintenanceTypeRepository.GetAll()
                                                             .Select(lct => new ListModel { Id = lct.Id, Text = lct.Name });

        var maintenanceTypes = await _maintenanceTypeRepository.ToListAsync(maintenanceTypeQuery);


        GetRMaintenanceChargeForCreateQueryResponse response = new(property,
                                                             EnumExtensions.ToListModel<FrequencyType>(),
                                                             maintenanceTypes);

        return OperationResult<GetRMaintenanceChargeForCreateQueryResponse>.SuccessResult(response);
    }
}
