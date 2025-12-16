using Levara.DAL.Repositories;
using Levara.Domain.DAL;
using Levara.Domain.DAL.Repositories;
using Levara.Domain.Enum;
using Levara.Domain.Models;
using Levara.Shared.Domain.Bus.Commands;
using Levara.Shared.Extensions;
using Levara.Shared.Results;

namespace Levara.Application.Plaid.CreateLeasePayment;

public class CreateLeasePaymentCommandHandler : ICommandHandler<CreateLeasePaymentCommand, CreateLeasePaymentCommandResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly CreateLeasePaymentCommandService _createLeasePaymentCommandService;

    public CreateLeasePaymentCommandHandler(IUnitOfWork unitOfWork,
        CreateLeasePaymentCommandService createLeasePaymentCommandService)
    {
        _unitOfWork = unitOfWork;
        _createLeasePaymentCommandService = createLeasePaymentCommandService;

    }
    public async Task<OperationResult<CreateLeasePaymentCommandResponse>> Handle(CreateLeasePaymentCommand command)
    {
        var response = await _unitOfWork.ExecuteAsTransactionAsync(async () =>
        {
            var response = await _createLeasePaymentCommandService.Handle(command);
            return response;
        });
        
        return response;

    }
}
