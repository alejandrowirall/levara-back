using Levara.Domain.DAL;
using Levara.Shared.Domain.Bus.Commands;
using Levara.Shared.Results;

namespace Levara.Application.Plaid.CreateMaintenancePayment;

public class CreateMaintenancePaymentCommandHandler : ICommandHandler<CreateMaintenancePaymentCommand, CreateMaintenancePaymentCommandResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly CreateMaintenancePaymentCommandService _createMaintenancePaymentCommandService;

    public CreateMaintenancePaymentCommandHandler(IUnitOfWork unitOfWork,
        CreateMaintenancePaymentCommandService createMaintenancePaymentCommandService)
    {
        _unitOfWork = unitOfWork;
        _createMaintenancePaymentCommandService = createMaintenancePaymentCommandService;
    }
    public async Task<OperationResult<CreateMaintenancePaymentCommandResponse>> Handle(CreateMaintenancePaymentCommand command)
    {

        var response = await _unitOfWork.ExecuteAsTransactionAsync(async () =>
        {
            var response = await _createMaintenancePaymentCommandService.Handle(command);
            return response;
        });

        return response;
    }
}
