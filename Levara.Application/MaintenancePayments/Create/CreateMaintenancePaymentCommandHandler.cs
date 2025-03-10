using Levara.Domain.DAL;
using Levara.Domain.DAL.Repositories;
using Levara.Domain.Enum;
using Levara.Domain.Models;
using Levara.Shared.Domain.Bus.Commands;
using Levara.Shared.Results;
using Microsoft.EntityFrameworkCore;

namespace Levara.Application.MaintenancePayments.Create;

public class CreateMaintenancePaymentCommandHandler : ICommandHandler<CreateMaintenancePaymentCommand, CreateMaintenancePaymentCommandResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IPaymentRepository _paymentRepository;
    private readonly IMaintenanceRepository _maintenanceRepository;
    private readonly IMaintenanceChargeRepository _maintenanceChargeRepository;
    private readonly IMaintenancePaymentRepository _maintenancePaymentRepository;
    private readonly ITransactionRepository _transactionRepository;
    private readonly ITransactionApplicationRepository _transactionApplicationRepository;
    public CreateMaintenancePaymentCommandHandler(IUnitOfWork unitOfWork,
        IPaymentRepository paymentRepository,
        IMaintenanceRepository maintenanceRepository,
        IMaintenanceChargeRepository maintenanceChargeRepository,
        IMaintenancePaymentRepository maintenancePaymentRepository,
        ITransactionRepository transactionRepository,
        ITransactionApplicationRepository transactionApplicationrepository)
    {
        _unitOfWork = unitOfWork;
        _paymentRepository = paymentRepository;
        _maintenanceRepository = maintenanceRepository;
        _maintenanceChargeRepository = maintenanceChargeRepository;
        _maintenancePaymentRepository = maintenancePaymentRepository;
        _transactionRepository = transactionRepository;
        _transactionApplicationRepository = transactionApplicationrepository;
    }
    public async Task<OperationResult<CreateMaintenancePaymentCommandResponse>> Handle(CreateMaintenancePaymentCommand command)
    {
        if (command.MaintenanceChargeId.HasValue)
            return await GenerateMaintenancePaymentWithCharge(command);

        return await GenerateMaintenancePaymentWithoutCharge(command);
    }

    private async Task<OperationResult<CreateMaintenancePaymentCommandResponse>> GenerateMaintenancePaymentWithoutCharge(CreateMaintenancePaymentCommand command)
    {

        var lastPropertyPaymentQuery = _paymentRepository.GetAll()
                                                         .Where(b => b.PropertyId == command.CreateMaintenance!.PropertyId!.Value)
                                                         .OrderByDescending(o => o.CreatedDate);

        decimal runningBalance = 0;
        Payment? lastPropertyPayment = await _paymentRepository.FirstOrDefaultAsync(lastPropertyPaymentQuery);
        if (lastPropertyPayment != null)
            runningBalance = lastPropertyPayment.RunningBalance;

        Payment newPayment = new()
        {
            Amount = command.Amount!.Value,
            Description = $"Payment of {command.CreateMaintenance!.Title}",
            Date = DateTime.UtcNow,
            OwnerBankAccountId = null,
            PropertyId = command.CreateMaintenance!.PropertyId!.Value,
            RunningBalance = runningBalance - command.Amount!.Value,
            BankAccountBalance = null,
            PlaidTransactionId = null,
            Type = TransactionType.Maintenance,
            PaymentMethod = PaymentMethod.Cash,
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
        });


        CreateMaintenancePaymentCommandResponse response = new()
        {
            Id = newPayment.Id
        };

        return OperationResult<CreateMaintenancePaymentCommandResponse>.SuccessResult(response);

    }

    private async Task<OperationResult<CreateMaintenancePaymentCommandResponse>> GenerateMaintenancePaymentWithCharge(CreateMaintenancePaymentCommand command)
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
            return await GenerateMaintenancePaymentFromUnpaid(maintenanceCharge, command);

        return await GenerateMaintenancePaymentFromPartpaid(maintenanceCharge, command);
    }

    private async Task<OperationResult<CreateMaintenancePaymentCommandResponse>> GenerateMaintenancePaymentFromUnpaid(MaintenanceCharge maintenanceCharge,
       CreateMaintenancePaymentCommand command)
    {

        var lastPropertyPaymentQuery = _paymentRepository.GetAll()
                                                         .Where(b => b.PropertyId == maintenanceCharge.Maintenance.PropertyId)
                                                         .OrderByDescending(o => o.CreatedDate);

        decimal runningBalance = 0;
        Payment? lastPropertyPayment = await _paymentRepository.FirstOrDefaultAsync(lastPropertyPaymentQuery);
        if (lastPropertyPayment != null)
            runningBalance = lastPropertyPayment.RunningBalance;

        Payment newPayment = new()
        {
            Amount = command.Amount!.Value,
            Description = $"Payment of {maintenanceCharge.Maintenance.Title}",
            Date = DateTime.UtcNow,
            OwnerBankAccountId = null,
            PropertyId = maintenanceCharge.Maintenance.PropertyId,
            RunningBalance = runningBalance - command.Amount!.Value,
            BankAccountBalance = null,
            PlaidTransactionId = null,
            Type = TransactionType.Maintenance,
            PaymentMethod = PaymentMethod.Cash,
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
                                                              lastTx.EntityRunningBalance);

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
        });


        CreateMaintenancePaymentCommandResponse response = new()
        {
            Id = newPayment.Id
        };

        return OperationResult<CreateMaintenancePaymentCommandResponse>.SuccessResult(response);

    }

    private async Task<OperationResult<CreateMaintenancePaymentCommandResponse>> GenerateMaintenancePaymentFromPartpaid(MaintenanceCharge maintenanceCharge,
        CreateMaintenancePaymentCommand command)
    {


        var lastPropertyPaymentQuery = _paymentRepository.GetAll()
                                                        .Where(b => b.PropertyId == maintenanceCharge.Maintenance.PropertyId)
                                                        .OrderByDescending(o => o.CreatedDate);

        decimal runningBalance = 0;
        Payment? lastPropertyPayment = await _paymentRepository.FirstOrDefaultAsync(lastPropertyPaymentQuery);
        if (lastPropertyPayment != null)
            runningBalance = lastPropertyPayment.RunningBalance;

        Payment newPayment = new()
        {
            Amount = command.Amount!.Value,
            Description = $"Maintenance payment {maintenanceCharge.Maintenance.Title}",
            Date = DateTime.UtcNow,
            OwnerBankAccountId = null,
            PropertyId = maintenanceCharge.Maintenance.PropertyId,
            RunningBalance = runningBalance - command.Amount!.Value,
            BankAccountBalance = null,
            PlaidTransactionId = null,
            Type = TransactionType.Maintenance,
            PaymentMethod = PaymentMethod.Cash,
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
                                                              lastTx.EntityRunningBalance);

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
        });


        CreateMaintenancePaymentCommandResponse response = new()
        {
            Id = newPayment.Id
        };

        return OperationResult<CreateMaintenancePaymentCommandResponse>.SuccessResult(response);

    }
}
