using Levara.Domain.DAL;
using Levara.Domain.DAL.Repositories;
using Levara.Domain.Models;
using Levara.Shared.Domain.Bus.Commands;
using Levara.Shared.Results;

namespace Levara.Application.Plaid.Update;

public class UpdateTransactionOwnerCommandHandler : ICommandHandler<UpdateTransactionOwnerCommand, UpdateTransactionOwnerCommandResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IPlaidRepository _plaidRepository;
    public UpdateTransactionOwnerCommandHandler(IUnitOfWork unitOfWork,
        IPlaidRepository plaidRepository) 
    {
        _unitOfWork = unitOfWork;
        _plaidRepository = plaidRepository;
    }
    public async Task<OperationResult<UpdateTransactionOwnerCommandResponse>> Handle(UpdateTransactionOwnerCommand command)
    {
        
        var plaidTxQuery = _plaidRepository.GetAll()
                                         .Where(o => o.Id == command.PlaidId!);

        PlaidTransaction? plaidtx = await _plaidRepository.FirstOrDefaultAsync(plaidTxQuery);
        if (plaidtx == null)
            return OperationResult<UpdateTransactionOwnerCommandResponse>.ErrorResult(new ErrorDetails(404, "Not found"));

        plaidtx.Id = command.PlaidId.Value;
        plaidtx.Status = command.Status!;
        
        
        //TODO
        //HACER INSERT DE BANK TRANSACTION
        await _unitOfWork.ExecuteAsTransactionAsync(() =>
        {
            _plaidRepository.Update(plaidtx);
            return Task.CompletedTask;

        });

        var response = new UpdateTransactionOwnerCommandResponse
        {
            Id = plaidtx.Id
        };

        return OperationResult<UpdateTransactionOwnerCommandResponse>.SuccessResult(response);

    }
}
