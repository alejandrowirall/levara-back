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
    private readonly IBankTransactionRepository _bankTransactionRepository;
    private readonly IMaintenanceChargeRepository _maintenanceChargeRepository;
    private readonly IMaintenancePaymentRepository _maintenancePaymentRepository;
    private readonly ILeaseChargeRepository _leaseChargeRepository;
    private readonly ILeasePaymentRepository _leasePaymentRepository;
    private readonly IExpenseChargeRepository _expensesChargeRepository;
    private readonly IExpensePaymentRepository _expensesPaymentRepository;
    private readonly ITransactionRepository _transactionRepository;
    private readonly ITransactionApplicationRepository _transactionApplicationRepository;
    public UpdateTransactionOwnerCommandHandler(IUnitOfWork unitOfWork,
        IPlaidRepository plaidRepository, IBankTransactionRepository bankTransactionRepository,
        IMaintenanceChargeRepository maintenanceChargeRepository,
    IMaintenancePaymentRepository maintenancePaymentRepository,
    ILeaseChargeRepository leaseChargeRepository,
    ILeasePaymentRepository leasePaymentRepository,
    IExpenseChargeRepository expensesChargeRepository,
    IExpensePaymentRepository expensesPaymentRepository,
    ITransactionRepository transactionRepository,
    ITransactionApplicationRepository transactionApplicationrepository)
    {
        _unitOfWork = unitOfWork;
        _plaidRepository = plaidRepository;
        _bankTransactionRepository = bankTransactionRepository;
        _maintenanceChargeRepository=maintenanceChargeRepository;
        _maintenancePaymentRepository= maintenancePaymentRepository;
        _leaseChargeRepository = leaseChargeRepository;
        _leasePaymentRepository = leasePaymentRepository;
        _expensesChargeRepository = expensesChargeRepository;
        _expensesPaymentRepository = expensesPaymentRepository;
        _transactionRepository = transactionRepository;
        _transactionApplicationRepository= transactionApplicationrepository;
    }
    public async Task<OperationResult<UpdateTransactionOwnerCommandResponse>> Handle(UpdateTransactionOwnerCommand command)
    {
        
        var plaidTxQuery = _plaidRepository.GetAll()
                                         .Where(o => o.Id == command.PlaidId!);

        PlaidTransaction? plaidtx = await _plaidRepository.FirstOrDefaultAsync(plaidTxQuery);
        if (plaidtx == null)
            return OperationResult<UpdateTransactionOwnerCommandResponse>.ErrorResult(new ErrorDetails(404, "Not found"));


     
        var bnkTxQuery = _bankTransactionRepository.GetAll()
            .Where(b =>b.OwnerBankAccountId==plaidtx.OwnerBankAccountId)
            .OrderByDescending(o => o.Id);

        BankTransaction? banktx = await _bankTransactionRepository.FirstOrDefaultAsync(bnkTxQuery);
        if (banktx == null)
            return OperationResult<UpdateTransactionOwnerCommandResponse>.ErrorResult(new ErrorDetails(404, "Not found"));


        BankTransaction bankTransaction = new BankTransaction()
        {
            Amount = plaidtx.Amount,
            Description = plaidtx.Description,
            Date = plaidtx.Date,
            LeaseId = command.LeaseId,
            OwnerBankAccountId = banktx.OwnerBankAccountId,
            PropertyId = command.PropertyId!.Value,
            RunningBalance = banktx.RunningBalance + plaidtx.Amount,
            PlaidIdTransaction=plaidtx.Id,
            Type=command.Category

        };
       
        plaidtx.Status = command.Status!;
        
        
        await _unitOfWork.ExecuteAsTransactionAsync(async () =>
        {
            await _bankTransactionRepository.AddAsync(bankTransaction);
            _plaidRepository.Update(plaidtx);

        });

        var response = new UpdateTransactionOwnerCommandResponse
        {
            Id = plaidtx.Id
        };

        return OperationResult<UpdateTransactionOwnerCommandResponse>.SuccessResult(response);

    }


    private async Task GenerateMaintenanceCharge(PlaidTransaction plaidtx, BankTransaction bankTx, UpdateTransactionOwnerCommand cmd)
    {
      
        var maintenanceChargeQuery = _maintenanceChargeRepository.GetAll()
            .Where(b => b.Id == cmd.MaintananceChargeId);
            

        MaintenanceCharge? maintenanceCharge = await _maintenanceChargeRepository.FirstOrDefaultAsync(maintenanceChargeQuery);

        var txQuery = _transactionRepository.GetAll()
           .Where(b => b.PropertyId == cmd.PropertyId)
           .OrderByDescending(o => o.Id);

        Transaction? lastTx = await _bankTransactionRepository.FirstOrDefaultAsync(txQuery);
        if (lastTx == null)
            return ;


        Transaction tx = new Transaction()
        {
            Amount = (decimal)plaidtx.Amount,
            Date = plaidtx.Date,
            Description = "PAGO DE Maintentance " + cmd.MaintananceChargeId.ToString(),
            RunningBalance = lastTx.RunningBalance + (decimal)plaidtx.Amount,
            SubType = Domain.Enum.TransactionSubType.Payment,
            Type = Domain.Enum.TransactionType.Maintenance,
            PropertyId = cmd.PropertyId!.Value,
            EntityId = maintenanceCharge.MaintenanceId

        };

        TransactionApplication txAppl = new TransactionApplication()
        {
            AppliedAmount = (decimal)plaidtx.Amount,
            BankTransaction = bankTx,
            ChargeTransaction = maintenanceCharge.Transaction,
            PaymentTransaction = tx
        };

        MaintenancePayment maintenancePayment = new MaintenancePayment()
        {
            MaintenanceId = maintenanceCharge.MaintenanceId,
            Transaction= tx,
            

        };

        await _unitOfWork.ExecuteAsTransactionAsync(async () =>
        {
            await _bankTransactionRepository.AddAsync(bankTx);
            await _transactionRepository.AddAsync(tx);
            await _transactionApplicationRepository.AddAsync(txAppl);
            await _maintenancePaymentRepository.AddAsync(maintenancePayment);
            _plaidRepository.Update(plaidtx);

        });

    }
}
