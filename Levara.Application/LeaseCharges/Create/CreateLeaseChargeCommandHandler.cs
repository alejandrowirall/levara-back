using Levara.Domain.DAL;
using Levara.Shared.Domain.Bus.Commands;
using Levara.Shared.Results;

namespace Levara.Application.LeaseCharges.Create;

public class CreateLeaseChargeCommandHandler : ICommandHandler<CreateLeaseChargeCommand, CreateLeaseChargeCommandResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly CreateLeaseChargeCommandService _createLeaseChargeCommandService;
    public CreateLeaseChargeCommandHandler(IUnitOfWork unitOfWork,
        CreateLeaseChargeCommandService createLeaseChargeCommandService)
    {
        _unitOfWork = unitOfWork;
        _createLeaseChargeCommandService = createLeaseChargeCommandService;
    }
    public async Task<OperationResult<CreateLeaseChargeCommandResponse>> Handle(CreateLeaseChargeCommand command)
    {
        var response = await _unitOfWork.ExecuteAsTransactionAsync(async () =>
        {
            var response = await _createLeaseChargeCommandService.Handle(command);
            return response;
        });

        return response;

    }
}
