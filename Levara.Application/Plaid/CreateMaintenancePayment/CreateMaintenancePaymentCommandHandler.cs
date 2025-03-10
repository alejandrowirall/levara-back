using Levara.DAL.Repositories;
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
    private readonly IPaymentRepository _paymentRepository;
    private readonly IMaintenanceRepository _maintenanceRepository;
    private readonly IMaintenanceChargeRepository _maintenanceChargeRepository;
    private readonly IMaintenancePaymentRepository _maintenancePaymentRepository;
    private readonly ITransactionRepository _transactionRepository;
    private readonly ITransactionApplicationRepository _transactionApplicationRepository;
    public CreateMaintenancePaymentCommandHandler(IUnitOfWork unitOfWork,
        IPlaidRepository plaidRepository,
        IPaymentRepository paymentRepository,
        IMaintenanceRepository maintenanceRepository,
        IMaintenanceChargeRepository maintenanceChargeRepository,
        IMaintenancePaymentRepository maintenancePaymentRepository,
        ITransactionRepository transactionRepository,
        ITransactionApplicationRepository transactionApplicationrepository)
    {
        _unitOfWork = unitOfWork;
        _plaidRepository = plaidRepository;
        _paymentRepository = paymentRepository;
        _maintenanceRepository = maintenanceRepository;
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

        if (((-1)*(plaidtx.Amount)) < command.Amount!.Value)
            return OperationResult<CreateMaintenancePaymentCommandResponse>.ErrorResult(new ErrorDetails(400, $"The amount must be less than or equal to the Plaid transaction amount"));

        if (plaidtx.OwnerBankAccount.OwnerId != command.OwnerId)
            return OperationResult<CreateMaintenancePaymentCommandResponse>.ErrorResult(new ErrorDetails(400, $"Plaid transaction is not owned by the owner"));

        plaidtx.Status = PlaidTransactionStatus.RelevantTransaction;

        if (command.MaintenanceChargeId.HasValue)
            return await GenerateMaintenancePaymentWithCharge(plaidtx, command);


        return await GenerateMaintenancePaymentWithoutCharge(plaidtx, command);
    }

    private async Task<OperationResult<CreateMaintenancePaymentCommandResponse>> GenerateMaintenancePaymentWithoutCharge(PlaidTransaction plaidtx,
        CreateMaintenancePaymentCommand command)
    {

        var lastPropertyPaymentQuery = _paymentRepository.GetAll()
                                                         .Where(b => b.PropertyId == command.CreateMaintenance!.PropertyId!.Value)
                                                         .OrderByDescending(o => o.CreatedDate);

        decimal runningBalance = 0;
        Payment? lastPropertyPayment = await _paymentRepository.FirstOrDefaultAsync(lastPropertyPaymentQuery);
        if (lastPropertyPayment != null)
            runningBalance = lastPropertyPayment.RunningBalance;

        var lastBankAccPaymentQuery = _paymentRepository.GetAll()
                                                        .Where(b => b.OwnerBankAccountId == plaidtx.OwnerBankAccountId)
                                                        .OrderByDescending(o => o.CreatedDate);

        decimal bankAccountBalance = 0;
        Payment? lastBankAccPayment = await _paymentRepository.FirstOrDefaultAsync(lastBankAccPaymentQuery);
        if (lastBankAccPayment != null)
            bankAccountBalance = lastBankAccPayment.BankAccountBalance!.Value;

        Payment newPayment = new()
        {
            Amount = command.Amount!.Value,
            Description = $"Payment of {command.CreateMaintenance!.Title}",
            Date = plaidtx.Date,
            OwnerBankAccountId = plaidtx.OwnerBankAccountId,
            PropertyId = command.CreateMaintenance!.PropertyId!.Value,
            RunningBalance = runningBalance - command.Amount!.Value,
            BankAccountBalance = bankAccountBalance - command.Amount!.Value,
            PlaidTransactionId = plaidtx.Id,
            Type = TransactionType.Maintenance,
            PaymentMethod = PaymentMethod.BankTransfer,
        };

        var txQuery = _transactionRepository.GetAll()
           .Where(b => b.PropertyId == command.CreateMaintenance!.PropertyId!.Value)
           .OrderByDescending(o => o.Id);

        Transaction? lastTx = await _transactionRepository.FirstOrDefaultAsync(txQuery);

        decimal currentRunningBalance = 0;
        decimal currentEntityRunningBalance = 0;

        if (lastTx != null)
        {
            currentRunningBalance = lastTx.RunningBalance;
            currentEntityRunningBalance = lastTx.EntityRunningBalance;
            
        }

        Maintenance newMaintenance = new()
        {
            PropertyId = command.CreateMaintenance!.PropertyId!.Value,
            Title = command.CreateMaintenance.Title,
            Status = MaintenanceStatus.Completed,
            TypeId = command.CreateMaintenance!.TypeId!.Value,
            DueDate = DateTime.UtcNow,
            Description = command.CreateMaintenance.Description
        };

        Transaction newMaintenanceChargeTx =
            Transaction.CreateMaintenanceCharge(command.CreateMaintenance!.PropertyId!.Value,
                                                command.Amount!.Value,
                                                0,
                                                newMaintenance.Title,
                                                currentRunningBalance,
                                                currentEntityRunningBalance);

        MaintenanceCharge newMaintenanceCharge = new()
        {
            Transaction = newMaintenanceChargeTx,
            Maintenance = newMaintenance,
            DueDate = DateTime.UtcNow,
            Status = MaintenanceChargeStatus.Paid,
        };

        Transaction newMaintenancePaymentTx = 
            Transaction.CreateMaintenancePayment(command.CreateMaintenance!.PropertyId!.Value,
                                                command.Amount!.Value,
                                                0,
                                                newMaintenance.Title,
                                                newMaintenanceChargeTx.RunningBalance,
                                                newMaintenanceChargeTx.EntityRunningBalance);

        TransactionApplication txAppl = new()
        {
            AppliedAmount = (decimal)command.Amount!,
            Payment = newPayment,
            ChargeTransaction = newMaintenanceChargeTx,
            PaymentTransaction = newMaintenancePaymentTx
        };

        MaintenancePayment newMaintenancePayment = new()
        {
            Maintenance = newMaintenance,
            Transaction = newMaintenancePaymentTx,
        };
        

        await _unitOfWork.ExecuteAsTransactionAsync(async () =>
        {
            await _maintenanceRepository.AddAsync(newMaintenance);
            await _unitOfWork.SaveChangesAsync();

            await _paymentRepository.AddAsync(newPayment);

            newMaintenanceChargeTx.EntityId = newMaintenance.Id;
            await _transactionRepository.AddAsync(newMaintenanceChargeTx);

            newMaintenancePaymentTx.EntityId = newMaintenance.Id;
            await _transactionRepository.AddAsync(newMaintenancePaymentTx);

            await _transactionApplicationRepository.AddAsync(txAppl);

            await _maintenanceChargeRepository.AddAsync(newMaintenanceCharge);
            await _maintenancePaymentRepository.AddAsync(newMaintenancePayment);
            _plaidRepository.Update(plaidtx);
        });


        CreateMaintenancePaymentCommandResponse response = new()
        {
            Id = plaidtx.Id
        };

        return OperationResult<CreateMaintenancePaymentCommandResponse>.SuccessResult(response);

    }

    private async Task<OperationResult<CreateMaintenancePaymentCommandResponse>> GenerateMaintenancePaymentWithCharge(PlaidTransaction plaidtx,
        CreateMaintenancePaymentCommand command)
    {
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


        var lastPropertyPaymentQuery = _paymentRepository.GetAll()
                                                         .Where(b => b.PropertyId == maintenanceCharge.Maintenance.PropertyId)
                                                         .OrderByDescending(o => o.CreatedDate);

        decimal runningBalance = 0;
        Payment? lastPropertyPayment = await _paymentRepository.FirstOrDefaultAsync(lastPropertyPaymentQuery);
        if (lastPropertyPayment != null)
            runningBalance = lastPropertyPayment.RunningBalance;

        var lastBankAccPaymentQuery = _paymentRepository.GetAll()
                                                        .Where(b => b.OwnerBankAccountId == plaidtx.OwnerBankAccountId)
                                                        .OrderByDescending(o => o.CreatedDate);

        decimal bankAccountBalance = 0;
        Payment? lastBankAccPayment = await _paymentRepository.FirstOrDefaultAsync(lastBankAccPaymentQuery);
        if (lastBankAccPayment != null)
            bankAccountBalance = lastBankAccPayment.BankAccountBalance!.Value;

        Payment newPayment = new()
        {
            Amount = command.Amount!.Value,
            Description = $"Payment of {maintenanceCharge.Maintenance.Title}",
            Date = plaidtx.Date,
            OwnerBankAccountId = plaidtx.OwnerBankAccountId,
            PropertyId = maintenanceCharge.Maintenance.PropertyId,
            RunningBalance = runningBalance - command.Amount!.Value,
            BankAccountBalance = bankAccountBalance - command.Amount!.Value,
            PlaidTransactionId = plaidtx.Id,
            Type = TransactionType.Maintenance,
            PaymentMethod = PaymentMethod.BankTransfer,
        };

        var txQuery = _transactionRepository.GetAll()
           .Where(b => b.PropertyId == maintenanceCharge.Maintenance.PropertyId)
           .OrderByDescending(o => o.CreatedDate);

        Transaction? lastTx = await _transactionRepository.FirstOrDefaultAsync(txQuery);
        if (lastTx == null)
            return OperationResult<CreateMaintenancePaymentCommandResponse>.ErrorResult(new ErrorDetails(404, "Not found"));

        Transaction tx = Transaction.CreateMaintenancePayment(maintenanceCharge.Maintenance.PropertyId,
                                                              command.Amount!.Value,
                                                              maintenanceCharge.MaintenanceId,
                                                              maintenanceCharge.Maintenance.Title,
                                                              lastTx.RunningBalance,
                                                              lastTx.EntityRunningBalance,
                                                              plaidtx.Date);

        TransactionApplication txAppl = new()
        {
            AppliedAmount = (decimal)command.Amount!,
            Payment = newPayment,
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
            await _paymentRepository.AddAsync(newPayment);
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


        var lastPropertyPaymentQuery = _paymentRepository.GetAll()
                                                        .Where(b => b.PropertyId == maintenanceCharge.Maintenance.PropertyId)
                                                        .OrderByDescending(o => o.CreatedDate);

        decimal runningBalance = 0;
        Payment? lastPropertyPayment = await _paymentRepository.FirstOrDefaultAsync(lastPropertyPaymentQuery);
        if (lastPropertyPayment != null)
            runningBalance = lastPropertyPayment.RunningBalance;

        var lastBankAccPaymentQuery = _paymentRepository.GetAll()
                                                        .Where(b => b.OwnerBankAccountId == plaidtx.OwnerBankAccountId)
                                                        .OrderByDescending(o => o.CreatedDate);

        decimal bankAccountBalance = 0;
        Payment? lastBankAccPayment = await _paymentRepository.FirstOrDefaultAsync(lastBankAccPaymentQuery);
        if (lastBankAccPayment != null)
            bankAccountBalance = lastBankAccPayment.BankAccountBalance!.Value;

        Payment newPayment = new()
        {
            Amount = command.Amount!.Value,
            Description = $"Payment of {maintenanceCharge.Maintenance.Title}",
            Date = plaidtx.Date,
            OwnerBankAccountId = plaidtx.OwnerBankAccountId,
            PropertyId = maintenanceCharge.Maintenance.PropertyId,
            RunningBalance = runningBalance + command.Amount!.Value,
            BankAccountBalance = bankAccountBalance + command.Amount!.Value,
            PlaidTransactionId = plaidtx.Id,
            Type = TransactionType.Maintenance,
            PaymentMethod = PaymentMethod.BankTransfer,
        };

        var txQuery = _transactionRepository.GetAll()
           .Where(b => b.PropertyId == maintenanceCharge.Maintenance.PropertyId)
           .OrderByDescending(o => o.Id);

        Transaction? lastTx = await _transactionRepository.FirstOrDefaultAsync(txQuery);
        if (lastTx == null)
            return OperationResult<CreateMaintenancePaymentCommandResponse>.ErrorResult(new ErrorDetails(404, "Not found"));

        Transaction tx = Transaction.CreateMaintenancePayment(maintenanceCharge.Maintenance.PropertyId,
                                                              command.Amount!.Value,
                                                              maintenanceCharge.MaintenanceId,
                                                              maintenanceCharge.Maintenance.Title,
                                                              lastTx.RunningBalance,
                                                              lastTx.EntityRunningBalance,
                                                              plaidtx.Date);


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
            Payment = newPayment,
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
            await _paymentRepository.AddAsync(newPayment);
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
