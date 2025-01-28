using Levara.Domain.DAL;
using Levara.Domain.DAL.Repositories;
using Levara.Domain.Enum;
using Levara.Domain.Models;
using Levara.Shared.Domain.Bus.Commands;
using Levara.Shared.Extensions;
using Levara.Shared.Results;
using Microsoft.EntityFrameworkCore;

namespace Levara.Application.Plaid.CreateExpensePayment;

public class CreateExpensePaymentCommandHandler : ICommandHandler<CreateExpensePaymentCommand, CreateExpensePaymentCommandResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IPlaidRepository _plaidRepository;
    private readonly IBankTransactionRepository _bankTransactionRepository;
    private readonly IExpenseChargeRepository _expenseChargeRepository;
    private readonly IExpensePaymentRepository _expensePaymentRepository;
    private readonly ITransactionRepository _transactionRepository;
    private readonly ITransactionApplicationRepository _transactionApplicationRepository;
    public CreateExpensePaymentCommandHandler(IUnitOfWork unitOfWork,
        IPlaidRepository plaidRepository, 
        IBankTransactionRepository bankTransactionRepository,
        IExpenseChargeRepository expenseChargeRepository,
        IExpensePaymentRepository expensePaymentRepository,
        ITransactionRepository transactionRepository,
        ITransactionApplicationRepository transactionApplicationrepository)
    {
        _unitOfWork = unitOfWork;
        _plaidRepository = plaidRepository;
        _bankTransactionRepository = bankTransactionRepository;
        _expenseChargeRepository = expenseChargeRepository;
        _expensePaymentRepository = expensePaymentRepository;
        _transactionRepository = transactionRepository;
        _transactionApplicationRepository = transactionApplicationrepository;
    }
    public async Task<OperationResult<CreateExpensePaymentCommandResponse>> Handle(CreateExpensePaymentCommand command)
    {

        var plaidTxQuery = _plaidRepository.GetAllWithOwnerBankAccount()
                                           .Where(o => o.Id == command.PlaidId!);

        PlaidTransaction? plaidtx = await _plaidRepository.FirstOrDefaultAsync(plaidTxQuery);
        if (plaidtx == null)
            return OperationResult<CreateExpensePaymentCommandResponse>.ErrorResult(new ErrorDetails(404, "Not found"));

        if (plaidtx.Status != PlaidTransactionStatus.Created && plaidtx.Status != PlaidTransactionStatus.NeedReview)
            return OperationResult<CreateExpensePaymentCommandResponse>.ErrorResult(new ErrorDetails(400, $"Plaid transaction must be in state {EnumExtensions.GetEnumDescription(PlaidTransactionStatus.Created)} or {EnumExtensions.GetEnumDescription(PlaidTransactionStatus.NeedReview)}"));

        if (plaidtx.Amount >= 0)
            return OperationResult<CreateExpensePaymentCommandResponse>.ErrorResult(new ErrorDetails(400, $"Plaid transaction must be less than zero"));

        if (plaidtx.OwnerBankAccount.OwnerId != command.OwnerId)
            return OperationResult<CreateExpensePaymentCommandResponse>.ErrorResult(new ErrorDetails(400, $"Plaid transaction is not owned by the owner"));

        plaidtx.Status = PlaidTransactionStatus.RelevantTransaction;

        var expenseChargeQuery = _expenseChargeRepository.GetAllFull()
                                                             .Where(b => b.Id == command.ExpenseChargeId);

        ExpenseCharge? expenseCharge = await _expenseChargeRepository.FirstOrDefaultAsync(expenseChargeQuery);
        if (expenseCharge == null)
            return OperationResult<CreateExpensePaymentCommandResponse>.ErrorResult(new ErrorDetails(404, "Not found"));

        if (expenseCharge.Transaction.Property.OwnerId != command.OwnerId)
            return OperationResult<CreateExpensePaymentCommandResponse>.ErrorResult(new ErrorDetails(400, "The charge does not belong to a property of the owner"));

        if (expenseCharge.Status == ExpenseChargeStatus.Paid)
            return OperationResult<CreateExpensePaymentCommandResponse>.ErrorResult(new ErrorDetails(400, "The charge must not be in paid status"));

        if (expenseCharge.Status == ExpenseChargeStatus.Unpaid)
            return await GenerateExpensePaymentFromUnpaid(plaidtx, expenseCharge, command);

        return await GenerateExpensePaymentFromPartpaid(plaidtx, expenseCharge, command);
    }

    private async Task<OperationResult<CreateExpensePaymentCommandResponse>> GenerateExpensePaymentFromUnpaid(PlaidTransaction plaidtx,
        ExpenseCharge expenseCharge,
        CreateExpensePaymentCommand command)

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
            OwnerBankAccountId = plaidtx.OwnerBankAccountId,
            PropertyId = expenseCharge.Transaction.PropertyId,
            RunningBalance = runningBalance + plaidtx.Amount,
            PlaidIdTransaction = plaidtx.Id,
            Type = TransactionType.Expense,
        };

        var txQuery = _transactionRepository.GetAll()
           .Where(b => b.PropertyId == expenseCharge.Transaction.PropertyId)
           .OrderByDescending(o => o.Id);

        Transaction? lastTx = await _bankTransactionRepository.FirstOrDefaultAsync(txQuery);
        if (lastTx == null)
            return OperationResult<CreateExpensePaymentCommandResponse>.ErrorResult(new ErrorDetails(404, "Not found"));


        Transaction tx = new()
        {
            Amount = command.Amount!.Value,
            Date = plaidtx.Date,
            Description = "Expense payment " + command.ExpenseChargeId.ToString(),
            RunningBalance = lastTx.RunningBalance + command.Amount!.Value,
            EntityRunningBalance = lastTx.EntityRunningBalance + command.Amount!.Value,
            SubType = TransactionSubType.Payment,
            Type = TransactionType.Expense,
            PropertyId = expenseCharge.Transaction.PropertyId,
            EntityId = expenseCharge.ExpenseId
        };

        TransactionApplication txAppl = new()
        {
            AppliedAmount = (decimal)command.Amount!,
            BankTransaction = newBankTx,
            ChargeTransactionId = expenseCharge.TransactionId,
            PaymentTransaction = tx
        };

        ExpensePayment expensePayment = new()
        {
            ExpenseId = expenseCharge.ExpenseId,
            Transaction = tx,
        };

        expenseCharge.Status = expenseCharge.Transaction.Amount == txAppl.AppliedAmount ? ExpenseChargeStatus.Paid : ExpenseChargeStatus.Partpaid;

        await _unitOfWork.ExecuteAsTransactionAsync(async () =>
        {
            await _bankTransactionRepository.AddAsync(newBankTx);
            await _transactionRepository.AddAsync(tx);
            await _transactionApplicationRepository.AddAsync(txAppl);
            _expenseChargeRepository.Update(expenseCharge);
            await _expensePaymentRepository.AddAsync(expensePayment);
            _plaidRepository.Update(plaidtx);
        });


        CreateExpensePaymentCommandResponse response = new()
        {
            Id = plaidtx.Id
        };

        return OperationResult<CreateExpensePaymentCommandResponse>.SuccessResult(response);

    }

    private async Task<OperationResult<CreateExpensePaymentCommandResponse>> GenerateExpensePaymentFromPartpaid(PlaidTransaction plaidtx,
        ExpenseCharge expenseCharge,
        CreateExpensePaymentCommand command)
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
            OwnerBankAccountId = plaidtx.OwnerBankAccountId,
            PropertyId = expenseCharge.Transaction.PropertyId,
            RunningBalance = runningBalance + plaidtx.Amount,
            PlaidIdTransaction = plaidtx.Id,
            Type = TransactionType.Expense,
        };

        var txQuery = _transactionRepository.GetAll()
           .Where(b => b.PropertyId == expenseCharge.Transaction.PropertyId)
           .OrderByDescending(o => o.Id);

        Transaction? lastTx = await _bankTransactionRepository.FirstOrDefaultAsync(txQuery);
        if (lastTx == null)
            return OperationResult<CreateExpensePaymentCommandResponse>.ErrorResult(new ErrorDetails(404, "Not found"));


        Transaction tx = new()
        {
            Amount = command.Amount!.Value,
            Date = plaidtx.Date,
            Description = "Expense payment " + command.ExpenseChargeId.ToString(),
            RunningBalance = lastTx.RunningBalance + command.Amount!.Value,
            EntityRunningBalance = lastTx.EntityRunningBalance + command.Amount!.Value,
            SubType = TransactionSubType.Payment,
            Type = TransactionType.Expense,
            PropertyId = expenseCharge.Transaction.PropertyId,
            EntityId = expenseCharge.ExpenseId

        };

        var currentTotalAmountTxAp = await _transactionApplicationRepository.GetAll()
                                                                            .Where(ta => ta.ChargeTransactionId == expenseCharge.TransactionId)
                                                                            .Select(ta => ta.AppliedAmount)
                                                                            .SumAsync();

        decimal newTotalAmountTxAp = currentTotalAmountTxAp + command.Amount!.Value;

        if (newTotalAmountTxAp > expenseCharge.Transaction.Amount)
            return OperationResult<CreateExpensePaymentCommandResponse>.ErrorResult(new ErrorDetails(400, "Invalid amount"));

        TransactionApplication txAppl = new()
        {
            AppliedAmount = command.Amount!.Value,
            BankTransaction = newBankTx,
            ChargeTransactionId = expenseCharge.TransactionId,
            PaymentTransaction = tx
        };

        ExpensePayment expensePayment = new()
        {
            ExpenseId = expenseCharge.ExpenseId,
            Transaction = tx,
        };


        expenseCharge.Status = expenseCharge.Transaction.Amount == newTotalAmountTxAp ? ExpenseChargeStatus.Paid : ExpenseChargeStatus.Partpaid;

        await _unitOfWork.ExecuteAsTransactionAsync(async () =>
        {
            await _bankTransactionRepository.AddAsync(newBankTx);
            await _transactionRepository.AddAsync(tx);
            await _transactionApplicationRepository.AddAsync(txAppl);
            _expenseChargeRepository.Update(expenseCharge);
            await _expensePaymentRepository.AddAsync(expensePayment);
            _plaidRepository.Update(plaidtx);
        });


        CreateExpensePaymentCommandResponse response = new()
        {
            Id = plaidtx.Id
        };

        return OperationResult<CreateExpensePaymentCommandResponse>.SuccessResult(response);

    }
}
