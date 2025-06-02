using Levara.Domain.DAL;
using Levara.Domain.DAL.Repositories;
using Levara.Domain.Enum;
using Levara.Domain.Models;
using Levara.Shared.Domain.Bus.Commands;
using Levara.Shared.Extensions;
using Levara.Shared.Results;

namespace Levara.Application.Plaid.ReconcileTransaction;

public class ReconcileTransactionCommandHandler : ICommandHandler<ReconcileTransactionCommand, ReconcileTransactionCommandResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IPlaidRepository _plaidRepository;
    private readonly IExpenseChargeRepository _expenseChargeRepository;
    private readonly ILeaseChargeRepository _leaseChargeRepository;
    private readonly IMaintenanceChargeRepository _maintenanceChargeRepository;
    private readonly IPlaidReconciliationRepository _plaidReconciliationRepository;

    public ReconcileTransactionCommandHandler(IUnitOfWork unitOfWork,
        IPlaidRepository plaidRepository,
        IExpenseChargeRepository expenseChargeRepository,
        ILeaseChargeRepository leaseChargeRepository,
        IMaintenanceChargeRepository maintenanceChargeRepository,
        IPlaidReconciliationRepository plaidReconciliationRepository)
    {
        _unitOfWork = unitOfWork;
        _plaidRepository = plaidRepository;
        _expenseChargeRepository = expenseChargeRepository;
        _leaseChargeRepository = leaseChargeRepository;
        _maintenanceChargeRepository = maintenanceChargeRepository;
        _plaidReconciliationRepository = plaidReconciliationRepository;
    }

    public async Task<OperationResult<ReconcileTransactionCommandResponse>> Handle(ReconcileTransactionCommand command)
    {
        var plaidTxQuery = _plaidRepository.GetAllWithOwnerBankAccount()
                                           .Where(o => o.Id == command.PlaidId!);

        PlaidTransaction? plaidtx = await _plaidRepository.FirstOrDefaultAsync(plaidTxQuery);
        if (plaidtx == null)
            return OperationResult<ReconcileTransactionCommandResponse>.ErrorResult(new ErrorDetails(404, "Not found"));

        if (plaidtx.Status != PlaidTransactionStatus.Created)
            return OperationResult<ReconcileTransactionCommandResponse>.ErrorResult(new ErrorDetails(400, $"Plaid transaction must be in state {EnumExtensions.GetEnumDescription(PlaidTransactionStatus.Created)}"));

        List<PlaidReconciliation> reconciliations = new();

        await ReconcileLeaseTransaction(plaidtx, reconciliations);
        await ReconcileMaintenanceTransaction(plaidtx, reconciliations);
        await ReconcileExpenseTransaction(plaidtx, reconciliations);

        await _unitOfWork.ExecuteAsTransactionAsync(async () =>
        {
            if (reconciliations.Count == 0)
            {
                plaidtx.Status = PlaidTransactionStatus.PersonalPayment;
                _plaidRepository.Update(plaidtx);
                return;
            }

            plaidtx.Status = PlaidTransactionStatus.NeedReview;
            _plaidRepository.Update(plaidtx);
            await _plaidReconciliationRepository.AddAsync(reconciliations);
        });

        return OperationResult<ReconcileTransactionCommandResponse>.SuccessResult(new ReconcileTransactionCommandResponse(plaidtx.Id));
    }

    private async Task ReconcileLeaseTransaction(PlaidTransaction plaidtx,
        List<PlaidReconciliation> reconciliations)
    {
        int ownerId = plaidtx.OwnerBankAccount.OwnerId;
        decimal plaidtxAmount = plaidtx.Amount;

        int plaidYear = plaidtx.Date.Year;
        int plaidMonth = plaidtx.Date.Month;

        var leaseChargeQuery = _leaseChargeRepository.GetAllFull().Where(lc =>
            lc.Lease.Property.OwnerId == ownerId &&
            lc.Status == LeaseChargeStatus.Unpaid &&
            (lc.Transaction.Amount == plaidtxAmount || lc.Transaction.Amount == ((-1) * plaidtxAmount)) &&
            lc.Transaction.Date.Year == plaidYear &&
            lc.Transaction.Date.Month == plaidMonth);

        var leaseCharges = await _leaseChargeRepository.ToListAsync(leaseChargeQuery);
        if (leaseCharges.Count() == 0)
            return;

        foreach (var leaseCharge in leaseCharges)
        {
            PlaidReconciliation reconciliation = new()
            {
                TransactionId = leaseCharge.TransactionId,
                PlaidTransactionId = plaidtx.Id
            };
            reconciliations.Add(reconciliation);
        }
    }

    private async Task ReconcileMaintenanceTransaction(PlaidTransaction plaidtx,
        List<PlaidReconciliation> reconciliations)
    {
        int ownerId = plaidtx.OwnerBankAccount.OwnerId;
        decimal plaidtxAmount = plaidtx.Amount;

        int plaidYear = plaidtx.Date.Year;
        int plaidMonth = plaidtx.Date.Month;

        var maintenanceChargeQuery = _maintenanceChargeRepository.GetAllFull().Where(mc =>
            mc.Maintenance.Property.OwnerId == ownerId &&
            mc.Status == MaintenanceChargeStatus.Unpaid &&
            (mc.Transaction.Amount == plaidtxAmount || mc.Transaction.Amount == ((-1) * plaidtxAmount)) &&
            mc.Transaction.Date.Year == plaidYear &&
            mc.Transaction.Date.Month == plaidMonth);

        var maintenanceCharges = await _maintenanceChargeRepository.ToListAsync(maintenanceChargeQuery);
        if (maintenanceCharges.Count() == 0)
            return;

        foreach (var maintenanceCharge in maintenanceCharges)
        {
            PlaidReconciliation reconciliation = new()
            {
                TransactionId = maintenanceCharge.TransactionId,
                PlaidTransactionId = plaidtx.Id
            };
            reconciliations.Add(reconciliation);
        }
    }

    private async Task ReconcileExpenseTransaction(PlaidTransaction plaidtx,
        List<PlaidReconciliation> reconciliations)
    {
        int ownerId = plaidtx.OwnerBankAccount.OwnerId;
        decimal plaidtxAmount = plaidtx.Amount;

        int plaidYear = plaidtx.Date.Year;
        int plaidMonth = plaidtx.Date.Month;

        var expenseChargeQuery = _expenseChargeRepository.GetAllFull().Where(ec =>
            ec.Transaction.Property.OwnerId == ownerId &&
            ec.Status == ExpenseChargeStatus.Unpaid &&
            (ec.Transaction.Amount == plaidtxAmount || ec.Transaction.Amount == ((-1) * plaidtxAmount)) &&
            ec.Transaction.Date.Year == plaidYear &&
            ec.Transaction.Date.Month == plaidMonth);

        var expenseCharges = await _expenseChargeRepository.ToListAsync(expenseChargeQuery);
        if (expenseCharges.Count() == 0)
            return;

        foreach (var expenseCharge in expenseCharges)
        {
            PlaidReconciliation reconciliation = new()
            {
                TransactionId = expenseCharge.TransactionId,
                PlaidTransactionId = plaidtx.Id
            };
            reconciliations.Add(reconciliation);
        }
    }
}