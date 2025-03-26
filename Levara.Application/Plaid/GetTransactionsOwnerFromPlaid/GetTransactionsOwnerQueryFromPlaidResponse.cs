namespace Levara.Application.Plaid.GetTransactionsOwnerFromPlaid;

public class GetTransactionsOwnerQueryFromPlaidResponse
{
    public GetTransactionsOwnerQueryFromPlaidResponse(int total_Transactions)
    {
        Total_Transactions = total_Transactions;

    }
    
    public int Total_Transactions { get; set; }
    public string Request_id { get; set; }
    
}
