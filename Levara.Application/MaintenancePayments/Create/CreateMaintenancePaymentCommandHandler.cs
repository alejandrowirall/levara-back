using Levara.Domain.DAL;
using Levara.Domain.DAL.Repositories;
using Levara.Domain.Enum;
using Levara.Domain.Models;
using Levara.Shared.Domain.Bus.Commands;
using Levara.Shared.Results;

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
        if (command.TransactionId.HasValue)
            return await GenerateMaintenancePaymentWithCharge(command);

        return await GenerateMaintenancePaymentWithoutCharge(command);
    }

    private async Task<OperationResult<CreateMaintenancePaymentCommandResponse>> GenerateMaintenancePaymentWithoutCharge(CreateMaintenancePaymentCommand command)
    {
        decimal paymentRunningBalance = await _paymentRepository.GetLastPropertyPaymentRunningBalanceAsync(command.CreateMaintenance!.PropertyId!.Value);

        Payment newPayment = new()
        {
            Amount = command.Amount!.Value,
            Description = $"Payment of {command.CreateMaintenance!.Title}",
            Date = command.Date.HasValue ? command.Date!.Value : DateTime.UtcNow,
            OwnerBankAccountId = null,
            PropertyId = command.CreateMaintenance!.PropertyId!.Value,
            RunningBalance = paymentRunningBalance - command.Amount!.Value,
            BankAccountRunningBalance = null,
            PlaidTransactionId = null,
            Type = TransactionType.Maintenance,
            PaymentMethod = PaymentMethod.Cash,
        };

        decimal currentPropertyRunningBalance = await _transactionRepository.GetLastPropertyRunningBalanceAsync(command.CreateMaintenance!.PropertyId!.Value);

        Maintenance newMaintenance = new()
        {
            PropertyId = command.CreateMaintenance!.PropertyId!.Value,
            Title = command.CreateMaintenance.Title,
            Status = MaintenanceStatus.Completed,
            TypeId = command.CreateMaintenance!.TypeId!.Value,
            DueDate = newPayment.Date,
            Description = command.CreateMaintenance.Description
        };

        Transaction newMaintenanceChargeTx =
            MaintenanceCharge.CreateTransaction(command.CreateMaintenance!.PropertyId!.Value,
                                                command.Amount!.Value,
                                                newMaintenance.Title,
                                                currentPropertyRunningBalance,
                                                newPayment.Date);

        newMaintenanceChargeTx.Status = TransactionStatus.Paid;

        MaintenanceCharge newMaintenanceCharge = new()
        {
            Transaction = newMaintenanceChargeTx,
            Maintenance = newMaintenance
        };

        Transaction newMaintenancePaymentTx =
            MaintenancePayment.CreateTransaction(command.CreateMaintenance!.PropertyId!.Value,
                                                command.Amount!.Value,
                                                newMaintenance.Title,
                                                newMaintenanceChargeTx.RunningBalance,
                                                newPayment.Date);

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

            await _transactionRepository.AddAsync(newMaintenanceChargeTx);

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
                                                                 .Where(b => b.TransactionId == command.TransactionId);

        MaintenanceCharge? maintenanceCharge = await _maintenanceChargeRepository.FirstOrDefaultAsync(maintenanceChargeQuery);
        if (maintenanceCharge == null)
            return OperationResult<CreateMaintenancePaymentCommandResponse>.ErrorResult(new ErrorDetails(404, $"Not found maintenance charge with TransactionId: {command.TransactionId}"));

        if (maintenanceCharge.Maintenance.Property.OwnerId != command.OwnerId)
            return OperationResult<CreateMaintenancePaymentCommandResponse>.ErrorResult(new ErrorDetails(400, "The charge does not belong to a property of the owner"));

        if (maintenanceCharge.Transaction.Status == TransactionStatus.Paid)
            return OperationResult<CreateMaintenancePaymentCommandResponse>.ErrorResult(new ErrorDetails(400, "The charge must not be in paid status"));

        if (maintenanceCharge.Transaction.Status == TransactionStatus.Unpaid)
            return await GenerateMaintenancePaymentFromUnpaid(maintenanceCharge, command);

        return await GenerateMaintenancePaymentFromPartpaid(maintenanceCharge, command);
    }

    private async Task<OperationResult<CreateMaintenancePaymentCommandResponse>> GenerateMaintenancePaymentFromUnpaid(MaintenanceCharge maintenanceCharge,
       CreateMaintenancePaymentCommand command)
    {

        decimal paymentRunningBalance = await _paymentRepository.GetLastPropertyPaymentRunningBalanceAsync(maintenanceCharge.Maintenance.PropertyId);

        Payment newPayment = new()
        {
            Amount = command.Amount!.Value,
            Description = $"Payment of {maintenanceCharge.Maintenance.Title}",
            Date = command.Date.HasValue ? command.Date!.Value : DateTime.UtcNow,
            OwnerBankAccountId = null,
            PropertyId = maintenanceCharge.Maintenance.PropertyId,
            RunningBalance = paymentRunningBalance - command.Amount!.Value,
            BankAccountRunningBalance = null,
            PlaidTransactionId = null,
            Type = TransactionType.Maintenance,
            PaymentMethod = PaymentMethod.Cash,
        };

        decimal currentPropertyRunningBalance = await _transactionRepository.GetLastPropertyRunningBalanceAsync(maintenanceCharge.Maintenance.PropertyId);

        Transaction tx = MaintenancePayment.CreateTransaction(maintenanceCharge.Maintenance.PropertyId,
                                                              command.Amount!.Value,
                                                              maintenanceCharge.Maintenance.Title,
                                                              currentPropertyRunningBalance,
                                                              newPayment.Date);

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

        await _unitOfWork.ExecuteAsTransactionAsync(async () =>
        {
            await _paymentRepository.AddAsync(newPayment);
            await _transactionRepository.AddAsync(tx);
            await _transactionApplicationRepository.AddAsync(txAppl);
            _transactionRepository.Update(maintenanceCharge.Transaction);
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

        decimal paymentRunningBalance = await _paymentRepository.GetLastPropertyPaymentRunningBalanceAsync(maintenanceCharge.Maintenance.PropertyId);

        Payment newPayment = new()
        {
            Amount = command.Amount!.Value,
            Description = $"Maintenance payment {maintenanceCharge.Maintenance.Title}",
            Date = command.Date.HasValue ? command.Date!.Value : DateTime.UtcNow,
            OwnerBankAccountId = null,
            PropertyId = maintenanceCharge.Maintenance.PropertyId,
            RunningBalance = paymentRunningBalance - command.Amount!.Value,
            BankAccountRunningBalance = null,
            PlaidTransactionId = null,
            Type = TransactionType.Maintenance,
            PaymentMethod = PaymentMethod.Cash,
        };

        // Obtener balance actual de la propiedad
        decimal currentPropertyRunningBalance = await _transactionRepository.GetLastPropertyRunningBalanceAsync(maintenanceCharge.Maintenance.PropertyId);

        Transaction tx = MaintenancePayment.CreateTransaction(maintenanceCharge.Maintenance.PropertyId,
                                                              command.Amount!.Value,
                                                              maintenanceCharge.Maintenance.Title,
                                                              currentPropertyRunningBalance, 
                                                              newPayment.Date);

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

        await _unitOfWork.ExecuteAsTransactionAsync(async () =>
        {
            await _paymentRepository.AddAsync(newPayment);
            await _transactionRepository.AddAsync(tx);
            await _transactionApplicationRepository.AddAsync(txAppl);
            _transactionRepository.Update(maintenanceCharge.Transaction);
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
