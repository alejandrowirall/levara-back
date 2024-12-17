
using Levara.DAL.DbContext;
using Levara.DAL.Repositories;
using Levara.Domain.DAL;
using Levara.Domain.DAL.Repositories;
using Levara.Domain.Enum;
using Levara.Domain.Models;
using Levara.Shared.Domain.Bus.Commands;
using Levara.Shared.Results;
using Microsoft.EntityFrameworkCore;

namespace Levara.Application.LeasesPayment.Create;

public class CreateLeasePaymentCommandHandler : ICommandHandler<CreateLeasePaymentCommand, CreateLeasePaymentCommandResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ITransactionRepository _transactionRepository;
    private readonly ILeasePaymentRepository _leasePaymentRepository;
    private readonly ApplicationDbContext _context;
    public CreateLeasePaymentCommandHandler(IUnitOfWork unitOfWork,
        ITransactionRepository transactionRepository, ILeasePaymentRepository paymentRepository, ApplicationDbContext context)
    {
        _unitOfWork = unitOfWork;
        _transactionRepository = transactionRepository;
        _leasePaymentRepository = paymentRepository;
        _context = context;
    }
    public async Task<OperationResult<CreateLeasePaymentCommandResponse>> Handle(CreateLeasePaymentCommand command)
    {
        var lastTransaction = _transactionRepository.GetAll()
        .Where(t => t.PropertyId == command.PropertyId) // Filtra por la propiedad
        .OrderByDescending(t => t.CreatedDate) // Ordena por fecha de creación descendente
        .FirstOrDefault();

        decimal nextRunningBalance = 0;
        decimal nextEntityRunningBalance = 0;

        if (lastTransaction != null)
        {
            nextEntityRunningBalance = lastTransaction.EntityRunningBalance + command.Amount;
            nextRunningBalance = lastTransaction.RunningBalance + command.Amount;
           
        }

        Transaction transaction = new()
        {
            Type = TransactionType.Lease,
            SubType = TransactionSubType.Payment,
            PropertyId = command.PropertyId,
            EntityId =command.EntityId,
            Amount=command.Amount,
            Date= command.Date.ToUniversalTime(),
            Description= command.Description, 
            RunningBalance=nextRunningBalance,
            EntityRunningBalance=nextEntityRunningBalance
        };

        LeasePayment leasePayment = new()
        {
            LeaseId = command.LeaseId
        };

        await _unitOfWork.ExecuteAsTransactionAsync(async () =>
        {
            await _transactionRepository.AddAsync(transaction);
            await _context.SaveChangesAsync();

            leasePayment.TransactionId = transaction.Id;

            await _leasePaymentRepository.AddAsync(leasePayment);
            await _context.SaveChangesAsync();

            return true;
        });

        CreateLeasePaymentCommandResponse response = new ()
        {
            Id = leasePayment.Id
        };

        return OperationResult<CreateLeasePaymentCommandResponse>.SuccessResult(response);

    }
}
