using Levara.Domain.DAL.Repositories;
using Levara.Domain.Models;
using Levara.Shared.Domain.Bus.Queries;
using Levara.Shared.Results;

namespace Levara.Application.Transactions.GetByGrid;

public class GetTransactionsByGridQueryHandler : IQueryHandler<GetTransactionsByGridQuery, PagedList<GetTransactionsByGridQueryResponse>>
{
    private readonly ITransactionRepository _transactionRepository;
    private readonly IExpenseChargeRepository _expenseChargeRepository;
    private readonly ILeaseChargeRepository _leaseChargeRepository;
    private readonly IMaintenanceChargeRepository _maintenanceChargeRepository;
    public GetTransactionsByGridQueryHandler(ITransactionRepository transactionRepository,
        IExpenseChargeRepository expenseChargeRepository,
        ILeaseChargeRepository leaseChargeRepository,
        IMaintenanceChargeRepository maintenanceChargeRepository) 
    {
        _transactionRepository = transactionRepository;
        _expenseChargeRepository = expenseChargeRepository;
        _leaseChargeRepository = leaseChargeRepository;
        _maintenanceChargeRepository = maintenanceChargeRepository;
    }
    public async Task<OperationResult<PagedList<GetTransactionsByGridQueryResponse>>> Handle(GetTransactionsByGridQuery query)
    {
        //TODO: Recfactor this to use a single repository for all transactions and charges
        var transactionQuery = _transactionRepository.GetAllFull()
            .GroupJoin(_leaseChargeRepository.GetAll(),
                t => t.Id,
                lc => lc.TransactionId,
                (t, lc) => new { Transaction = t, LeaseCharges = lc })
            .SelectMany(x => x.LeaseCharges.DefaultIfEmpty(),
                (t, lc) => new { t.Transaction, LeaseCharge = lc })
            .GroupJoin(_expenseChargeRepository.GetAll(),
                x => x.Transaction.Id,
                ec => ec.TransactionId,
                (x, ec) => new { x.Transaction, x.LeaseCharge, ExpenseCharges = ec })
            .SelectMany(x => x.ExpenseCharges.DefaultIfEmpty(),
                (x, ec) => new { x.Transaction, x.LeaseCharge, ExpenseCharge = ec })
            .GroupJoin(_maintenanceChargeRepository.GetAll(),
                x => x.Transaction.Id,
                mc => mc.TransactionId,
                (x, mc) => new { x.Transaction, x.LeaseCharge, x.ExpenseCharge, MaintenanceCharges = mc })
            .SelectMany(x => x.MaintenanceCharges.DefaultIfEmpty(),
                (x, mc) => new { x.Transaction, x.LeaseCharge, x.ExpenseCharge, MaintenanceCharge = mc });

        if (query.OwnerId.HasValue)
            transactionQuery = transactionQuery.Where(t => t.Transaction.Property.OwnerId == query.OwnerId!.Value);

        if (query.PropertyId.HasValue)
            transactionQuery = transactionQuery.Where(t => t.Transaction.PropertyId == query.PropertyId!.Value);

        if (query.DateFrom.HasValue)
            transactionQuery = transactionQuery.Where(t => t.Transaction.Date >= query.DateFrom!.Value);

        if (query.DateTo.HasValue)
            transactionQuery = transactionQuery.Where(t => t.Transaction.Date <= query.DateTo!.Value);

        if (query.Types != null && query.Types.Any())
            transactionQuery = transactionQuery.Where(t => query.Types.Contains(t.Transaction.Type));

        if (query.SubTypes != null && query.SubTypes.Any())
            transactionQuery = transactionQuery.Where(t => query.SubTypes.Contains(t.Transaction.SubType));

        if (query.ChargeStatuses != null && query.ChargeStatuses.Any())
        {
            transactionQuery = transactionQuery.Where(t =>
                (t.LeaseCharge != null && query.ChargeStatuses.Contains((int)t.LeaseCharge.Status)) ||
                (t.ExpenseCharge != null && query.ChargeStatuses.Contains((int)t.ExpenseCharge.Status)) ||
                (t.MaintenanceCharge != null && query.ChargeStatuses.Contains((int)t.MaintenanceCharge.Status)));
        }


        var transactionQueryResponse = transactionQuery.OrderByDescending(t => t.Transaction.Date)
            .Select(t => new GetTransactionsByGridQueryResponse(t.Transaction, t.ExpenseCharge, t.LeaseCharge, t.MaintenanceCharge));

        var response = await _transactionRepository.ToListPagedAsync(transactionQueryResponse, query.PageNumber!.Value, query.PageSize!.Value);

        return OperationResult<PagedList<GetTransactionsByGridQueryResponse>>.SuccessResult(response);

    }
}


