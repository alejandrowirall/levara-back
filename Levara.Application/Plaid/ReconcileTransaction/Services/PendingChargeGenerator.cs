using Levara.Application.ExpenseCharges.Create;
using Levara.Application.LeaseCharges.Create;
using Levara.Application.MaintenancesCharges.Create;
using Levara.Domain.DAL;
using Levara.Domain.DAL.Repositories;
using Levara.Domain.Enum;
using Levara.Domain.Models;
using Microsoft.Extensions.Logging;

namespace Levara.Application.Plaid.ReconcileTransaction.Services;

public class PendingChargeGenerator
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IRecurringChargeInstanceRepository _instanceRepository;
    private readonly IRecurringChargeRepository _recurringChargeRepository;
    private readonly CreateLeaseChargeCommandService _leaseChargeService;
    private readonly CreateExpenseChargeCommandService _expenseChargeService;
    private readonly CreateMaintenanceChargeCommandService _maintenanceChargeService;
    private readonly ILogger<PendingChargeGenerator> _logger;

    public PendingChargeGenerator(
        IUnitOfWork unitOfWork,
        IRecurringChargeInstanceRepository instanceRepository,
        IRecurringChargeRepository recurringChargeRepository,
        CreateLeaseChargeCommandService leaseChargeService,
        CreateExpenseChargeCommandService expenseChargeService,
        CreateMaintenanceChargeCommandService maintenanceChargeService,
        ILogger<PendingChargeGenerator> logger)
    {
        _unitOfWork = unitOfWork;
        _instanceRepository = instanceRepository;
        _recurringChargeRepository = recurringChargeRepository;
        _leaseChargeService = leaseChargeService;
        _expenseChargeService = expenseChargeService;
        _maintenanceChargeService = maintenanceChargeService;
        _logger = logger;
    }

    public async Task GenerateAsync(IEnumerable<RecurringCharge> recurringCharges, DateTime utcNow)
    {
        foreach (var rc in recurringCharges)
        {
            if (!rc.Active || !rc.NextChargeDate.HasValue)
                continue;

            while (rc.NextChargeDate.Value <= utcNow &&
                   rc.NextChargeDate.Value <= rc.EndDate!.Value)
            {
                try
                {
                    await _unitOfWork.ExecuteAsTransactionAsync(async () =>
                    {
                        if (await InstanceExistsAsync(rc))
                        {
                            AdvanceNextDate(rc);
                            return;
                        }

                        var transactionId = await CreateChargeByTypeAsync(rc);
                        if (transactionId.HasValue)
                        {
                            await _instanceRepository.AddAsync(new RecurringChargeInstance
                            {
                                RecurringChargeId = rc.Id,
                                TransactionId = transactionId.Value
                            });

                            _logger.LogInformation(
                                "Generated pending {Type} charge for RC {RcId}, Date: {Date}",
                                rc.Type, rc.Id, rc.NextChargeDate.Value);
                        }

                        AdvanceNextDate(rc);
                        await _unitOfWork.SaveChangesAsync();
                    });
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex,
                        "Error generating charge for RC {RcId}, Date: {Date}",
                        rc.Id, rc.NextChargeDate);
                    break;
                }
            }
        }
    }

    private async Task<int?> CreateChargeByTypeAsync(RecurringCharge rc)
    {
        return rc.Type switch
        {
            TransactionType.Lease => await CreateLeaseChargeAsync(rc),
            TransactionType.Expense => await CreateExpenseChargeAsync(rc),
            TransactionType.Maintenance => await CreateMaintenanceChargeAsync(rc),
            _ => null
        };
    }

    private async Task<int?> CreateLeaseChargeAsync(RecurringCharge rc)
    {
        var response = await _leaseChargeService.Handle(new CreateLeaseChargeCommand
        {
            OwnerId = rc.Property.OwnerId,
            PropertyId = rc.PropertyId,
            LeaseId = rc.LeaseId!.Value,
            Amount = rc.Amount!.Value,
            Description = $"{rc.LeaseChargeType!.Name} - Auto Generated",
            Date = rc.NextChargeDate!.Value,
            DueDate = rc.NextChargeDate.Value,
            TypeId = rc.LeaseChargeTypeId!
        });
        return response.Success ? response.Result!.Id : null;
    }

    private async Task<int?> CreateExpenseChargeAsync(RecurringCharge rc)
    {
        var response = await _expenseChargeService.Handle(new CreateExpenseChargeCommand
        {
            OwnerId = rc.Property.OwnerId,
            PropertyId = rc.PropertyId,
            Amount = rc.Amount!.Value,
            Date = rc.NextChargeDate!.Value,
            DueDate = rc.NextChargeDate.Value,
            ExpenseId = rc.ExpenseId!.Value
        });
        return response.Success ? response.Result!.Id : null;
    }

    private async Task<int?> CreateMaintenanceChargeAsync(RecurringCharge rc)
    {
        var response = await _maintenanceChargeService.Handle(new CreateMaintenanceChargeCommand
        {
            OwnerId = rc.Property.OwnerId,
            PropertyId = rc.PropertyId,
            Amount = rc.Amount!.Value,
            Title = rc.MaintenanceType?.Description,
            Description = $"{rc.Type} - Auto Generated",
            Date = rc.NextChargeDate!.Value,
            DueDate = rc.NextChargeDate.Value,
            TypeId = rc.MaintenanceTypeId!.Value
        });
        return response.Success ? response.Result!.Id : null;
    }

    private async Task<bool> InstanceExistsAsync(RecurringCharge rc)
    {
        var query = _instanceRepository.GetAllFull()
            .Where(i => i.RecurringChargeId == rc.Id)
            .Where(i => i.Transaction!.Date.Date == rc.NextChargeDate!.Value.Date);
        return await _instanceRepository.FirstOrDefaultAsync(query) != null;
    }

    private void AdvanceNextDate(RecurringCharge rc)
    {
        rc.NextChargeDate = rc.CalculateNextDate(rc.NextChargeDate!.Value);
        _recurringChargeRepository.Update(rc);
    }
}
