using Levara.Application.ExpenseCharges.Create;
using Levara.Application.LeaseCharges.Create;
using Levara.Application.MaintenancesCharges.Create;
using Levara.Application.Plaid.CreateExpensePayment;
using Levara.Application.Plaid.CreateLeasePayment;
using Levara.Application.Plaid.CreateMaintenancePayment;
using Levara.Application.Plaid.ReconcileTransaction.Models;
using Levara.Domain.DAL;
using Levara.Domain.DAL.Repositories;
using Levara.Domain.Enum;
using Levara.Domain.Models;
using Microsoft.Extensions.Logging;

namespace Levara.Application.Plaid.ReconcileTransaction.Services;

public class ReconciliationPaymentApplier
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IRecurringChargeInstanceRepository _instanceRepository;
    private readonly IRecurringChargeRepository _recurringChargeRepository;
    private readonly IPlaidReconciliationRepository _reconciliationRepository;

    private readonly CreateLeasePaymentCommandService _leasePaymentService;
    private readonly CreateExpensePaymentCommandService _expensePaymentService;
    private readonly CreateMaintenancePaymentCommandService _maintenancePaymentService;

    private readonly CreateLeaseChargeCommandService _leaseChargeService;
    private readonly CreateExpenseChargeCommandService _expenseChargeService;
    private readonly CreateMaintenanceChargeCommandService _maintenanceChargeService;

    private readonly ILogger<ReconciliationPaymentApplier> _logger;

    public ReconciliationPaymentApplier(
        IUnitOfWork unitOfWork,
        IRecurringChargeInstanceRepository instanceRepository,
        IRecurringChargeRepository recurringChargeRepository,
        IPlaidReconciliationRepository reconciliationRepository,
        CreateLeasePaymentCommandService leasePaymentService,
        CreateExpensePaymentCommandService expensePaymentService,
        CreateMaintenancePaymentCommandService maintenancePaymentService,
        CreateLeaseChargeCommandService leaseChargeService,
        CreateExpenseChargeCommandService expenseChargeService,
        CreateMaintenanceChargeCommandService maintenanceChargeService,
        ILogger<ReconciliationPaymentApplier> logger)
    {
        _unitOfWork = unitOfWork;
        _instanceRepository = instanceRepository;
        _recurringChargeRepository = recurringChargeRepository;
        _reconciliationRepository = reconciliationRepository;
        _leasePaymentService = leasePaymentService;
        _expensePaymentService = expensePaymentService;
        _maintenancePaymentService = maintenancePaymentService;
        _leaseChargeService = leaseChargeService;
        _expenseChargeService = expenseChargeService;
        _maintenanceChargeService = maintenanceChargeService;
        _logger = logger;
    }

    public async Task<bool> ApplyAsync(
        PlaidReconciliation reconciliation,
        ChargeCandidate candidate,
        PlaidTransaction plaidTx)
    {
        var amount = Math.Abs(reconciliation.ActualAmount);
        var ownerId = plaidTx.OwnerBankAccount!.OwnerId;

        // Rama 1: cargo real ya existe → solo crear pago
        if (candidate.TransactionId.HasValue && candidate.SourceTransaction != null)
        {
            return await PayExistingChargeAsync(
                reconciliation, candidate.SourceTransaction, plaidTx, amount, ownerId);
        }

        // Rama 2: candidato virtual → crear cargo + pago
        if (candidate.SourceRecurringCharge != null)
        {
            return await CreateChargeAndPayAsync(
                reconciliation, candidate.SourceRecurringCharge, plaidTx, amount, ownerId);
        }

        _logger.LogWarning("No source entity for candidate RC:{RcId} TX:{TxId}",
            candidate.RecurringChargeId, candidate.TransactionId);
        return false;
    }

    private async Task<bool> PayExistingChargeAsync(
        PlaidReconciliation reconciliation,
        Transaction existingTx,
        PlaidTransaction plaidTx,
        decimal amount,
        int ownerId)
    {
        var success = existingTx.Type switch
        {
            TransactionType.Lease => (await _leasePaymentService.Handle(new CreateLeasePaymentCommand
            {
                PlaidId = plaidTx.Id,
                OwnerId = ownerId,
                TransactionId = existingTx.Id,
                Amount = amount
            })).Success,

            TransactionType.Expense => (await _expensePaymentService.Handle(new CreateExpensePaymentCommand
            {
                PlaidId = plaidTx.Id,
                OwnerId = ownerId,
                TransactionId = existingTx.Id,
                Amount = amount
            })).Success,

            TransactionType.Maintenance => (await _maintenancePaymentService.Handle(new CreateMaintenancePaymentCommand
            {
                PlaidId = plaidTx.Id,
                OwnerId = ownerId,
                TransactionId = existingTx.Id,
                Amount = amount
            })).Success,

            _ => false
        };

        return success;
    }

    private async Task<bool> CreateChargeAndPayAsync(
        PlaidReconciliation reconciliation,
        RecurringCharge rc,
        PlaidTransaction plaidTx,
        decimal amount,
        int ownerId)
    {
        return rc.Type switch
        {
            TransactionType.Lease => await CreateAndPayLeaseAsync(reconciliation, rc, plaidTx, amount, ownerId),
            TransactionType.Expense => await CreateAndPayExpenseAsync(reconciliation, rc, plaidTx, amount, ownerId),
            TransactionType.Maintenance => await CreateAndPayMaintenanceAsync(reconciliation, rc, plaidTx, amount, ownerId),
            _ => false
        };
    }

    private async Task<bool> CreateAndPayLeaseAsync(
        PlaidReconciliation reconciliation,
        RecurringCharge rc,
        PlaidTransaction plaidTx,
        decimal amount,
        int ownerId)
    {
        var chargeResponse = await _leaseChargeService.Handle(new CreateLeaseChargeCommand
        {
            OwnerId = ownerId,
            PropertyId = rc.PropertyId,
            LeaseId = rc.LeaseId,
            Amount = amount,
            Description = reconciliation.MatchedDescription,
            Date = plaidTx.Date,
            DueDate = rc.NextChargeDate ?? plaidTx.Date,
            TypeId = rc.LeaseChargeTypeId
        });

        if (!chargeResponse.Success) return false;

        var paymentResponse = await _leasePaymentService.Handle(new CreateLeasePaymentCommand
        {
            PlaidId = plaidTx.Id,
            OwnerId = ownerId,
            TransactionId = chargeResponse.Result!.Id,
            Amount = amount
        });

        if (!paymentResponse.Success) return false;

        await RegisterInstanceAndUpdateReconciliation(reconciliation, rc, chargeResponse.Result!.Id);
        return true;
    }

    private async Task<bool> CreateAndPayExpenseAsync(
        PlaidReconciliation reconciliation,
        RecurringCharge rc,
        PlaidTransaction plaidTx,
        decimal amount,
        int ownerId)
    {
        var chargeResponse = await _expenseChargeService.Handle(new CreateExpenseChargeCommand
        {
            OwnerId = ownerId,
            PropertyId = rc.PropertyId,
            Amount = amount,
            Date = plaidTx.Date,
            DueDate = rc.NextChargeDate ?? plaidTx.Date,
            ExpenseId = rc.ExpenseId
        });

        if (!chargeResponse.Success) return false;

        var paymentResponse = await _expensePaymentService.Handle(new CreateExpensePaymentCommand
        {
            PlaidId = plaidTx.Id,
            OwnerId = ownerId,
            TransactionId = chargeResponse.Result!.Id,
            Amount = amount
        });

        if (!paymentResponse.Success) return false;

        await RegisterInstanceAndUpdateReconciliation(reconciliation, rc, chargeResponse.Result!.Id);
        return true;
    }

    private async Task<bool> CreateAndPayMaintenanceAsync(
        PlaidReconciliation reconciliation,
        RecurringCharge rc,
        PlaidTransaction plaidTx,
        decimal amount,
        int ownerId)
    {
        var chargeResponse = await _maintenanceChargeService.Handle(new CreateMaintenanceChargeCommand
        {
            OwnerId = ownerId,
            PropertyId = rc.PropertyId,
            Amount = amount,
            Title = rc.MaintenanceType?.Description,
            Description = reconciliation.MatchedDescription,
            Date = plaidTx.Date,
            DueDate = rc.NextChargeDate ?? plaidTx.Date,
            TypeId = rc.MaintenanceTypeId
        });

        if (!chargeResponse.Success) return false;

        var paymentResponse = await _maintenancePaymentService.Handle(new CreateMaintenancePaymentCommand
        {
            PlaidId = plaidTx.Id,
            OwnerId = ownerId,
            TransactionId = chargeResponse.Result!.Id,
            Amount = amount
        });

        if (!paymentResponse.Success) return false;

        await RegisterInstanceAndUpdateReconciliation(reconciliation, rc, chargeResponse.Result!.Id);
        return true;
    }

    private async Task RegisterInstanceAndUpdateReconciliation(
        PlaidReconciliation reconciliation,
        RecurringCharge rc,
        int transactionId)
    {
        await _instanceRepository.AddAsync(new RecurringChargeInstance
        {
            RecurringChargeId = rc.Id,
            TransactionId = transactionId
        });

        if (rc.IsRecurrent && rc.NextChargeDate.HasValue)
        {
            rc.NextChargeDate = rc.CalculateNextDate(rc.NextChargeDate.Value);
            _recurringChargeRepository.Update(rc);
        }

        reconciliation.TransactionId = transactionId;
        _reconciliationRepository.Update(reconciliation);

        await _unitOfWork.SaveChangesAsync();
    }
}
