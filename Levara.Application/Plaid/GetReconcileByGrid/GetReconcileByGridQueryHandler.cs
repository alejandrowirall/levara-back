using Levara.Domain.DAL.Repositories;
using Levara.Domain.Enum;
using Levara.Domain.Models;
using Levara.Shared.Domain.Bus.Queries;
using Levara.Shared.Extensions;
using Levara.Shared.Results;
using Microsoft.EntityFrameworkCore;

namespace Levara.Application.Plaid.GetReconcileByGrid;

public class GetReconcileByGridQueryHandler : IQueryHandler<GetReconcileByGridQuery, List<GetReconcileByGridQueryResponse>>
{
    private readonly IExpenseChargeRepository _expenseChargeRepository;
    private readonly ILeaseChargeRepository _leaseChargeRepository;
    private readonly IMaintenanceChargeRepository _maintenanceChargeRepository;
    private readonly IPlaidReconciliationRepository _plaidReconciliationRepository;

    public GetReconcileByGridQueryHandler(IExpenseChargeRepository expenseChargeRepository,
        ILeaseChargeRepository leaseChargeRepository,
        IMaintenanceChargeRepository maintenanceChargeRepository,
        IPlaidReconciliationRepository plaidReconciliationRepository)
    {
        _expenseChargeRepository = expenseChargeRepository;
        _leaseChargeRepository = leaseChargeRepository;
        _maintenanceChargeRepository = maintenanceChargeRepository;
        _plaidReconciliationRepository = plaidReconciliationRepository;
    }
    public async Task<OperationResult<List<GetReconcileByGridQueryResponse>>> Handle(GetReconcileByGridQuery query)
    {

        var plaidReconciliationQuery = _plaidReconciliationRepository.GetAllFull()
                                                                     .Where(pr => pr.PlaidTransactionId == query.PlaidId! &&
                                                                                  pr.PlaidTransaction.OwnerBankAccount.OwnerId == query.OwnerId!.Value);

        var plaidReconciliations = await _plaidReconciliationRepository.ToListAsync(plaidReconciliationQuery);

        List<GetReconcileByGridQueryResponse> response = new();
        foreach (var plaidReconciliation in plaidReconciliations)
        {
            response.Add(new GetReconcileByGridQueryResponse(plaidReconciliation));
        }

        await SetChargeLease(response, plaidReconciliations);
        await SetChargeExpense(response, plaidReconciliations);
        await SetChargeMaintenance(response, plaidReconciliations);

        return OperationResult<List<GetReconcileByGridQueryResponse>>.SuccessResult(response);
    }

    private async Task SetChargeLease(List<GetReconcileByGridQueryResponse> response, IEnumerable<PlaidReconciliation> plaidReconciliations)
    {
        var transactionIds = plaidReconciliations.Where(pr => pr.Transaction.Type == TransactionType.Lease).Select(pr => pr.TransactionId);
        if (!transactionIds.Any())
            return;
        var leaseChargeQuery = _leaseChargeRepository.GetAll()
                                                     .Where(lc => transactionIds.Contains(lc.TransactionId));

        var leaseCharges = await _leaseChargeRepository.ToListAsync(leaseChargeQuery);
        foreach (var leaseCharge in leaseCharges)
        {
            var reconcileResponse = response.FirstOrDefault(r => r.TransactionId == leaseCharge.TransactionId);
            if (reconcileResponse != null)
            {
                reconcileResponse.ChargeId = leaseCharge.Id;
                reconcileResponse.StatusDescription = EnumExtensions.GetEnumDescription(leaseCharge.Status);
                reconcileResponse.DueDate = leaseCharge.DueDate;
            }
        }
    }

    private async Task SetChargeExpense(List<GetReconcileByGridQueryResponse> response, IEnumerable<PlaidReconciliation> plaidReconciliations)
    {
        var transactionIds = plaidReconciliations.Where(pr => pr.Transaction.Type == TransactionType.Expense).Select(pr => pr.TransactionId);
        if (!transactionIds.Any())
            return;
        var expenseChargeQuery = _expenseChargeRepository.GetAll()
                                                         .Where(ec => transactionIds.Contains(ec.TransactionId));
        var expenseCharges = await _expenseChargeRepository.ToListAsync(expenseChargeQuery);
        foreach (var expenseCharge in expenseCharges)
        {
            var reconcileResponse = response.FirstOrDefault(r => r.TransactionId == expenseCharge.TransactionId);
            if (reconcileResponse != null)
            {
                reconcileResponse.ChargeId = expenseCharge.Id;
                reconcileResponse.StatusDescription = EnumExtensions.GetEnumDescription(expenseCharge.Status);
                reconcileResponse.DueDate = expenseCharge.DueDate;
            }
        }
    }

    private async Task SetChargeMaintenance(List<GetReconcileByGridQueryResponse> response, IEnumerable<PlaidReconciliation> plaidReconciliations)
    {
        var transactionIds = plaidReconciliations.Where(pr => pr.Transaction.Type == TransactionType.Maintenance).Select(pr => pr.TransactionId);
        if (!transactionIds.Any())
            return;
        var maintenanceChargeQuery = _maintenanceChargeRepository.GetAll()
                                                                 .Where(mc => transactionIds.Contains(mc.TransactionId));
        var maintenanceCharges = await _maintenanceChargeRepository.ToListAsync(maintenanceChargeQuery);
        foreach (var maintenanceCharge in maintenanceCharges)
        {
            var reconcileResponse = response.FirstOrDefault(r => r.TransactionId == maintenanceCharge.TransactionId);
            if (reconcileResponse != null)
            {
                reconcileResponse.ChargeId = maintenanceCharge.Id;
                reconcileResponse.StatusDescription = EnumExtensions.GetEnumDescription(maintenanceCharge.Status);
                reconcileResponse.DueDate = maintenanceCharge.DueDate;
            }
        }
    }
}
