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

        DateTime fromDate = new DateTime(query.Year!.Value, 1, 1, 0, 0, 0, DateTimeKind.Utc);
        DateTime toDate = new DateTime(query.Year!.Value, 12, 31, 23, 59, 59, DateTimeKind.Utc);

        var btQuery = _paymentRepository.GetAll()
                                        .Where(bt => bt.Property.OwnerId == query.OwnerId &&
                                                     bt.Date >= fromDate && bt.Date <= toDate);

        var payments = await _paymentRepository.ToListAsync(btQuery);

        var paymentsByMonth = payments.GroupBy(bt => bt.Date.Month)
                                              .ToDictionary(g => g.Key, g => new
                                              {
                                                  Income = g.Where(t => t.Type == TransactionType.Lease).Sum(t => t.Amount),
                                                  Expenses = g.Where(t => t.Type == TransactionType.Maintenance).Sum(t => t.Amount)
                                              });

        var btsSummaryByMonth = Enumerable.Range(1, 12)
                                          .Select(month => new PaymentsSummaryByMonth
                                          {
                                              Month = CultureInfo.InvariantCulture.DateTimeFormat.GetMonthName(month),
                                              Income = paymentsByMonth.ContainsKey(month) ? paymentsByMonth[month].Income : 0,
                                              Expenses = paymentsByMonth.ContainsKey(month) ? paymentsByMonth[month].Expenses : 0
                                          });

        GetPaymentsSummaryByMonthQueryResponse response = new(btsSummaryByMonth);

        return OperationResult<GetPaymentsSummaryByMonthQueryResponse>.SuccessResult(response);

    }
}


