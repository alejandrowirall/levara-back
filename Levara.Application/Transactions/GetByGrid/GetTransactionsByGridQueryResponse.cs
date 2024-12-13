
using Levara.Domain.Models;

namespace Levara.Application.Transactions.GetByGrid;

public class GetTransactionsByGridQueryResponse
{
    public GetTransactionsByGridQueryResponse(Transaction transaction)
    {
        //Id = property.Id;
        //Number = property.Number;
        //Address = $"{property.Address.Street} {property.Address.Number}, {property.Address.City}, {property.Address.State}";
        //Price = property.Price;
    }
    public int Id { get; }

    public int Number { get; set; }

    public string Address { get; set; }

    public decimal? Price { get; set; }
}