
using Levara.Domain.DAL;
using Levara.Domain.DAL.Repositories;
using Levara.Domain.Enum;
using Levara.Domain.Models;
using Levara.Shared.Domain.Bus.Commands;
using Levara.Shared.Results;

namespace Levara.Application.LeaseCharges.Create;

public class CreateLeaseChargeCommandHandler : ICommandHandler<CreateLeaseChargeCommand, CreateLeaseChargeCommandResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ITransactionRepository _transactionRepository;
    private readonly ILeaseChargeRepository _leaseChargeRepository;
    public CreateLeaseChargeCommandHandler(IUnitOfWork unitOfWork,
        ITransactionRepository transactionRepository, 
        ILeaseChargeRepository leaseChargeRepository)
    {
        _unitOfWork = unitOfWork;
        _transactionRepository = transactionRepository;
        _leaseChargeRepository = leaseChargeRepository;
    }
    public async Task<OperationResult<CreateLeaseChargeCommandResponse>> Handle(CreateLeaseChargeCommand command)
    {

        var lastTxQuery = _transactionRepository.GetAll()
                                                .Where(t => t.PropertyId == command.PropertyId)
                                                .OrderByDescending(t => t.CreatedDate);

        var lastTx = await _transactionRepository.FirstOrDefaultAsync(lastTxQuery);

        decimal nextRunningBalance = 0;
        decimal nextEntityRunningBalance = 0;

        if (lastTx != null)
        {
            nextEntityRunningBalance = lastTx.EntityRunningBalance - command.Amount!.Value;
            nextRunningBalance = lastTx.RunningBalance - command.Amount!.Value;
        }

        Transaction newTransaction =
            Transaction.CreateLeaseCharge(command.PropertyId!.Value,
                command.Amount!.Value,
                command.LeaseId!.Value,
                command.Description!,
                nextRunningBalance,
                nextEntityRunningBalance,
                command.Date);

        LeaseCharge newLeaseCharge = new()
        {
            Description = command.Description!,
            LeaseId = command.LeaseId!.Value,
            Status = LeaseChargeStatus.Unpaid,
            DueDate = command.DueDate!.Value,
            Transaction = newTransaction
        };

        await _unitOfWork.ExecuteAsTransactionAsync(async () =>
        {
            await _transactionRepository.AddAsync(newTransaction);
            await _leaseChargeRepository.AddAsync(newLeaseCharge);
        });


        CreateLeaseChargeCommandResponse response = new()
        {
            Id = newTransaction.Id
        };

        return OperationResult<CreateLeaseChargeCommandResponse>.SuccessResult(response);

    }
}
