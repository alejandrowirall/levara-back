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
    private readonly IPaymentRepository _paymentRepository;
    private readonly ILeaseRepository _leaseRepository;
    private readonly ILeaseChargeRepository _leaseChargeRepository;
    private readonly ILeasePaymentRepository _leasePaymentRepository;
    private readonly ITransactionRepository _transactionRepository;
    private readonly ITransactionApplicationRepository _transactionApplicationRepository;
    public CreateLeasePaymentCommandHandler(IUnitOfWork unitOfWork,
        IPlaidRepository plaidRepository,
        IPaymentRepository paymentRepository,
        ILeaseRepository leaseRepository,
        ILeaseChargeRepository leaseChargeRepository,
        ILeasePaymentRepository leasePaymentRepository,
        ITransactionRepository transactionRepository,
        ITransactionApplicationRepository transactionApplicationrepository)
    {
        _unitOfWork = unitOfWork;
        _plaidRepository = plaidRepository;
        _paymentRepository = paymentRepository;
        _leaseRepository = leaseRepository;
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

        if (plaidtx.Amount < 0)
            return OperationResult<CreateLeasePaymentCommandResponse>.ErrorResult(new ErrorDetails(400, $"Plaid transaction must be greater than zero"));

        if (plaidtx.Amount < command.Amount!.Value)
            return OperationResult<CreateLeasePaymentCommandResponse>.ErrorResult(new ErrorDetails(400, $"The amount must be less than or equal to the Plaid transaction amount"));

        if (plaidtx.OwnerBankAccount.OwnerId != command.OwnerId)
            return OperationResult<CreateLeasePaymentCommandResponse>.ErrorResult(new ErrorDetails(400, $"Plaid transaction is not owned by the owner"));

        plaidtx.Status = PlaidTransactionStatus.RelevantTransaction;

        if (command.LeaseChargeId.HasValue)
            return await GenerateLeasePaymentWithCharge(plaidtx, command);


        return await GenerateLeasePaymentWithoutCharge(plaidtx, command);
    }

    private async Task<OperationResult<CreateLeasePaymentCommandResponse>> GenerateLeasePaymentWithoutCharge(PlaidTransaction plaidtx,
        CreateLeasePaymentCommand command)
    {

        var leaseQuery = _leaseRepository.GetAll()
                                            .Where(e => e.Id == command.CreateLeaseCharge!.LeaseId!.Value);

        var lease = await _leaseRepository.FirstOrDefaultAsync(leaseQuery);
        if (lease == null)
            return OperationResult<CreateLeasePaymentCommandResponse>.ErrorResult(new ErrorDetails(404, $"Not found Lease with id: {command.CreateLeaseCharge!.LeaseId!.Value}"));

        var lastPropertyPaymentQuery = _paymentRepository.GetAll()
                                                         .Where(b => b.PropertyId == lease.PropertyId)
                                                         .OrderByDescending(o => o.CreatedDate);

        decimal runningBalance = 0;
        Payment? lastPropertyPayment = await _paymentRepository.FirstOrDefaultAsync(lastPropertyPaymentQuery);
        if (lastPropertyPayment != null)
            runningBalance = lastPropertyPayment.RunningBalance;

        var lastBankAccPaymentQuery = _paymentRepository.GetAll()
                                                        .Where(b => b.OwnerBankAccountId == plaidtx.OwnerBankAccountId)
                                                        .OrderByDescending(o => o.CreatedDate);

        decimal bankAccountBalance = 0;
        Payment? lastBankAccPayment = await _paymentRepository.FirstOrDefaultAsync(lastBankAccPaymentQuery);
        if (lastBankAccPayment != null)
            bankAccountBalance = lastBankAccPayment.BankAccountBalance!.Value;

        Payment newPayment = new()
        {
            Amount = command.Amount!.Value,
            Description = $"Payment of {command.CreateLeaseCharge!.Description}",
            Date = plaidtx.Date,
            OwnerBankAccountId = plaidtx.OwnerBankAccountId,
            PropertyId = lease.PropertyId,
            RunningBalance = runningBalance + command.Amount!.Value,
            BankAccountBalance = bankAccountBalance + command.Amount!.Value,
            PlaidTransactionId = plaidtx.Id,
            Type = TransactionType.Lease,
            PaymentMethod = PaymentMethod.BankTransfer,
        };

        var txQuery = _transactionRepository.GetAll()
           .Where(b => b.PropertyId == lease.PropertyId)
           .OrderByDescending(o => o.Id);

        Transaction? lastTx = await _transactionRepository.FirstOrDefaultAsync(txQuery);

        decimal currentRunningBalance = 0;
        decimal currentEntityRunningBalance = 0;

        if (lastTx != null)
        {
            currentRunningBalance = lastTx.RunningBalance;
            currentEntityRunningBalance = lastTx.EntityRunningBalance;
            
        }

        Transaction newLeaseChargeTx =
            Transaction.CreateLeaseCharge(lease.PropertyId,
                                          command.Amount!.Value,
                                          command.CreateLeaseCharge!.LeaseId!.Value,
                                          command.CreateLeaseCharge!.Description,
                                          currentRunningBalance,
                                          currentEntityRunningBalance,
                                          plaidtx.Date);

        LeaseCharge newLeaseCharge = new()
        {
            Transaction = newLeaseChargeTx,
            Description = command.CreateLeaseCharge!.Description,
            LeaseId = lease.Id,
            DueDate = DateTime.UtcNow,
            Status = LeaseChargeStatus.Paid,
        };

        Transaction newLeasePaymentTx =
            Transaction.CreateLeasePayment(lease.PropertyId,
                                           command.Amount!.Value,
                                           command.CreateLeaseCharge!.LeaseId!.Value,
                                           command.CreateLeaseCharge!.Description,
                                           newLeaseChargeTx.RunningBalance,
                                           newLeaseChargeTx.EntityRunningBalance,
                                           plaidtx.Date);

        TransactionApplication txAppl = new()
        {
            AppliedAmount = (decimal)command.Amount!,
            Payment = newPayment,
            ChargeTransaction = newLeaseChargeTx,
            PaymentTransaction = newLeasePaymentTx
        };

        LeasePayment newLeasePayment = new()
        {
            LeaseId = lease.Id,
            Transaction = newLeasePaymentTx,
        };

        await _unitOfWork.ExecuteAsTransactionAsync(async () =>
        {
            await _paymentRepository.AddAsync(newPayment);

            await _transactionRepository.AddAsync(newLeaseChargeTx);

            await _transactionRepository.AddAsync(newLeasePaymentTx);

            await _transactionApplicationRepository.AddAsync(txAppl);

            await _leaseChargeRepository.AddAsync(newLeaseCharge);
            await _leasePaymentRepository.AddAsync(newLeasePayment);
            _plaidRepository.Update(plaidtx);
        });


        CreateLeasePaymentCommandResponse response = new()
        {
            Id = plaidtx.Id
        };

        return OperationResult<CreateLeasePaymentCommandResponse>.SuccessResult(response);
    }

    private async Task<OperationResult<CreateLeasePaymentCommandResponse>> GenerateLeasePaymentWithCharge(PlaidTransaction plaidtx,
        CreateLeasePaymentCommand command)
    {
        var leaseChargeQuery = _leaseChargeRepository.GetAllFull()
                                                       .Where(b => b.Id == command.LeaseChargeId);

        LeaseCharge? leaseCharge = await _leaseChargeRepository.FirstOrDefaultAsync(leaseChargeQuery);
        if (leaseCharge == null)
            return OperationResult<CreateLeasePaymentCommandResponse>.ErrorResult(new ErrorDetails(404, $"Not found lease charge with id: {command.LeaseChargeId}"));

        if (leaseCharge.Lease.OwnerId != command.OwnerId)
            return OperationResult<CreateLeasePaymentCommandResponse>.ErrorResult(new ErrorDetails(400, "The charge does not belong to a lease of the owner"));

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

        var lastPropertyPaymentQuery = _paymentRepository.GetAll()
                                                         .Where(b => b.PropertyId == leaseCharge.Transaction.PropertyId)
                                                         .OrderByDescending(o => o.CreatedDate);

        decimal runningBalance = 0;
        Payment? lastPropertyPayment = await _paymentRepository.FirstOrDefaultAsync(lastPropertyPaymentQuery);
        if (lastPropertyPayment != null)
            runningBalance = lastPropertyPayment.RunningBalance;

        var lastBankAccPaymentQuery = _paymentRepository.GetAll()
                                                        .Where(b => b.OwnerBankAccountId == plaidtx.OwnerBankAccountId)
                                                        .OrderByDescending(o => o.CreatedDate);

        decimal bankAccountBalance = 0;
        Payment? lastBankAccPayment = await _paymentRepository.FirstOrDefaultAsync(lastBankAccPaymentQuery);
        if (lastBankAccPayment != null)
            bankAccountBalance = lastBankAccPayment.BankAccountBalance!.Value;

        Payment newPayment = new()
        {
            Amount = command.Amount!.Value,
            Description = $"Payment of {leaseCharge.Description}",
            Date = plaidtx.Date,
            OwnerBankAccountId = plaidtx.OwnerBankAccountId,
            PropertyId = leaseCharge.Transaction.PropertyId,
            RunningBalance = runningBalance + command.Amount!.Value,
            BankAccountBalance = bankAccountBalance + command.Amount!.Value,
            PlaidTransactionId = plaidtx.Id,
            Type = TransactionType.Lease,
            PaymentMethod = PaymentMethod.BankTransfer,
        };

        var txQuery = _transactionRepository.GetAll()
           .Where(b => b.PropertyId == leaseCharge.Transaction.PropertyId)
           .OrderByDescending(o => o.CreatedDate);

        Transaction? lastTx = await _transactionRepository.FirstOrDefaultAsync(txQuery);
        if (lastTx == null)
            return OperationResult<CreateLeasePaymentCommandResponse>.ErrorResult(new ErrorDetails(404, "Not found"));

        Transaction tx = Transaction.CreateLeasePayment(leaseCharge.Transaction.PropertyId,
                                                        command.Amount!.Value,
                                                        leaseCharge.LeaseId,
                                                        leaseCharge.Description,
                                                        lastTx.RunningBalance,
                                                        lastTx.EntityRunningBalance,
                                                        plaidtx.Date);

        TransactionApplication txAppl = new()
        {
            AppliedAmount = (decimal)command.Amount!,
            Payment = newPayment,
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
            await _paymentRepository.AddAsync(newPayment);
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


        var lastPropertyPaymentQuery = _paymentRepository.GetAll()
                                                         .Where(b => b.PropertyId == leaseCharge.Transaction.PropertyId)
                                                         .OrderByDescending(o => o.CreatedDate);

        decimal runningBalance = 0;
        Payment? lastPropertyPayment = await _paymentRepository.FirstOrDefaultAsync(lastPropertyPaymentQuery);
        if (lastPropertyPayment != null)
            runningBalance = lastPropertyPayment.RunningBalance;

        var lastBankAccPaymentQuery = _paymentRepository.GetAll()
                                                        .Where(b => b.OwnerBankAccountId == plaidtx.OwnerBankAccountId)
                                                        .OrderByDescending(o => o.CreatedDate);

        decimal bankAccountBalance = 0;
        Payment? lastBankAccPayment = await _paymentRepository.FirstOrDefaultAsync(lastBankAccPaymentQuery);
        if (lastBankAccPayment != null)
            bankAccountBalance = lastBankAccPayment.BankAccountBalance!.Value;

        Payment newPayment = new()
        {
            Amount = command.Amount!.Value,
            Description = $"Payment of {leaseCharge.Description}",
            Date = plaidtx.Date,
            OwnerBankAccountId = plaidtx.OwnerBankAccountId,
            PropertyId = leaseCharge.Transaction.PropertyId,
            RunningBalance = runningBalance + command.Amount!.Value,
            BankAccountBalance = bankAccountBalance + command.Amount!.Value,
            PlaidTransactionId = plaidtx.Id,
            Type = TransactionType.Lease,
            PaymentMethod = PaymentMethod.BankTransfer,
        };

        var txQuery = _transactionRepository.GetAll()
           .Where(b => b.PropertyId == leaseCharge.Transaction.PropertyId)
           .OrderByDescending(o => o.Id);

        Transaction? lastTx = await _transactionRepository.FirstOrDefaultAsync(txQuery);
        if (lastTx == null)
            return OperationResult<CreateLeasePaymentCommandResponse>.ErrorResult(new ErrorDetails(404, "Not found"));

        Transaction tx = Transaction.CreateLeasePayment(leaseCharge.Transaction.PropertyId,
                                                        command.Amount!.Value,
                                                        leaseCharge.LeaseId,
                                                        leaseCharge.Description,
                                                        lastTx.RunningBalance,
                                                        lastTx.EntityRunningBalance,
                                                        plaidtx.Date);

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
            Payment = newPayment,
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
            await _paymentRepository.AddAsync(newPayment);
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
