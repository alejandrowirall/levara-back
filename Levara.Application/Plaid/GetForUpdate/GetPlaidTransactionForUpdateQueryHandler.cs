
using Levara.Domain.DAL;
using Levara.Domain.DAL.Repositories;
using Levara.Domain.Enum;
using Levara.Domain.Models;
using Levara.Shared.Domain.Bus.Queries;
using Levara.Shared.Domain.Models;
using Levara.Shared.Extensions;
using Levara.Shared.Results;

namespace Levara.Application.Plaid.GetForUpdate;

public class GetPlaidTransactionForUpdateQueryHandler : IQueryHandler<GetPlaidTransactionForUpdateQuery, GetPlaidTransactionForUpdateQueryResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IPlaidRepository _plaidRepository;

    private readonly ITransactionApplicationRepository _transactionApplicationRepository;
    private readonly IExpenseChargeRepository _expenseChargeRepository;
    private readonly ILeaseChargeRepository _leaseChargeRepository;
    private readonly IMaintenanceChargeRepository _maintenanceChargeRepository;
    public GetPlaidTransactionForUpdateQueryHandler(IUnitOfWork unitOfWork,
        IPlaidRepository plaidRepository,
        ITransactionApplicationRepository transactionApplicationRepository,
        IExpenseChargeRepository expenseChargeRepository,
        ILeaseChargeRepository leaseChargeRepository,
        IMaintenanceChargeRepository maintenanceChargeRepository)
    {
        _unitOfWork = unitOfWork;
        _plaidRepository = plaidRepository;
        _transactionApplicationRepository = transactionApplicationRepository;
        _expenseChargeRepository = expenseChargeRepository;
        _leaseChargeRepository = leaseChargeRepository;
        _maintenanceChargeRepository = maintenanceChargeRepository;
    }
    public async Task<OperationResult<GetPlaidTransactionForUpdateQueryResponse>> Handle(GetPlaidTransactionForUpdateQuery query)
    {
        var plaidTxQuery = _plaidRepository.GetAll()
                                           .Where(p => p.Id == query.PlaidId!.Value &&
                                                       p.OwnerBankAccount.OwnerId == query.OwnerId!);

        PlaidTransaction? plaidTx = await _plaidRepository.FirstOrDefaultAsync(plaidTxQuery);
        if (plaidTx == null)
            return OperationResult<GetPlaidTransactionForUpdateQueryResponse>.ErrorResult(new ErrorDetails(404, "Not found"));

        if (plaidTx.Status == PlaidTransactionStatus.RelevantTransaction)
            return await GetByRelevantTransaction(plaidTx);

        PliadTransactionUpdate pliadTransactionUpdate = new(plaidTx);

        List<ListModel> statuses = EnumExtensions.ToListModel<PlaidTransactionStatus>();

        if (plaidTx.Status != PlaidTransactionStatus.Created)
        {
            statuses = [.. statuses.Where(s => s.Id != (int)PlaidTransactionStatus.Created)];
        }

        if (plaidTx.Status != PlaidTransactionStatus.NeedReview)
        {
            statuses = [.. statuses.Where(s => s.Id != (int)PlaidTransactionStatus.NeedReview)];
        }

        GetPlaidTransactionForUpdateQueryResponse response = new(pliadTransactionUpdate,
                                                                 statuses);

        return OperationResult<GetPlaidTransactionForUpdateQueryResponse>.SuccessResult(response);

    }

    public async Task<OperationResult<GetPlaidTransactionForUpdateQueryResponse>> GetByRelevantTransaction(PlaidTransaction plaidTx)
    {
        PliadTransactionUpdate pliadTransactionUpdate = new(plaidTx);

        var transactionApplicationQuery = _transactionApplicationRepository.GetAllFull()
                                                                           .Where(ta => ta.Payment.PlaidTransactionId == plaidTx.Id);

        var transactionApplication = await _transactionApplicationRepository.FirstOrDefaultAsync(transactionApplicationQuery);
        if (transactionApplication == null)
            return OperationResult<GetPlaidTransactionForUpdateQueryResponse>.ErrorResult(new ErrorDetails(404, $"Not found Transaction Application by PlaidTransactionId {plaidTx.Id}"));

        PliadTransactionCharge pliadTransactionCharge = new(transactionApplication);
        await SetChargeLease(pliadTransactionCharge);
        await SetChargeExpense(pliadTransactionCharge);
        await SetChargeMaintenance(pliadTransactionCharge);

        GetPlaidTransactionForUpdateQueryResponse response = new(pliadTransactionUpdate,
                                                                 [new() { Id = (int)plaidTx.Status, Text = EnumExtensions.GetEnumDescription(plaidTx.Status) }],
                                                                 pliadTransactionCharge);

        return OperationResult<GetPlaidTransactionForUpdateQueryResponse>.SuccessResult(response);
    }

    private async Task SetChargeLease(PliadTransactionCharge pliadTransactionCharge)
    {
        if (pliadTransactionCharge.TransactionType != TransactionType.Lease)
            return;


        var leaseChargeQuery = _leaseChargeRepository.GetAll().Where(lc => pliadTransactionCharge.TransactionId == lc.TransactionId);

        var leaseCharge = await _leaseChargeRepository.FirstOrDefaultAsync(leaseChargeQuery);
        if (leaseCharge == null)
            return;

        pliadTransactionCharge.StatusDescription = EnumExtensions.GetEnumDescription(leaseCharge.Status);
        pliadTransactionCharge.DueDate = leaseCharge.DueDate;
    }

    private async Task SetChargeExpense(PliadTransactionCharge pliadTransactionCharge)
    {
        if (pliadTransactionCharge.TransactionType != TransactionType.Expense)
            return;


        var expenseChargeQuery = _expenseChargeRepository.GetAll().Where(ec => pliadTransactionCharge.TransactionId == ec.TransactionId);

        var expenseCharge = await _expenseChargeRepository.FirstOrDefaultAsync(expenseChargeQuery);
        if (expenseCharge == null)
            return;

        pliadTransactionCharge.StatusDescription = EnumExtensions.GetEnumDescription(expenseCharge.Status);
        pliadTransactionCharge.DueDate = expenseCharge.DueDate;
    }

    private async Task SetChargeMaintenance(PliadTransactionCharge pliadTransactionCharge)
    {
        if (pliadTransactionCharge.TransactionType != TransactionType.Maintenance)
            return;


        var maintenanceChargeQuery = _maintenanceChargeRepository.GetAll().Where(mc => pliadTransactionCharge.TransactionId == mc.TransactionId);

        var maintenanceCharge = await _maintenanceChargeRepository.FirstOrDefaultAsync(maintenanceChargeQuery);
        if (maintenanceCharge == null)
            return;

        pliadTransactionCharge.StatusDescription = EnumExtensions.GetEnumDescription(maintenanceCharge.Status);
        pliadTransactionCharge.DueDate = maintenanceCharge.DueDate;
    }
}
