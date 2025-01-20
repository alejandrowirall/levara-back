using Levara.Domain.DAL;
using Levara.Domain.DAL.Repositories;
using Levara.Domain.Enum;
using Levara.Domain.Models;
using Levara.Shared.Domain.Bus.Commands;
using Levara.Shared.Extensions;
using Levara.Shared.Results;
using Microsoft.EntityFrameworkCore;

namespace Levara.Application.Plaid.CreateMaintenancePayment;

public class CreateMaintenancePaymentCommandHandler : ICommandHandler<CreateMaintenancePaymentCommand, CreateMaintenancePaymentCommandResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IPlaidRepository _plaidRepository;
    private readonly IBankTransactionRepository _bankTransactionRepository;
    private readonly IMaintenanceChargeRepository _maintenanceChargeRepository;
    private readonly IMaintenancePaymentRepository _maintenancePaymentRepository;
    private readonly ITransactionRepository _transactionRepository;
    private readonly ITransactionApplicationRepository _transactionApplicationRepository;
    public CreateMaintenancePaymentCommandHandler(IUnitOfWork unitOfWork,
        IPlaidRepository plaidRepository, 
        IBankTransactionRepository bankTransactionRepository,
        IMaintenanceChargeRepository maintenanceChargeRepository,
        IMaintenancePaymentRepository maintenancePaymentRepository,
        ITransactionRepository transactionRepository,
        ITransactionApplicationRepository transactionApplicationrepository)
    {
        _unitOfWork = unitOfWork;
        _plaidRepository = plaidRepository;
        _bankTransactionRepository = bankTransactionRepository;
        _maintenanceChargeRepository = maintenanceChargeRepository;
        _maintenancePaymentRepository = maintenancePaymentRepository;
        _transactionRepository = transactionRepository;
        _transactionApplicationRepository = transactionApplicationrepository;
    }
    public async Task<OperationResult<CreateMaintenancePaymentCommandResponse>> Handle(CreateMaintenancePaymentCommand command)
    {

        var plaidTxQuery = _plaidRepository.GetAllWithOwnerBankAccount()
                                           .Where(o => o.Id == command.PlaidId!);

        PlaidTransaction? plaidtx = await _plaidRepository.FirstOrDefaultAsync(plaidTxQuery);
        if (plaidtx == null)
            return OperationResult<CreateMaintenancePaymentCommandResponse>.ErrorResult(new ErrorDetails(404, "Not found"));

        if (plaidtx.Status != PlaidTransactionStatus.Created && plaidtx.Status != PlaidTransactionStatus.NeedReview)
            return OperationResult<CreateMaintenancePaymentCommandResponse>.ErrorResult(new ErrorDetails(400, $"Plaid transaction must be in state {EnumExtensions.GetEnumDescription(PlaidTransactionStatus.Created)} or {EnumExtensions.GetEnumDescription(PlaidTransactionStatus.NeedReview)}"));

        if (plaidtx.Amount >= 0)
            return OperationResult<CreateMaintenancePaymentCommandResponse>.ErrorResult(new ErrorDetails(400, $"Plaid transaction must be less than zero"));

        if (plaidtx.OwnerBankAccount.OwnerId != command.OwnerId)
            return OperationResult<CreateMaintenancePaymentCommandResponse>.ErrorResult(new ErrorDetails(400, $"Plaid transaction is not owned by the owner"));

        plaidtx.Status = PlaidTransactionStatus.RelevantTransaction;

        var maintenanceChargeQuery = _maintenanceChargeRepository.GetAllFull()
                                                                 .Where(b => b.Id == command.MaintenanceChargeId);

        MaintenanceCharge? maintenanceCharge = await _maintenanceChargeRepository.FirstOrDefaultAsync(maintenanceChargeQuery);
        if (maintenanceCharge == null)
            return OperationResult<CreateMaintenancePaymentCommandResponse>.ErrorResult(new ErrorDetails(404, "Not found"));

        if (maintenanceCharge.Maintenance.Property.OwnerId != command.OwnerId)
            return OperationResult<CreateMaintenancePaymentCommandResponse>.ErrorResult(new ErrorDetails(400, "The charge does not belong to a property of the owner"));

        if (maintenanceCharge.Status == MaintenanceChargeStatus.Paid)
            return OperationResult<CreateMaintenancePaymentCommandResponse>.ErrorResult(new ErrorDetails(400, "The charge must not be in paid status"));

        if (maintenanceCharge.Status == MaintenanceChargeStatus.Unpaid)
            return await GenerateMaintenancePaymentFromUnpaid(plaidtx, maintenanceCharge, command);

        return await GenerateMaintenancePaymentFromPartpaid(plaidtx, maintenanceCharge, command);
    }

    private async Task<OperationResult<CreateMaintenancePaymentCommandResponse>> GenerateMaintenancePaymentFromUnpaid(PlaidTransaction plaidtx,
        MaintenanceCharge maintenanceCharge,
        CreateMaintenancePaymentCommand command)
    {


        var bnkTxQuery = _bankTransactionRepository.GetAll()
           .Where(b => b.OwnerBankAccountId == plaidtx.OwnerBankAccountId)
           .OrderByDescending(o => o.Id);

        double runningBalance = 0;
        BankTransaction? lastBanktx = await _bankTransactionRepository.FirstOrDefaultAsync(bnkTxQuery);
        if (lastBanktx != null)
            runningBalance = lastBanktx.RunningBalance!.Value;

        BankTransaction newBankTx = new()
        {
            TransactionId = plaidtx.TransactionId,
            Amount = plaidtx.Amount,
            Description = plaidtx.Description,
            Date = plaidtx.Date,
            OwnerBankAccountId = plaidtx.OwnerBankAccountId,
            PropertyId = maintenanceCharge.Maintenance.PropertyId,
            RunningBalance = runningBalance + plaidtx.Amount,
            PlaidIdTransaction = plaidtx.Id,
            Type = TransactionType.Maintenance,
        };

        var txQuery = _transactionRepository.GetAll()
           .Where(b => b.PropertyId == maintenanceCharge.Maintenance.PropertyId)
           .OrderByDescending(o => o.Id);

        Transaction? lastTx = await _bankTransactionRepository.FirstOrDefaultAsync(txQuery);
        if (lastTx == null)
            return OperationResult<CreateMaintenancePaymentCommandResponse>.ErrorResult(new ErrorDetails(404, "Not found"));


        Transaction tx = new()
        {
            Amount = command.Amount!.Value,
            Date = plaidtx.Date,
            Description = "Maintenance payment " + command.MaintenanceChargeId.ToString(),
            RunningBalance = lastTx.RunningBalance + command.Amount!.Value,
            EntityRunningBalance = lastTx.EntityRunningBalance + command.Amount!.Value,
            SubType = TransactionSubType.Payment,
            Type = TransactionType.Maintenance,
            PropertyId = maintenanceCharge.Maintenance.PropertyId,
            EntityId = maintenanceCharge.MaintenanceId
        };

        TransactionApplication txAppl = new()
        {
            AppliedAmount = (decimal)command.Amount!,
            BankTransaction = newBankTx,
            ChargeTransactionId = maintenanceCharge.TransactionId,
            PaymentTransaction = tx
        };

        MaintenancePayment maintenancePayment = new()
        {
            MaintenanceId = maintenanceCharge.MaintenanceId,
            Transaction = tx,
        };

        maintenanceCharge.Status = maintenanceCharge.Transaction.Amount == txAppl.AppliedAmount ? MaintenanceChargeStatus.Paid : MaintenanceChargeStatus.Partpaid;

        await _unitOfWork.ExecuteAsTransactionAsync(async () =>
        {
            await _bankTransactionRepository.AddAsync(newBankTx);
            await _transactionRepository.AddAsync(tx);
            await _transactionApplicationRepository.AddAsync(txAppl);
            _maintenanceChargeRepository.Update(maintenanceCharge);
            await _maintenancePaymentRepository.AddAsync(maintenancePayment);
            _plaidRepository.Update(plaidtx);
        });


        CreateMaintenancePaymentCommandResponse response = new()
        {
            Id = plaidtx.Id
        };

        return OperationResult<CreateMaintenancePaymentCommandResponse>.SuccessResult(response);

    }

    private async Task<OperationResult<CreateMaintenancePaymentCommandResponse>> GenerateMaintenancePaymentFromPartpaid(PlaidTransaction plaidtx,
        MaintenanceCharge maintenanceCharge,
        CreateMaintenancePaymentCommand command)
    {


        var bnkTxQuery = _bankTransactionRepository.GetAll()
           .Where(b => b.OwnerBankAccountId == plaidtx.OwnerBankAccountId)
           .OrderByDescending(o => o.Id);

        double runningBalance = 0;
        BankTransaction? lastBanktx = await _bankTransactionRepository.FirstOrDefaultAsync(bnkTxQuery);
        if (lastBanktx != null)
            runningBalance = lastBanktx.RunningBalance!.Value;

        BankTransaction newBankTx = new()
        {
            TransactionId = plaidtx.TransactionId,
            Amount = plaidtx.Amount,
            Description = plaidtx.Description,
            Date = plaidtx.Date,
            OwnerBankAccountId = plaidtx.OwnerBankAccountId,
            PropertyId = maintenanceCharge.Maintenance.PropertyId,
            RunningBalance = runningBalance + plaidtx.Amount,
            PlaidIdTransaction = plaidtx.Id,
            Type = TransactionType.Maintenance,
        };

        var txQuery = _transactionRepository.GetAll()
           .Where(b => b.PropertyId == maintenanceCharge.Maintenance.PropertyId)
           .OrderByDescending(o => o.Id);

        Transaction? lastTx = await _bankTransactionRepository.FirstOrDefaultAsync(txQuery);
        if (lastTx == null)
            return OperationResult<CreateMaintenancePaymentCommandResponse>.ErrorResult(new ErrorDetails(404, "Not found"));


        Transaction tx = new()
        {
            Amount = command.Amount!.Value,
            Date = plaidtx.Date,
            Description = "Maintenance payment " + command.MaintenanceChargeId.ToString(),
            RunningBalance = lastTx.RunningBalance + command.Amount!.Value,
            EntityRunningBalance = lastTx.EntityRunningBalance + command.Amount!.Value,
            SubType = TransactionSubType.Payment,
            Type = TransactionType.Maintenance,
            PropertyId = maintenanceCharge.Maintenance.PropertyId,
            EntityId = maintenanceCharge.MaintenanceId

        };

        var currentTotalAmountTxAp = await _transactionApplicationRepository.GetAll()
                                                                            .Where(ta => ta.ChargeTransactionId == maintenanceCharge.TransactionId)
                                                                            .Select(ta => ta.AppliedAmount)
                                                                            .SumAsync();

        decimal newTotalAmountTxAp = currentTotalAmountTxAp + command.Amount!.Value;

        if (newTotalAmountTxAp > maintenanceCharge.Transaction.Amount)
            return OperationResult<CreateMaintenancePaymentCommandResponse>.ErrorResult(new ErrorDetails(400, "Invalid amount"));

        TransactionApplication txAppl = new()
        {
            AppliedAmount = command.Amount!.Value,
            BankTransaction = newBankTx,
            ChargeTransactionId = maintenanceCharge.TransactionId,
            PaymentTransaction = tx
        };

        MaintenancePayment maintenancePayment = new()
        {
            MaintenanceId = maintenanceCharge.MaintenanceId,
            Transaction = tx,
        };


        maintenanceCharge.Status = maintenanceCharge.Transaction.Amount == newTotalAmountTxAp ? MaintenanceChargeStatus.Paid : MaintenanceChargeStatus.Partpaid;

        await _unitOfWork.ExecuteAsTransactionAsync(async () =>
        {
            await _bankTransactionRepository.AddAsync(newBankTx);
            await _transactionRepository.AddAsync(tx);
            await _transactionApplicationRepository.AddAsync(txAppl);
            _maintenanceChargeRepository.Update(maintenanceCharge);
            await _maintenancePaymentRepository.AddAsync(maintenancePayment);
            _plaidRepository.Update(plaidtx);
        });


        CreateMaintenancePaymentCommandResponse response = new()
        {
            Id = plaidtx.Id
        };

        return OperationResult<CreateMaintenancePaymentCommandResponse>.SuccessResult(response);

    }
}
