using Levara.Domain.Contexts;
using Levara.Domain.DAL;
using Levara.Domain.DAL.Repositories;
using Levara.Domain.Models;
using Levara.Shared.Domain.Bus.Commands;
using Levara.Shared.Results;

namespace Levara.Application.Transactions.Delete;

public class DeleteTransactionCommandHandler : ICommandHandler<DeleteTransactionCommand, DeleteTransactionCommandResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ITransactionRepository _transactionRepository;
    public DeleteTransactionCommandHandler(IUnitOfWork unitOfWork,
        IUserContext userContext,
        ITransactionRepository transactionRepository) 
    {
        _unitOfWork = unitOfWork;
        _transactionRepository = transactionRepository;
    }
    public async Task<OperationResult<DeleteTransactionCommandResponse>> Handle(DeleteTransactionCommand command)
    {
        Transaction? transaction = await _transactionRepository.GetByIdAsync(command.Id!.Value);
        if (transaction == null)
            return OperationResult<DeleteTransactionCommandResponse>.ErrorResult(new ErrorDetails(404, "Not found"));

        await _unitOfWork.ExecuteAsTransactionAsync(() =>
        {
            _transactionRepository.Delete(transaction);

            return Task.CompletedTask;
        });

        var response = new DeleteTransactionCommandResponse
        {
            Id = transaction.Id
        };

        return OperationResult<DeleteTransactionCommandResponse>.SuccessResult(response);
    }
}
