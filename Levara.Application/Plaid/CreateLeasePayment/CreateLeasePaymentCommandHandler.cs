using Levara.Domain.DAL;
using Levara.Domain.DAL.Repositories;
using Levara.Domain.Enum;
using Levara.Domain.Models;
using Levara.Shared.Domain.Bus.Commands;
using Levara.Shared.Results;
using Levara.Shared.Extensions;
using Microsoft.EntityFrameworkCore;

namespace Levara.Application.Plaid.CreateLeasePayment;

public class CreateLeasePaymentCommandHandler : ICommandHandler<CreateLeasePaymentCommand, CreateLeasePaymentCommandResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IPlaidRepository _plaidRepository;
    private readonly IBankTransactionRepository _bankTransactionRepository;
    private readonly ILeaseChargeRepository _leaseChargeRepository;
    private readonly ILeasePaymentRepository _leasePaymentRepository;
    private readonly ITransactionRepository _transactionRepository;
    private readonly ITransactionApplicationRepository _transactionApplicationRepository;
    public CreateLeasePaymentCommandHandler(IUnitOfWork unitOfWork,
        IPlaidRepository plaidRepository, 
        IBankTransactionRepository bankTransactionRepository,
        ILeaseChargeRepository leaseChargeRepository,
        ILeasePaymentRepository leasePaymentRepository,
        ITransactionRepository transactionRepository,
        ITransactionApplicationRepository transactionApplicationrepository)
    {
        _unitOfWork = unitOfWork;
        _plaidRepository = plaidRepository;
        _bankTransactionRepository = bankTransactionRepository;
        _leaseChargeRepository = leaseChargeRepository;
        _leasePaymentRepository = leasePaymentRepository;
        _transactionRepository = transactionRepository;
        _transactionApplicationRepository = transactionApplicationrepository;
    }
    public async Task<OperationResult<CreateLeasePaymentCommandResponse>> Handle(CreateLeasePaymentCommand command)
    {

        var plaidTxQuery = _plaidRepository.GetAllWithOwnerBankAccount()
                                           .Where(o => o.Id == command.PlaidId!);

        PlaidTransaction? plaidtx = await _plaidRepository.FirstOrDefaultAsync(plaidTxQuery);
        if (plaidtx == null)
            return OperationResult<CreateLeasePaymentCommandResponse>.ErrorResult(new ErrorDetails(404, "Not found"));

        if (plaidtx.Status != PlaidTransactionStatus.Created && plaidtx.Status != PlaidTransactionStatus.NeedReview)
            return OperationResult<CreateLeasePaymentCommandResponse>.ErrorResult(new ErrorDetails(400, $"Plaid transaction must be in state {EnumExtensions.GetEnumDescription(PlaidTransactionStatus.Created)} or {EnumExtensions.GetEnumDescription(PlaidTransactionStatus.NeedReview)}"));

        if (plaidtx.Amount <= 0)
            return OperationResult<CreateLeasePaymentCommandResponse>.ErrorResult(new ErrorDetails(400, $"Plaid transaction must be greater than zero"));

        if (plaidtx.OwnerBankAccount.OwnerId != command.OwnerId)
            return OperationResult<CreateLeasePaymentCommandResponse>.ErrorResult(new ErrorDetails(400, $"Plaid transaction is not owned by the owner"));

        plaidtx.Status = PlaidTransactionStatus.RelevantTransaction;

        var leaseChargeQuery = _leaseChargeRepository.GetAllFull()
                                                     .Where(b => b.Id == command.LeaseChargeId);

        LeaseCharge? leaseCharge = await _leaseChargeRepository.FirstOrDefaultAsync(leaseChargeQuery);
        if (leaseCharge == null)
            return OperationResult<CreateLeasePaymentCommandResponse>.ErrorResult(new ErrorDetails(404, "Not found"));

        if (leaseCharge.Lease.OwnerId != command.OwnerId)
            return OperationResult<CreateLeasePaymentCommandResponse>.ErrorResult(new ErrorDetails(400, "The charge does not belong to a property of the owner"));

        if (leaseCharge.Status == LeaseChargeStatus.Paid)
            return OperationResult<CreateLeasePaymentCommandResponse>.ErrorResult(new ErrorDetails(400, "The charge must not be in paid status"));

        if (leaseCharge.Status == LeaseChargeStatus.Unpaid)
            return await GenerateLeasePaymentFromUnpaid(plaidtx, leaseCharge, command);

        return await GenerateLeasePaymentFromPartpaid(plaidtx, leaseCharge, command);
    }

    private async Task<OperationResult<CreateLeasePaymentCommandResponse>> GenerateLeasePaymentFromUnpaid(PlaidTransaction plaidtx,
        LeaseCharge leaseCharge,
        CreateLeasePaymentCommand command)
    {


        var bnkTxQuery = _bankTransactionRepository.GetAll()
           .Where(b => b.OwnerBankAccountId == plaidtx.OwnerBankAccountId)
           .OrderByDescending(o => o.Id);

        double runningBalance = 0;
        BankTransaction? lastBanktx = await _bankTransactionRepository.FirstOrDefaultAsync(bnkTxQuery);
        if (lastBanktx != null)
            runningBalance = lastBanktx.RunningBalance!.Value;

        BankTransaction newBankTx = new()
        {
            TransactionId = plaidtx.TransactionId,
            Amount = plaidtx.Amount,
            Description = plaidtx.Description,
            Date = plaidtx.Date,
            LeaseId = leaseCharge.LeaseId,
            OwnerBankAccountId = plaidtx.OwnerBankAccountId,
            PropertyId = leaseCharge.Lease.PropertyId,
            RunningBalance = runningBalance + plaidtx.Amount,
            PlaidIdTransaction = plaidtx.Id,
            Type = TransactionType.Lease,
        };

        var txQuery = _transactionRepository.GetAll()
           .Where(b => b.PropertyId == leaseCharge.Lease.PropertyId)
           .OrderByDescending(o => o.Id);

        Transaction? lastTx = await _bankTransactionRepository.FirstOrDefaultAsync(txQuery);
        if (lastTx == null)
            return OperationResult<CreateLeasePaymentCommandResponse>.ErrorResult(new ErrorDetails(404, "Not found"));


        Transaction tx = new()
        {
            Amount = command.Amount!.Value,
            Date = plaidtx.Date,
            Description = "PAGO DE Lease " + command.LeaseChargeId.ToString(),
            RunningBalance = lastTx.RunningBalance + command.Amount!.Value,
            EntityRunningBalance = lastTx.EntityRunningBalance + command.Amount!.Value,
            SubType = TransactionSubType.Payment,
            Type = TransactionType.Lease,
            PropertyId = leaseCharge.Lease.PropertyId,
            EntityId = leaseCharge.LeaseId

        };

        TransactionApplication txAppl = new()
        {
            AppliedAmount = (decimal)command.Amount!,
            BankTransaction = newBankTx,
            ChargeTransactionId = leaseCharge.TransactionId,
            PaymentTransaction = tx
        };

        LeasePayment leasePayment = new()
        {
            LeaseId = leaseCharge.LeaseId,
            Transaction = tx,
        };

        leaseCharge.Status = leaseCharge.Transaction.Amount == txAppl.AppliedAmount ? LeaseChargeStatus.Paid : LeaseChargeStatus.Partpaid;

        await _unitOfWork.ExecuteAsTransactionAsync(async () =>
        {
            await _bankTransactionRepository.AddAsync(newBankTx);
            await _transactionRepository.AddAsync(tx);
            await _transactionApplicationRepository.AddAsync(txAppl);
            _leaseChargeRepository.Update(leaseCharge);
            await _leasePaymentRepository.AddAsync(leasePayment);
            _plaidRepository.Update(plaidtx);
        });


        CreateLeasePaymentCommandResponse response = new()
        {
            Id = plaidtx.Id
        };

        return OperationResult<CreateLeasePaymentCommandResponse>.SuccessResult(response);

    }

    private async Task<OperationResult<CreateLeasePaymentCommandResponse>> GenerateLeasePaymentFromPartpaid(PlaidTransaction plaidtx,
        LeaseCharge leaseCharge,
        CreateLeasePaymentCommand command)
    {


        var bnkTxQuery = _bankTransactionRepository.GetAll()
           .Where(b => b.OwnerBankAccountId == plaidtx.OwnerBankAccountId)
           .OrderByDescending(o => o.Id);

        double runningBalance = 0;
        BankTransaction? lastBanktx = await _bankTransactionRepository.FirstOrDefaultAsync(bnkTxQuery);
        if (lastBanktx != null)
            runningBalance = lastBanktx.RunningBalance!.Value;

        BankTransaction newBankTx = new()
        {
            TransactionId = plaidtx.TransactionId,
            Amount = plaidtx.Amount,
            Description = plaidtx.Description,
            Date = plaidtx.Date,
            LeaseId = leaseCharge.LeaseId,
            OwnerBankAccountId = plaidtx.OwnerBankAccountId,
            PropertyId = leaseCharge.Lease.PropertyId,
            RunningBalance = runningBalance + plaidtx.Amount,
            PlaidIdTransaction = plaidtx.Id,
            Type = TransactionType.Lease,
        };

        var txQuery = _transactionRepository.GetAll()
           .Where(b => b.PropertyId == leaseCharge.Lease.PropertyId)
           .OrderByDescending(o => o.Id);

        Transaction? lastTx = await _bankTransactionRepository.FirstOrDefaultAsync(txQuery);
        if (lastTx == null)
            return OperationResult<CreateLeasePaymentCommandResponse>.ErrorResult(new ErrorDetails(404, "Not found"));


        Transaction tx = new()
        {
            Amount = command.Amount!.Value,
            Date = plaidtx.Date,
            Description = "PAGO DE Lease " + command.LeaseChargeId.ToString(),
            RunningBalance = lastTx.RunningBalance + command.Amount!.Value,
            EntityRunningBalance = lastTx.EntityRunningBalance + command.Amount!.Value,
            SubType = TransactionSubType.Payment,
            Type = TransactionType.Lease,
            PropertyId = leaseCharge.Lease.PropertyId,
            EntityId = leaseCharge.LeaseId

        };

        var currentTotalAmountTxAp = await _transactionApplicationRepository.GetAll()
                                                                            .Where(ta => ta.ChargeTransactionId == leaseCharge.TransactionId)
                                                                            .Select(ta => ta.AppliedAmount)
                                                                            .SumAsync();

        decimal newTotalAmountTxAp = currentTotalAmountTxAp + command.Amount!.Value;

        if (newTotalAmountTxAp > leaseCharge.Transaction.Amount)
            return OperationResult<CreateLeasePaymentCommandResponse>.ErrorResult(new ErrorDetails(400, "Invalid amount"));

        TransactionApplication txAppl = new()
        {
            AppliedAmount = command.Amount!.Value,
            BankTransaction = newBankTx,
            ChargeTransactionId = leaseCharge.TransactionId,
            PaymentTransaction = tx
        };

        LeasePayment leasePayment = new()
        {
            LeaseId = leaseCharge.LeaseId,
            Transaction = tx,
        };

        
        leaseCharge.Status = leaseCharge.Transaction.Amount == newTotalAmountTxAp ? LeaseChargeStatus.Paid : LeaseChargeStatus.Partpaid;

        await _unitOfWork.ExecuteAsTransactionAsync(async () =>
        {
            await _bankTransactionRepository.AddAsync(newBankTx);
            await _transactionRepository.AddAsync(tx);
            await _transactionApplicationRepository.AddAsync(txAppl);
            _leaseChargeRepository.Update(leaseCharge);
            await _leasePaymentRepository.AddAsync(leasePayment);
            _plaidRepository.Update(plaidtx);

        });


        CreateLeasePaymentCommandResponse response = new()
        {
            Id = plaidtx.Id
        };

        return OperationResult<CreateLeasePaymentCommandResponse>.SuccessResult(response);

    }
}
