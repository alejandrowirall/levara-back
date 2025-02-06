using Levara.Domain.DAL.Repositories;
using Levara.Domain.Enum;
using Levara.Shared.Domain.Bus.Queries;
using Levara.Shared.Results;
using System.Globalization;

namespace Levara.Application.BankTransactions.SummaryByMonth;

public class GetBankTransSummaryByMonthQueryHandler : IQueryHandler<GetBankTransSummaryByMonthQuery, GetBankTransSummaryByMonthQueryResponse>
{
    private readonly IBankTransactionRepository _bankTransactionRepository;
    private readonly IOwnerBankAccountRepository _ownerBankAccountRepository;
    public GetBankTransSummaryByMonthQueryHandler(IBankTransactionRepository bankTransactionRepository,
        IOwnerBankAccountRepository ownerBankAccountRepository) 
    {
        _bankTransactionRepository = bankTransactionRepository;
        _ownerBankAccountRepository = ownerBankAccountRepository;
    }
    public async Task<OperationResult<GetBankTransSummaryByMonthQueryResponse>> Handle(GetBankTransSummaryByMonthQuery query)
    {

        var ownerBankAccountQuery = _ownerBankAccountRepository.GetAll()
                                                               .Where(oba => oba.OwnerId == query.OwnerId!.Value)
                                                               .OrderByDescending(oba => oba.Id);

        var ownerBankAccount = await _ownerBankAccountRepository.FirstOrDefaultAsync(ownerBankAccountQuery);

        DateTime fromDate = new DateTime(query.Year!.Value, 1, 1, 0, 0, 0, DateTimeKind.Utc);
        DateTime toDate = new DateTime(query.Year!.Value, 12, 31, 23, 59, 59, DateTimeKind.Utc);

        var btQuery = _bankTransactionRepository.GetAll()
                                                .Where(bt => bt.OwnerBankAccountId == ownerBankAccount.Id &&
                                                             bt.Date >= fromDate && bt.Date <= toDate);

        var bankTransactions = await _bankTransactionRepository.ToListAsync(btQuery);

        var btsSummaryByMonth = bankTransactions.GroupBy(bt => bt.Date.ToString("MMMM", CultureInfo.InvariantCulture))
                                                .Select(g => new BankTransSummaryByMonth()
                                                {
                                                    Month = g.Key,
                                                    Income = g.Where(t => t.Type == TransactionType.Lease).Sum(t => t.Amount) ?? 0,
                                                    Expenses = g.Where(t => t.Type == TransactionType.Maintenance).Sum(t => (-1) * t.Amount) ?? 0
                                                });

        GetBankTransSummaryByMonthQueryResponse response = new(btsSummaryByMonth);

        return OperationResult<GetBankTransSummaryByMonthQueryResponse>.SuccessResult(response);

    }
}


