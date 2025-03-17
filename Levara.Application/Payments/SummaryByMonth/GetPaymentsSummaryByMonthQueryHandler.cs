using Levara.Domain.DAL.Repositories;
using Levara.Domain.Enum;
using Levara.Shared.Domain.Bus.Queries;
using Levara.Shared.Results;
using System.Globalization;

namespace Levara.Application.Payments.SummaryByMonth;

public class GetPaymentsSummaryByMonthQueryHandler : IQueryHandler<GetPaymentsSummaryByMonthQuery, GetPaymentsSummaryByMonthQueryResponse>
{
    private readonly IPaymentRepository _paymentRepository;

    public GetPaymentsSummaryByMonthQueryHandler(IPaymentRepository paymentRepository)
    {
        _paymentRepository = paymentRepository;
    }

    public async Task<OperationResult<GetPaymentsSummaryByMonthQueryResponse>> Handle(GetPaymentsSummaryByMonthQuery query)
    {
        var fromDate = new DateTime(query.Years.Min(), 1, 1, 0, 0, 0, DateTimeKind.Utc);
        var toDate = new DateTime(query.Years.Max(), 12, 31, 23, 59, 59, DateTimeKind.Utc);

        var btQuery = _paymentRepository.GetAll()
            .Where(bt => bt.Property.OwnerId == query.OwnerId &&
                         query.Years.Contains(bt.Date.Year) &&
                         bt.Date >= fromDate && bt.Date <= toDate);

        if (query.PropertyId.HasValue)
        {
            btQuery = btQuery.Where(bt => bt.PropertyId == query.PropertyId.Value);
        }

        if (query.TransactionTypes.Any())
        {
            btQuery = btQuery.Where(bt => query.TransactionTypes.Contains(bt.Type));
        }

        var payments = await _paymentRepository.ToListAsync(btQuery);

        var paymentsByYearMonth = payments.GroupBy(bt => new { bt.Date.Year, bt.Date.Month })
            .ToDictionary(g => g.Key, g => new
            {
                Income = g.Where(t => t.Type == TransactionType.Lease).Sum(t => t.Amount),
                Expenses = g.Where(t => t.Type == TransactionType.Expense).Sum(t => t.Amount),
                Maintenances = g.Where(t => t.Type == TransactionType.Maintenance).Sum(t => t.Amount)
            });

        var btsSummaryByMonth = query.Years.SelectMany(year => Enumerable.Range(1, 12)
            .Select(month => new PaymentsSummaryByMonth
            {
                Year = year,
                Month = CultureInfo.InvariantCulture.DateTimeFormat.GetMonthName(month),
                Income = paymentsByYearMonth.ContainsKey(new { Year = year, Month = month }) ? paymentsByYearMonth[new { Year = year, Month = month }].Income : 0,
                Expenses = paymentsByYearMonth.ContainsKey(new { Year = year, Month = month }) ? paymentsByYearMonth[new { Year = year, Month = month }].Expenses : 0,
                Maintenances = paymentsByYearMonth.ContainsKey(new { Year = year, Month = month }) ? paymentsByYearMonth[new { Year = year, Month = month }].Maintenances : 0
            }));

        var response = new GetPaymentsSummaryByMonthQueryResponse(btsSummaryByMonth);

        return OperationResult<GetPaymentsSummaryByMonthQueryResponse>.SuccessResult(response);
    }
}


