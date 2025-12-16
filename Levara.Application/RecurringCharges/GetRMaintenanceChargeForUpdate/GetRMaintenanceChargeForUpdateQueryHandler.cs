using Levara.Domain.DAL.Repositories;
using Levara.Domain.Enum;
using Levara.Shared.Domain.Bus.Queries;
using Levara.Shared.Domain.Models;
using Levara.Shared.Extensions;
using Levara.Shared.Results;

namespace Levara.Application.RecurringCharges.GetRMaintenanceChargeForUpdate;


public class GetMaintenanceChargeForUpdateQueryHandler : IQueryHandler<GetRMaintenanceChargeForUpdateQuery, GetRMaintenanceChargeForUpdateQueryResponse>
{
    private readonly IPropertyRepository _propertyRepository;
    private readonly IMaintenanceTypeRepository _maintenanceTypeRepository;

    private readonly IRecurringChargeRepository _recurringChargeRepository;

    public GetMaintenanceChargeForUpdateQueryHandler(IPropertyRepository propertyRepository,
        IMaintenanceTypeRepository maintenanceTypeRepository,
        IRecurringChargeRepository recurringChargeRepository)
    {
        _propertyRepository = propertyRepository;
        _maintenanceTypeRepository = maintenanceTypeRepository;
        _recurringChargeRepository = recurringChargeRepository;
    }
    public async Task<OperationResult<GetRMaintenanceChargeForUpdateQueryResponse>> Handle(GetRMaintenanceChargeForUpdateQuery query)
    {
        var recurringCharge = await _recurringChargeRepository.GetByIdAsync(query.Id!.Value);
        if (recurringCharge == null || !recurringCharge.MaintenanceTypeId.HasValue)
            return OperationResult<GetRMaintenanceChargeForUpdateQueryResponse>.ErrorResult(
                new ErrorDetails(404, $"RecurringCharge with id {query.Id} not found "));


        var propertyQuery = _propertyRepository.GetAllWithAddress()
                                            .Where(l => l.Id == recurringCharge.PropertyId);

        var property = await _propertyRepository.FirstOrDefaultAsync(propertyQuery);
        if (property == null)
            return OperationResult<GetRMaintenanceChargeForUpdateQueryResponse>.ErrorResult(
                new ErrorDetails(404, $"Property with id {recurringCharge.PropertyId} not found"));

        var maintenanceTypeQuery = _maintenanceTypeRepository.GetAll()
                                                             .Select(lct => new ListModel { Id = lct.Id, Text = lct.Name });

        var maintenanceTypes = await _maintenanceTypeRepository.ToListAsync(maintenanceTypeQuery);


        GetRMaintenanceChargeForUpdateQueryResponse response = new(recurringCharge,
                                                             property,
                                                             EnumExtensions.ToListModel<FrequencyType>(),
                                                             maintenanceTypes);

        return OperationResult<GetRMaintenanceChargeForUpdateQueryResponse>.SuccessResult(response);
    }
}
