

namespace Levara.Application.BankTransactions.SummaryByMonth;

public class GetBankTransSummaryByMonthQueryResponse
{
    public GetBankTransSummaryByMonthQueryResponse(IEnumerable<BankTransSummaryByMonth> bankTransSummaryByMonths)
    {
        BankTransSummaryByMonths = bankTransSummaryByMonths;
    }

    public IEnumerable<BankTransSummaryByMonth> BankTransSummaryByMonths { get; set; }
}

public class BankTransSummaryByMonth
{
    public string Month { get; set; }

    public double Income { get; set; }

    public double Expenses { get; set; }
}