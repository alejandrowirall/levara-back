using Levara.Domain.DAL;
using Levara.Domain.DAL.Repositories;
using Levara.Domain.Models;
using Levara.Shared.Domain.Bus.Commands;
using Levara.Shared.Results;

namespace Levara.Application.RecurringCharges.CreateRLeaseCharges;

public class CreateRLeaseChargeCommandHandler : ICommandHandler<CreateRLeaseChargeCommand, CreateRLeaseChargeCommandResponse>
{
    private readonly IUnitOfWork _unitOfWork;

    private readonly ILeaseRepository _leaseRepository;
    private readonly ILeaseChargeTypeRepository _leaseChargeTypeRepository;

    private readonly IRecurringChargeRepository _recurringChargeRepository;
    
    public CreateRLeaseChargeCommandHandler(IUnitOfWork unitOfWork,
        ILeaseRepository leaseRepository,
        ILeaseChargeTypeRepository leaseChargeTypeRepository,
        IRecurringChargeRepository recurringChargeRepository)
    {
        _unitOfWork = unitOfWork;
        _leaseRepository = leaseRepository;
        _leaseChargeTypeRepository = leaseChargeTypeRepository;
        _recurringChargeRepository = recurringChargeRepository;
    }
    public async Task<OperationResult<CreateRLeaseChargeCommandResponse>> Handle(CreateRLeaseChargeCommand command)
    {
        Lease? lease = await _leaseRepository.FirstOrDefaultAsync(l => l.Id == command.LeaseId && 
                                                                       l.OwnerId == command.OwnerId);

        if (lease == null)
            return OperationResult<CreateRLeaseChargeCommandResponse>.ErrorResult(new ErrorDetails(404, $"Not found Lease with id {command.LeaseId} for Owner with id {command.OwnerId}"));

        if (!await _leaseChargeTypeRepository.AnyAsync(lct => lct.Id == command.LeaseChargeTypeId))
            return OperationResult<CreateRLeaseChargeCommandResponse>.ErrorResult(new ErrorDetails(404, $"Not found LeaseChargeType with id {command.LeaseChargeTypeId}"));

        var validationResult = ValidateBusinessRules(command, lease);
        if (!validationResult.Success)
            return validationResult;


        var newRecurringCharge = RecurringCharge.CreateForLease(
            lease.PropertyId,
            command.LeaseChargeTypeId!.Value,
            lease.Id,
            command.IsRecurrent!.Value,
            command.Amount,
            command.Frequency,
            command.StartDate,
            command.EndDate,
            command.Active!.Value,
            command.MatchTags);

        await _recurringChargeRepository.AddAsync(newRecurringCharge);
        await _unitOfWork.SaveChangesAsync();


        CreateRLeaseChargeCommandResponse response = new()
        {
            Id = newRecurringCharge.Id
        };

        return OperationResult<CreateRLeaseChargeCommandResponse>.SuccessResult(response);

    }

    private OperationResult<CreateRLeaseChargeCommandResponse> ValidateBusinessRules(CreateRLeaseChargeCommand command, Lease lease)
    {
        // Validaciones específicas para cargos recurrentes
        if (command.IsRecurrent == true)
        {
            // Validar que los campos requeridos estén presentes
            if (!command.Amount.HasValue)
                return OperationResult<CreateRLeaseChargeCommandResponse>.ErrorResult(
                    new ErrorDetails(400, "Amount is required for recurrent charges"));

            if (!command.Frequency.HasValue)
                return OperationResult<CreateRLeaseChargeCommandResponse>.ErrorResult(
                    new ErrorDetails(400, "Frequency is required for recurrent charges"));

            if (!command.StartDate.HasValue)
                return OperationResult<CreateRLeaseChargeCommandResponse>.ErrorResult(
                    new ErrorDetails(400, "StartDate is required for recurrent charges"));

            if (!command.EndDate.HasValue)
                return OperationResult<CreateRLeaseChargeCommandResponse>.ErrorResult(
                    new ErrorDetails(400, "EndDate is required for recurrent charges"));

            // Validar que StartDate < EndDate
            if (command.StartDate >= command.EndDate)
                return OperationResult<CreateRLeaseChargeCommandResponse>.ErrorResult(
                    new ErrorDetails(400, "StartDate must be before EndDate"));

            // RecurringCharge debe estar dentro del período del Lease
            if (command.StartDate < lease.DateFrom)
                return OperationResult<CreateRLeaseChargeCommandResponse>.ErrorResult(
                    new ErrorDetails(400, $"Recurring charge StartDate ({command.StartDate:yyyy-MM-dd}) cannot be before lease StartDate ({lease.DateFrom:yyyy-MM-dd})"));

            if (command.EndDate > lease.DateTo)
                return OperationResult<CreateRLeaseChargeCommandResponse>.ErrorResult(
                    new ErrorDetails(400, $"Recurring charge EndDate ({command.EndDate:yyyy-MM-dd}) cannot be after lease EndDate ({lease.DateTo:yyyy-MM-dd})"));
        }
        else
        {
            // Validaciones para cargos NO recurrentes (solo matching)
            if (command.MatchTags == null || !command.MatchTags.Any())
                return OperationResult<CreateRLeaseChargeCommandResponse>.ErrorResult(
                    new ErrorDetails(400, "At least one MatchTag is required for non-recurrent charges"));
        }

        return OperationResult<CreateRLeaseChargeCommandResponse>.SuccessResult(new());
    }
}
