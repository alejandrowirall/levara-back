
using Levara.Domain.Enum;
using Levara.Domain.Models;

namespace Levara.Application.LeasesPayment.GetByGrid;

public class GetLeasePaymentByGridQueryResponse
{
    public GetLeasePaymentByGridQueryResponse(LeasePayment leaseCharge)
    {
        TransactionId = leaseCharge.TransactionId;
        Transaction = leaseCharge.Transaction;
        LeaseId = leaseCharge.LeaseId;
        Lease = leaseCharge.Lease;
        
    }

    public int TransactionId { get; set; }
    public Transaction Transaction { get; set; }

    public int LeaseId { get; set; }

    public Lease Lease { get; set; }

}