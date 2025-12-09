

namespace Levara.Application.Payments.SummaryByMonth;

public class GetPaymentsSummaryByMonthQueryResponse
{
    public GetPaymentsSummaryByMonthQueryResponse(IEnumerable<PaymentsSummaryByMonth> paymentsSummaryByMonths)
    {
        PaymentsSummaryByMonths = paymentsSummaryByMonths;
    }

    public IEnumerable<PaymentsSummaryByMonth> PaymentsSummaryByMonths { get; set; }
}

public class PaymentsSummaryByMonth
{
    public int Year { get; set; }
    public string Month { get; set; }
    public decimal Income { get; set; }
    public decimal Expenses { get; set; }
    public decimal Maintenances { get; set; }
}