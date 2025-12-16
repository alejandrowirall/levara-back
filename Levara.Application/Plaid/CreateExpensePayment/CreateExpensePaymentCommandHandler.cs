using Levara.Domain.DAL;
using Levara.Shared.Domain.Bus.Commands;
using Levara.Shared.Results;

namespace Levara.Application.Plaid.CreateExpensePayment;

public class CreateExpensePaymentCommandHandler : ICommandHandler<CreateExpensePaymentCommand, CreateExpensePaymentCommandResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly CreateExpensePaymentCommandService _createExpensePaymentCommandService;

    public CreateExpensePaymentCommandHandler(IUnitOfWork unitOfWork,
        CreateExpensePaymentCommandService createExpensePaymentCommandService)
    {
        _unitOfWork = unitOfWork;
        _createExpensePaymentCommandService = createExpensePaymentCommandService;
    }
    public async Task<OperationResult<CreateExpensePaymentCommandResponse>> Handle(CreateExpensePaymentCommand command)
    {

        var response = await _unitOfWork.ExecuteAsTransactionAsync(async () =>
        {
            var response = await _createExpensePaymentCommandService.Handle(command);
            return response;
        });

        return response;
    }

}
