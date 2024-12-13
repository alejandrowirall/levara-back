
using Levara.Domain.Models;
using Levara.Shared.Domain.Bus.Commands;
using System.ComponentModel.DataAnnotations;

namespace Levara.Application.Transactions.GetForUpdate;

public class GetTransactionForUpdateQueryResponse
{
    public GetTransactionForUpdateQueryResponse(TransactionUpdateQueryResponse transaction)
    {
        Transaction = transaction;
    }

    public TransactionUpdateQueryResponse Transaction { get; }
}

public class TransactionUpdateQueryResponse
{
    public TransactionUpdateQueryResponse(Transaction transaction)
    {
        //Id = property.Id;
        //OwnerId = property.OwnerId;
        //Number = property.Number;
        //Street = property.Address.Street;
        //City = property.Address.City;
        //State = property.Address.State;
        //PostalCode = property.Address.PostalCode;
        //Price=property.Price;
        //RoomsQuantity = property.RoomsQuantity;
        //BathroomQuantity = property.BathroomQuantity;
        //AreaQuantity = property.AreaQuantity;
        //HasPool = property.HasPool;
        //HasBalcony = property.HasBalcony;
        //HasGarage = property.HasGarage;
        //DetailDepositAndAdittionalInfo = property.DetailDepositAndAdittionalInfo;
        //PetsPoliticAndRate = property.PetsPoliticAndRate;
        //TenantRequirements = property.TenantRequirements;
        //AvaliableFrom = property.AvaliableFrom;
    }
    public int Id { get; }

    public int OwnerId { get; }

    public int Number { get; }

    public string Street { get; }

    public string? AdditionalLine { get; }

    public string City { get; }

    public string State { get; }

    public string PostalCode { get; }

    public decimal? Price { get; set; }

    public int? RoomsQuantity { get; set; }
    public int? BathroomQuantity { get; set; }

    public decimal? AreaQuantity { get; set; }

    public bool? HasPool { get; set; }

    public bool? HasBalcony { get; set; }
    public bool? HasGarage { get; set; }
    
    public string? DetailDepositAndAdittionalInfo { get; set; }
   
    public string? PetsPoliticAndRate { get; set; }
    
    public string? TenantRequirements { get; set; }

    public DateTime? AvaliableFrom { get; set; }

}
