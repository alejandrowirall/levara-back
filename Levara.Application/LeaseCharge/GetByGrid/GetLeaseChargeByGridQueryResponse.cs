
using Levara.Domain.Enum;
using Levara.Domain.Models;

namespace Levara.Application.LeasesCharges.GetByGrid;

public class GetLeaseChargeByGridQueryResponse
{
    public GetLeaseChargeByGridQueryResponse(LeaseCharge leaseCharge)
    {
        Id = leaseCharge.Id;
        TransactionId = leaseCharge.TransactionId;
        Transaction = leaseCharge.Transaction;
        DueDate = leaseCharge.DueDate;
        LeaseId = leaseCharge.LeaseId;
        Lease = leaseCharge.Lease;
        Status = leaseCharge.Status;
    }

    public int Id { get; set; }
    public int TransactionId { get; set; }
    public Transaction Transaction { get; set; }

    public DateTime DueDate { get; set; }

    public int LeaseId { get; set; }

    public Lease Lease { get; set; }

    public LeaseChargeStatus Status { get; set; }
}