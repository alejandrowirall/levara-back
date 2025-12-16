using Levara.Domain.DAL;
using Levara.Shared.Domain.Bus.Commands;
using Levara.Shared.Results;

namespace Levara.Application.MaintenancesCharges.Create;

public class CreateMaintenanceChargeCommandHandler : ICommandHandler<CreateMaintenanceChargeCommand, CreateMaintenanceChargeCommandResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly CreateMaintenanceChargeCommandService _createMaintenanceChargeCommandService;
    public CreateMaintenanceChargeCommandHandler(IUnitOfWork unitOfWork,
        CreateMaintenanceChargeCommandService createMaintenanceChargeCommandService) 
    {
        _unitOfWork = unitOfWork;
        _createMaintenanceChargeCommandService = createMaintenanceChargeCommandService;
    }
    public async Task<OperationResult<CreateMaintenanceChargeCommandResponse>> Handle(CreateMaintenanceChargeCommand command)
    {
        var response = await _unitOfWork.ExecuteAsTransactionAsync(async () =>
        {
            var response = await _createMaintenanceChargeCommandService.Handle(command);
            return response;
        });

        return response;

    }
}
