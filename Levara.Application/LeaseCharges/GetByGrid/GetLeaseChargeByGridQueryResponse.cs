
using Levara.Domain.Enum;
using Levara.Domain.Models;
using Levara.Shared.Extensions;

namespace Levara.Application.LeaseCharges.GetByGrid;

public class GetLeaseChargeByGridQueryResponse
{
    public GetLeaseChargeByGridQueryResponse(LeaseCharge leaseCharge)
    {
        Id = leaseCharge.Id;
        TransactionId = leaseCharge.TransactionId;
        Transaction = leaseCharge.Transaction;
        DueDate = leaseCharge.Transaction.DueDate ?? DateTime.MinValue;
        LeaseId = leaseCharge.LeaseId;
        Lease = leaseCharge.Lease;
        Status = leaseCharge.Transaction.Status;
        StatusDescription = EnumExtensions.GetEnumDescription(leaseCharge.Transaction.Status);
    }

    public int Id { get; set; }
    public int TransactionId { get; set; }
    public Transaction Transaction { get; set; }

    public DateTime DueDate { get; set; }

    public int LeaseId { get; set; }

    public Lease Lease { get; set; }

    public TransactionStatus Status { get; set; }
    public string StatusDescription { get; set; }
}