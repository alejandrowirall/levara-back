using Levara.DAL.Repositories;
using Levara.Domain.DAL;
using Levara.Domain.DAL.Repositories;
using Levara.Domain.Enum;
using Levara.Domain.Models;
using Levara.Shared.Domain.Bus.Commands;
using Levara.Shared.Extensions;
using Levara.Shared.Results;

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

        //if (plaidtx.Amount < 0)
        //    return OperationResult<CreateLeasePaymentCommandResponse>.ErrorResult(new ErrorDetails(400, $"Plaid transaction must be greater than zero"));

        if (command.Amount!.Value > Math.Abs(plaidtx.Amount))
            return OperationResult<CreateLeasePaymentCommandResponse>.ErrorResult(new ErrorDetails(400, $"The amount must be less than or equal to the Plaid transaction amount"));

        if (plaidtx.OwnerBankAccount.OwnerId != command.OwnerId)
            return OperationResult<CreateLeasePaymentCommandResponse>.ErrorResult(new ErrorDetails(400, $"Plaid transaction is not owned by the owner"));

        plaidtx.Status = PlaidTransactionStatus.RelevantTransaction;

        if (command.TransactionId.HasValue)
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

        decimal runningBalance = await _paymentRepository.GetLastPropertyPaymentRunningBalanceAsync(lease.PropertyId);
        decimal bankAccountRunningBalance = await _paymentRepository.GetLastBankAccountRunningBalanceAsync(plaidtx.OwnerBankAccountId);
        decimal leasePaymentRunningBalance = await _paymentRepository.GetLastLeasePaymentRunningBalanceAsync(command.CreateLeaseCharge!.LeaseId!.Value);

        Payment newPayment = new()
        {
            Amount = command.Amount!.Value,
            Description = $"Payment of {command.CreateLeaseCharge!.Description}",
            Date = plaidtx.Date,
            OwnerBankAccountId = plaidtx.OwnerBankAccountId,
            PropertyId = lease.PropertyId,
            RunningBalance = runningBalance + command.Amount!.Value,
            BankAccountRunningBalance = bankAccountRunningBalance + command.Amount!.Value,
            LeaseId = command.CreateLeaseCharge!.LeaseId!.Value,
            LeaseRunningBalance = leasePaymentRunningBalance + command.Amount!.Value,
            PlaidTransactionId = plaidtx.Id,
            Type = TransactionType.Lease,
            PaymentMethod = PaymentMethod.BankTransfer,
        };

        decimal currentPropertyRunningBalance = await _transactionRepository.GetLastPropertyRunningBalanceAsync(lease.PropertyId);
        decimal currentLeaseRunningBalance = await _transactionRepository.GetLastLeaseRunningBalanceAsync(command.CreateLeaseCharge!.LeaseId!.Value);

        Transaction newLeaseChargeTx =
            LeaseCharge.CreateTransaction(lease.PropertyId,
                                          command.Amount!.Value,
                                          command.CreateLeaseCharge!.LeaseId!.Value,
                                          command.CreateLeaseCharge!.Description,
                                          currentPropertyRunningBalance,
                                          currentLeaseRunningBalance,
                                          DateTime.UtcNow,
                                          plaidtx.Date);

        newLeaseChargeTx.Status = TransactionStatus.Paid;

        LeaseCharge newLeaseCharge = new()
        {
            Transaction = newLeaseChargeTx,
            Description = command.CreateLeaseCharge!.Description,
            LeaseId = lease.Id,
        };

        Transaction newLeasePaymentTx =
            LeasePayment.CreateTransaction(lease.PropertyId,
                                           command.Amount!.Value,
                                           command.CreateLeaseCharge!.LeaseId!.Value,
                                           command.CreateLeaseCharge!.Description,
                                           newLeaseChargeTx.RunningBalance,
                                           newLeaseChargeTx.LeaseRunningBalance!.Value,
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
                                                     .Where(b => b.TransactionId == command.TransactionId);

        LeaseCharge? leaseCharge = await _leaseChargeRepository.FirstOrDefaultAsync(leaseChargeQuery);
        if (leaseCharge == null)
            return OperationResult<CreateLeasePaymentCommandResponse>.ErrorResult(new ErrorDetails(404, $"Not found lease charge with TransactionId: {command.TransactionId}"));

        if (leaseCharge.Lease.OwnerId != command.OwnerId)
            return OperationResult<CreateLeasePaymentCommandResponse>.ErrorResult(new ErrorDetails(400, "The charge does not belong to a lease of the owner"));

        if (leaseCharge.Transaction.Status == TransactionStatus.Paid)
            return OperationResult<CreateLeasePaymentCommandResponse>.ErrorResult(new ErrorDetails(400, "The charge must not be in paid status"));

        if (leaseCharge.Transaction.Status == TransactionStatus.Unpaid)
            return await GenerateLeasePaymentFromUnpaid(plaidtx, leaseCharge, command);

        return await GenerateLeasePaymentFromPartpaid(plaidtx, leaseCharge, command);
    }

    private async Task<OperationResult<CreateLeasePaymentCommandResponse>> GenerateLeasePaymentFromUnpaid(PlaidTransaction plaidtx,
        LeaseCharge leaseCharge,
        CreateLeasePaymentCommand command)

    {

        decimal runningBalance = await _paymentRepository.GetLastPropertyPaymentRunningBalanceAsync(leaseCharge.Transaction.PropertyId);
        decimal bankAccountRunningBalance = await _paymentRepository.GetLastBankAccountRunningBalanceAsync(plaidtx.OwnerBankAccountId);
        decimal leasePaymentRunningBalance = await _paymentRepository.GetLastLeasePaymentRunningBalanceAsync(leaseCharge.LeaseId);

        Payment newPayment = new()
        {
            Amount = command.Amount!.Value,
            Description = $"Payment of {leaseCharge.Description}",
            Date = plaidtx.Date,
            OwnerBankAccountId = plaidtx.OwnerBankAccountId,
            PropertyId = leaseCharge.Transaction.PropertyId,
            RunningBalance = runningBalance + command.Amount!.Value,
            BankAccountRunningBalance = bankAccountRunningBalance + command.Amount!.Value,
            LeaseId = leaseCharge.LeaseId,
            LeaseRunningBalance = leasePaymentRunningBalance + command.Amount!.Value,
            PlaidTransactionId = plaidtx.Id,
            Type = TransactionType.Lease,
            PaymentMethod = PaymentMethod.BankTransfer,
        };

        decimal currentPropertyRunningBalance = await _transactionRepository.GetLastPropertyRunningBalanceAsync(leaseCharge.Transaction.PropertyId);
        decimal currentLeaseRunningBalance = await _transactionRepository.GetLastLeaseRunningBalanceAsync(leaseCharge.LeaseId);

        Transaction tx = LeasePayment.CreateTransaction(leaseCharge.Transaction.PropertyId,
                                                        command.Amount!.Value,
                                                        leaseCharge.LeaseId,
                                                        leaseCharge.Description,
                                                        currentPropertyRunningBalance,
                                                        currentLeaseRunningBalance,
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

        leaseCharge.Transaction.Status = leaseCharge.Transaction.Amount == txAppl.AppliedAmount ? TransactionStatus.Paid : TransactionStatus.PartiallyPaid;


        await _unitOfWork.ExecuteAsTransactionAsync(async () =>
        {
            await _paymentRepository.AddAsync(newPayment);
            await _transactionRepository.AddAsync(tx);
            await _transactionApplicationRepository.AddAsync(txAppl);
            _transactionRepository.Update(leaseCharge.Transaction);
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


        decimal runningBalance = await _paymentRepository.GetLastPropertyPaymentRunningBalanceAsync(leaseCharge.Transaction.PropertyId);
        decimal bankAccountRunningBalance = await _paymentRepository.GetLastBankAccountRunningBalanceAsync(plaidtx.OwnerBankAccountId);
        decimal leasePaymentRunningBalance = await _paymentRepository.GetLastLeasePaymentRunningBalanceAsync(leaseCharge.LeaseId);

        Payment newPayment = new()
        {
            Amount = command.Amount!.Value,
            Description = $"Payment of {leaseCharge.Description}",
            Date = plaidtx.Date,
            OwnerBankAccountId = plaidtx.OwnerBankAccountId,
            PropertyId = leaseCharge.Transaction.PropertyId,
            RunningBalance = runningBalance + command.Amount!.Value,
            BankAccountRunningBalance = bankAccountRunningBalance + command.Amount!.Value,
            LeaseId = leaseCharge.LeaseId,
            LeaseRunningBalance = leasePaymentRunningBalance + command.Amount!.Value,
            PlaidTransactionId = plaidtx.Id,
            Type = TransactionType.Lease,
            PaymentMethod = PaymentMethod.BankTransfer,
        };

        decimal currentPropertyRunningBalance = await _transactionRepository.GetLastPropertyRunningBalanceAsync(leaseCharge.Transaction.PropertyId);
        decimal currentLeaseRunningBalance = await _transactionRepository.GetLastLeaseRunningBalanceAsync(leaseCharge.LeaseId);

        Transaction tx = LeasePayment.CreateTransaction(leaseCharge.Transaction.PropertyId,
                                                        command.Amount!.Value,
                                                        leaseCharge.LeaseId,
                                                        leaseCharge.Description,
                                                        currentPropertyRunningBalance,
                                                        currentLeaseRunningBalance,
                                                        plaidtx.Date);

        var currentTotalAmountTxAp = await _transactionApplicationRepository.GetTotalAppliedAmountByChargeTransactionAsync(leaseCharge.TransactionId);

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


        leaseCharge.Transaction.Status = leaseCharge.Transaction.Amount == newTotalAmountTxAp ? TransactionStatus.Paid : TransactionStatus.PartiallyPaid;

        await _unitOfWork.ExecuteAsTransactionAsync(async () =>
        {
            await _paymentRepository.AddAsync(newPayment);
            await _transactionRepository.AddAsync(tx);
            await _transactionApplicationRepository.AddAsync(txAppl);
            _transactionRepository.Update(leaseCharge.Transaction);
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
