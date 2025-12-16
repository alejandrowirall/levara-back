using Levara.Domain.DAL;
using Levara.Shared.Domain.Bus.Commands;
using Levara.Shared.Results;

namespace Levara.Application.ExpenseCharges.Create;

public class CreateExpenseChargeCommandHandler : ICommandHandler<CreateExpenseChargeCommand, CreateExpenseChargeCommandResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly CreateExpenseChargeCommandService _createExpenseChargeCommandService;
    public CreateExpenseChargeCommandHandler(IUnitOfWork unitOfWork,
        CreateExpenseChargeCommandService createExpenseChargeCommandService)
    {
        _unitOfWork = unitOfWork;
        _createExpenseChargeCommandService = createExpenseChargeCommandService;
    }
    public async Task<OperationResult<CreateExpenseChargeCommandResponse>> Handle(CreateExpenseChargeCommand command)
    {

        var response = await _unitOfWork.ExecuteAsTransactionAsync(async () =>
        {
            var response = await _createExpenseChargeCommandService.Handle(command);
            return response;
        });

        return response;

    }
}
