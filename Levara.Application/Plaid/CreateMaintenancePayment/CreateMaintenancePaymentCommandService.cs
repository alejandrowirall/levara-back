using Levara.Domain;
using Levara.Domain.DAL;
using Levara.Domain.DAL.Repositories;
using Levara.Domain.Enum;
using Levara.Domain.Models;
using Levara.Shared.Extensions;
using Levara.Shared.Results;

namespace Levara.Application.Plaid.CreateMaintenancePayment;

public class CreateMaintenancePaymentCommandService : Service
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IPlaidRepository _plaidRepository;
    private readonly IPaymentRepository _paymentRepository;
    private readonly IMaintenanceRepository _maintenanceRepository;
    private readonly IMaintenanceChargeRepository _maintenanceChargeRepository;
    private readonly IMaintenancePaymentRepository _maintenancePaymentRepository;
    private readonly ITransactionRepository _transactionRepository;
    private readonly ITransactionApplicationRepository _transactionApplicationRepository;
    public CreateMaintenancePaymentCommandService(IUnitOfWork unitOfWork,
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

        if (plaidtx.Status != PlaidTransactionStatus.Created &&
            plaidtx.Status != PlaidTransactionStatus.NeedReview &&
            plaidtx.Status != PlaidTransactionStatus.NoMatch &&
            plaidtx.Status != PlaidTransactionStatus.Error)
            return OperationResult<CreateMaintenancePaymentCommandResponse>.ErrorResult(new ErrorDetails(400, $"Plaid transaction must be in state {EnumExtensions.GetEnumDescription(PlaidTransactionStatus.Created)} or {EnumExtensions.GetEnumDescription(PlaidTransactionStatus.NeedReview)} or {EnumExtensions.GetEnumDescription(PlaidTransactionStatus.NoMatch)} or {EnumExtensions.GetEnumDescription(PlaidTransactionStatus.Error)}"));

        //if (plaidtx.Amount >= 0)
        //    return OperationResult<CreateMaintenancePaymentCommandResponse>.ErrorResult(new ErrorDetails(400, $"Plaid transaction must be less than zero"));

        if (command.Amount!.Value > Math.Abs(plaidtx.Amount))
            return OperationResult<CreateMaintenancePaymentCommandResponse>.ErrorResult(new ErrorDetails(400, $"The amount must be less than or equal to the Plaid transaction amount"));

        if (plaidtx.OwnerBankAccount.OwnerId != command.OwnerId)
            return OperationResult<CreateMaintenancePaymentCommandResponse>.ErrorResult(new ErrorDetails(400, $"Plaid transaction is not owned by the owner"));

        plaidtx.Status = PlaidTransactionStatus.Reconciled;

        if (command.TransactionId.HasValue)
            return await GenerateMaintenancePaymentWithCharge(plaidtx, command);


        return await GenerateMaintenancePaymentWithoutCharge(plaidtx, command);
    }

    private async Task<OperationResult<CreateMaintenancePaymentCommandResponse>> GenerateMaintenancePaymentWithoutCharge(PlaidTransaction plaidtx,
        CreateMaintenancePaymentCommand command)
    {

        decimal runningBalance = await _paymentRepository.GetLastPropertyPaymentRunningBalanceAsync(command.CreateMaintenance!.PropertyId!.Value);
        decimal bankAccountRunningBalance = await _paymentRepository.GetLastBankAccountRunningBalanceAsync(plaidtx.OwnerBankAccountId);

        Payment newPayment = new()
        {
            Amount = command.Amount!.Value,
            Description = $"Payment of {command.CreateMaintenance!.Title}",
            Date = plaidtx.Date,
            OwnerBankAccountId = plaidtx.OwnerBankAccountId,
            PropertyId = command.CreateMaintenance!.PropertyId!.Value,
            RunningBalance = runningBalance - command.Amount!.Value,
            BankAccountRunningBalance = bankAccountRunningBalance - command.Amount!.Value,
            PlaidTransactionId = plaidtx.Id,
            Type = TransactionType.Maintenance,
            PaymentMethod = PaymentMethod.BankTransfer,
        };

        decimal currentRunningBalance = await _transactionRepository.GetLastPropertyRunningBalanceAsync(command.CreateMaintenance!.PropertyId!.Value);

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
            MaintenanceCharge.CreateTransaction(command.CreateMaintenance!.PropertyId!.Value,
                                                command.Amount!.Value,
                                                newMaintenance.Title,
                                                currentRunningBalance,
                                                DateTime.UtcNow,
                                                plaidtx.Date);

        newMaintenanceChargeTx.Status = TransactionStatus.Paid;

        MaintenanceCharge newMaintenanceCharge = new()
        {
            Transaction = newMaintenanceChargeTx,
            Maintenance = newMaintenance,
        };

        Transaction newMaintenancePaymentTx =
            MaintenancePayment.CreateTransaction(command.CreateMaintenance!.PropertyId!.Value,
                                                 command.Amount!.Value,
                                                 newMaintenance.Title,
                                                 newMaintenanceChargeTx.RunningBalance,
                                                 plaidtx.Date);

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

        await _maintenanceRepository.AddAsync(newMaintenance);
        await _unitOfWork.SaveChangesAsync();

        await _paymentRepository.AddAsync(newPayment);

        await _transactionRepository.AddAsync(newMaintenanceChargeTx);

        await _transactionRepository.AddAsync(newMaintenancePaymentTx);

        await _transactionApplicationRepository.AddAsync(txAppl);

        await _maintenanceChargeRepository.AddAsync(newMaintenanceCharge);
        await _maintenancePaymentRepository.AddAsync(newMaintenancePayment);
        _plaidRepository.Update(plaidtx);

        await _unitOfWork.SaveChangesAsync();

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
                                                                 .Where(b => b.TransactionId == command.TransactionId);

        MaintenanceCharge? maintenanceCharge = await _maintenanceChargeRepository.FirstOrDefaultAsync(maintenanceChargeQuery);
        if (maintenanceCharge == null)
            return OperationResult<CreateMaintenancePaymentCommandResponse>.ErrorResult(new ErrorDetails(404, $"Not found maintenance charge with TransactionId: {command.TransactionId}"));

        if (maintenanceCharge.Maintenance.Property.OwnerId != command.OwnerId)
            return OperationResult<CreateMaintenancePaymentCommandResponse>.ErrorResult(new ErrorDetails(400, "The charge does not belong to a property of the owner"));

        if (maintenanceCharge.Transaction.Status == TransactionStatus.Paid)
            return OperationResult<CreateMaintenancePaymentCommandResponse>.ErrorResult(new ErrorDetails(400, "The charge must not be in paid status"));

        if (maintenanceCharge.Transaction.Status == TransactionStatus.Unpaid)
            return await GenerateMaintenancePaymentFromUnpaid(plaidtx, maintenanceCharge, command);

        return await GenerateMaintenancePaymentFromPartpaid(plaidtx, maintenanceCharge, command);
    }

    private async Task<OperationResult<CreateMaintenancePaymentCommandResponse>> GenerateMaintenancePaymentFromUnpaid(PlaidTransaction plaidtx,
       MaintenanceCharge maintenanceCharge,
       CreateMaintenancePaymentCommand command)
    {

        decimal runningBalance = await _paymentRepository.GetLastPropertyPaymentRunningBalanceAsync(maintenanceCharge.Maintenance.PropertyId);
        decimal bankAccountRunningBalance = await _paymentRepository.GetLastBankAccountRunningBalanceAsync(plaidtx.OwnerBankAccountId);

        Payment newPayment = new()
        {
            Amount = command.Amount!.Value,
            Description = $"Payment of {maintenanceCharge.Maintenance.Title}",
            Date = plaidtx.Date,
            OwnerBankAccountId = plaidtx.OwnerBankAccountId,
            PropertyId = maintenanceCharge.Maintenance.PropertyId,
            RunningBalance = runningBalance - command.Amount!.Value,
            BankAccountRunningBalance = bankAccountRunningBalance - command.Amount!.Value,
            PlaidTransactionId = plaidtx.Id,
            Type = TransactionType.Maintenance,
            PaymentMethod = PaymentMethod.BankTransfer,
        };

        decimal currentRunningBalance = await _transactionRepository.GetLastPropertyRunningBalanceAsync(maintenanceCharge.Maintenance.PropertyId);

        Transaction tx = MaintenancePayment.CreateTransaction(maintenanceCharge.Maintenance.PropertyId,
                                                              command.Amount!.Value,
                                                              maintenanceCharge.Maintenance.Title,
                                                              currentRunningBalance,
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

        maintenanceCharge.Transaction.Status = maintenanceCharge.Transaction.Amount == txAppl.AppliedAmount ? TransactionStatus.Paid : TransactionStatus.PartiallyPaid;

        await _paymentRepository.AddAsync(newPayment);
        await _transactionRepository.AddAsync(tx);
        await _transactionApplicationRepository.AddAsync(txAppl);
        _transactionRepository.Update(maintenanceCharge.Transaction);
        _maintenanceChargeRepository.Update(maintenanceCharge);
        await _maintenancePaymentRepository.AddAsync(maintenancePayment);
        _plaidRepository.Update(plaidtx);

        await _unitOfWork.SaveChangesAsync();

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

        decimal runningBalance = await _paymentRepository.GetLastPropertyPaymentRunningBalanceAsync(maintenanceCharge.Maintenance.PropertyId);
        decimal bankAccountRunningBalance = await _paymentRepository.GetLastBankAccountRunningBalanceAsync(plaidtx.OwnerBankAccountId);

        Payment newPayment = new()
        {
            Amount = command.Amount!.Value,
            Description = $"Payment of {maintenanceCharge.Maintenance.Title}",
            Date = plaidtx.Date,
            OwnerBankAccountId = plaidtx.OwnerBankAccountId,
            PropertyId = maintenanceCharge.Maintenance.PropertyId,
            RunningBalance = runningBalance + command.Amount!.Value,
            BankAccountRunningBalance = bankAccountRunningBalance + command.Amount!.Value,
            PlaidTransactionId = plaidtx.Id,
            Type = TransactionType.Maintenance,
            PaymentMethod = PaymentMethod.BankTransfer,
        };

        decimal currentRunningBalance = await _transactionRepository.GetLastPropertyRunningBalanceAsync(maintenanceCharge.Maintenance.PropertyId);

        Transaction tx = MaintenancePayment.CreateTransaction(maintenanceCharge.Maintenance.PropertyId,
                                                              command.Amount!.Value,
                                                              maintenanceCharge.Maintenance.Title,
                                                              currentRunningBalance,
                                                              plaidtx.Date);


        var currentTotalAmountTxAp = await _transactionApplicationRepository.GetTotalAppliedAmountByChargeTransactionAsync(maintenanceCharge.TransactionId);

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


        maintenanceCharge.Transaction.Status = maintenanceCharge.Transaction.Amount == newTotalAmountTxAp ? TransactionStatus.Paid : TransactionStatus.PartiallyPaid;

        await _paymentRepository.AddAsync(newPayment);
        await _transactionRepository.AddAsync(tx);
        await _transactionApplicationRepository.AddAsync(txAppl);
        _transactionRepository.Update(maintenanceCharge.Transaction);
        _maintenanceChargeRepository.Update(maintenanceCharge);
        await _maintenancePaymentRepository.AddAsync(maintenancePayment);
        _plaidRepository.Update(plaidtx);

        await _unitOfWork.SaveChangesAsync();

        CreateMaintenancePaymentCommandResponse response = new()
        {
            Id = plaidtx.Id
        };

        return OperationResult<CreateMaintenancePaymentCommandResponse>.SuccessResult(response);

    }
}
