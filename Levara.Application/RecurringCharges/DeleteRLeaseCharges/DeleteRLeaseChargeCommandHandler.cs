using Levara.Domain.DAL;
using Levara.Domain.DAL.Repositories;
using Levara.Shared.Domain.Bus.Commands;
using Levara.Shared.Results;

namespace Levara.Application.RecurringCharges.DeleteRLeaseCharges;


public class DeleteRLeaseChargeCommandHandler : ICommandHandler<DeleteRLeaseChargeCommand, DeleteRLeaseChargeCommandResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IRecurringChargeRepository _recurringChargeRepository;
    private readonly IRecurringChargeInstanceRepository _rcInstanceRepository;

    public DeleteRLeaseChargeCommandHandler(IUnitOfWork unitOfWork,
        IRecurringChargeInstanceRepository rcInstanceRepository,
        IRecurringChargeRepository recurringChargeRepository)
    {
        _unitOfWork = unitOfWork;
        _recurringChargeRepository = recurringChargeRepository;
        _rcInstanceRepository = rcInstanceRepository;
    }
    public async Task<OperationResult<DeleteRLeaseChargeCommandResponse>> Handle(DeleteRLeaseChargeCommand command)
    {
        var recurringCharge = await _recurringChargeRepository.GetByIdAsync(command.Id!.Value);
        if (recurringCharge == null)
            return OperationResult<DeleteRLeaseChargeCommandResponse>.ErrorResult(
                new ErrorDetails(404, $"RecurringCharge with id {command.Id} not found "));

        var rcInstancesQuery = _rcInstanceRepository.GetAll().Where(rci => rci.RecurringChargeId == recurringCharge.Id);
        var rcInstances = await _rcInstanceRepository.ToListAsync(rcInstancesQuery);
        if (rcInstances.Any())
            return OperationResult<DeleteRLeaseChargeCommandResponse>.ErrorResult(
                new ErrorDetails(400, "It is not possible to delete the recurring charge because it already has charges created."));


        _recurringChargeRepository.Delete(recurringCharge);
        _rcInstanceRepository.Delete([.. rcInstances]);
        await _unitOfWork.SaveChangesAsync();

        return OperationResult<DeleteRLeaseChargeCommandResponse>.SuccessResult(new());
    }
}
