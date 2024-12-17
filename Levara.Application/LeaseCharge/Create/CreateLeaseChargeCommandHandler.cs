
using Levara.DAL.DbContext;
using Levara.Domain.DAL;
using Levara.Domain.DAL.Repositories;
using Levara.Domain.Enum;
using Levara.Domain.Models;
using Levara.Shared.Domain.Bus.Commands;
using Levara.Shared.Results;

namespace Levara.Application.LeasesCharges.Create;

public class CreateLeaseChargeCommandHandler : ICommandHandler<CreateLeaseChargeCommand, CreateLeaseChargeCommandResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ITransactionRepository _transactionRepository;
    private readonly ILeaseChargeRepository _leaseChargeRepository;
    private readonly ApplicationDbContext _context;
    public CreateLeaseChargeCommandHandler(IUnitOfWork unitOfWork,
        ITransactionRepository transactionRepository, ILeaseChargeRepository leaseChargeRepository, ApplicationDbContext context) 
    {
        _unitOfWork = unitOfWork;
        _transactionRepository = transactionRepository;
        _leaseChargeRepository = leaseChargeRepository;
        _context = context;
    }
    public async Task<OperationResult<CreateLeaseChargeCommandResponse>> Handle(CreateLeaseChargeCommand command)
    {
        //Debo obtener la ultima transaccion de la propiedad para poder luego actualizar el running balance
        //Y el entity Running Balance
        var lastTransaction = _transactionRepository.GetAll()
        .Where(t => t.PropertyId == command.PropertyId) // Filtra por la propiedad
        .OrderByDescending(t => t.CreatedDate) // Ordena por fecha de creación descendente
        .FirstOrDefault();

        decimal nextRunningBalance = 0;
        decimal nextEntityRunningBalance = 0;

        if (lastTransaction != null)
        {
            nextEntityRunningBalance = lastTransaction.EntityRunningBalance - command.Amount;
            nextRunningBalance = lastTransaction.RunningBalance - command.Amount;
        }

        Transaction transaction = new()
        {
            Type = TransactionType.Lease,
            SubType = TransactionSubType.Charge,
            PropertyId = command.PropertyId,
            EntityId = command.LeaseId,
            Amount=command.Amount,
            Date= command.Date.ToUniversalTime(),
            Description= command.Description, 
            RunningBalance=nextRunningBalance,
            EntityRunningBalance=nextEntityRunningBalance
        };

        LeaseCharge leaseCharge = new()
        {
            LeaseId = command.LeaseId
        };

        await _unitOfWork.ExecuteAsTransactionAsync(async () =>
        {  
            await _transactionRepository.AddAsync(transaction);
            await _context.SaveChangesAsync();

            leaseCharge.TransactionId = transaction.Id;
            
            await _leaseChargeRepository.AddAsync(leaseCharge);
            await _context.SaveChangesAsync(); 

            return true;
        });
       

        CreateLeaseChargeCommandResponse response = new ()
        {
            Id = transaction.Id
        };

        return OperationResult<CreateLeaseChargeCommandResponse>.SuccessResult(response);

    }
}
