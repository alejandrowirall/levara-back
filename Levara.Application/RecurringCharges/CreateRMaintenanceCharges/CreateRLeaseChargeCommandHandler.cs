using Levara.Domain.DAL;
using Levara.Domain.DAL.Repositories;
using Levara.Domain.Models;
using Levara.Shared.Domain.Bus.Commands;
using Levara.Shared.Results;

namespace Levara.Application.RecurringCharges.CreateRMaintenanceCharges;

public class CreateRMaintenanceChargeCommandHandler : ICommandHandler<CreateRMaintenanceChargeCommand, CreateRMaintenanceChargeCommandResponse>
{
    private readonly IUnitOfWork _unitOfWork;

    private readonly IPropertyRepository _propertyRepository;
    private readonly IMaintenanceTypeRepository _maintenanceTypeRepository;

    private readonly IRecurringChargeRepository _recurringChargeRepository;
    
    public CreateRMaintenanceChargeCommandHandler(IUnitOfWork unitOfWork,
        IPropertyRepository propertyRepository,
        IMaintenanceTypeRepository maintenanceTypeRepository,
        IRecurringChargeRepository recurringChargeRepository)
    {
        _unitOfWork = unitOfWork;
        _propertyRepository = propertyRepository;
        _maintenanceTypeRepository = maintenanceTypeRepository;
        _recurringChargeRepository = recurringChargeRepository;
    }
    public async Task<OperationResult<CreateRMaintenanceChargeCommandResponse>> Handle(CreateRMaintenanceChargeCommand command)
    {
        Property? property = await _propertyRepository.FirstOrDefaultAsync(p => p.Id == command.PropertyId && 
                                                                                p.OwnerId == command.OwnerId);

        if (property == null)
            return OperationResult<CreateRMaintenanceChargeCommandResponse>.ErrorResult(new ErrorDetails(404, $"Not found Property with id {command.PropertyId} for Owner with id {command.OwnerId}"));

        if (!await _maintenanceTypeRepository.AnyAsync(lct => lct.Id == command.MaintenanceTypeId))
            return OperationResult<CreateRMaintenanceChargeCommandResponse>.ErrorResult(new ErrorDetails(404, $"Not found MaintenanceType with id {command.MaintenanceTypeId}"));

        var validationResult = ValidateBusinessRules(command);
        if (!validationResult.Success)
            return validationResult;


        var newRecurringCharge = RecurringCharge.CreateForMaintenance(
            property.Id,
            command.MaintenanceTypeId!.Value,
            command.IsRecurrent!.Value,
            command.Amount,
            command.Frequency,
            command.StartDate,
            command.EndDate,
            command.Active!.Value,
            command.Spliteable ?? false,
            command.MatchTags);

        await _recurringChargeRepository.AddAsync(newRecurringCharge);
        await _unitOfWork.SaveChangesAsync();


        CreateRMaintenanceChargeCommandResponse response = new()
        {
            Id = newRecurringCharge.Id
        };

        return OperationResult<CreateRMaintenanceChargeCommandResponse>.SuccessResult(response);

    }

    private OperationResult<CreateRMaintenanceChargeCommandResponse> ValidateBusinessRules(CreateRMaintenanceChargeCommand command)
    {
        if (command.IsRecurrent == true)
        {
            if (!command.Amount.HasValue)
                return OperationResult<CreateRMaintenanceChargeCommandResponse>.ErrorResult(
                    new ErrorDetails(400, "Amount is required for recurrent charges"));

            if (!command.Frequency.HasValue)
                return OperationResult<CreateRMaintenanceChargeCommandResponse>.ErrorResult(
                    new ErrorDetails(400, "Frequency is required for recurrent charges"));

            if (!command.StartDate.HasValue)
                return OperationResult<CreateRMaintenanceChargeCommandResponse>.ErrorResult(
                    new ErrorDetails(400, "StartDate is required for recurrent charges"));

            if (!command.EndDate.HasValue)
                return OperationResult<CreateRMaintenanceChargeCommandResponse>.ErrorResult(
                    new ErrorDetails(400, "EndDate is required for recurrent charges"));

            if (command.StartDate >= command.EndDate)
                return OperationResult<CreateRMaintenanceChargeCommandResponse>.ErrorResult(
                    new ErrorDetails(400, "StartDate must be before EndDate"));
        }
        else
        {
            if (command.MatchTags == null || !command.MatchTags.Any())
                return OperationResult<CreateRMaintenanceChargeCommandResponse>.ErrorResult(
                    new ErrorDetails(400, "At least one MatchTag is required for non-recurrent charges"));
        }

        return OperationResult<CreateRMaintenanceChargeCommandResponse>.SuccessResult(new());
    }
}
