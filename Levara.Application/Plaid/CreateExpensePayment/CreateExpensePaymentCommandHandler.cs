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
    private readonly IPaymentRepository _paymentRepository;
    private readonly IExpenseRepository _expenseRepository;
    private readonly IExpenseChargeRepository _expenseChargeRepository;
    private readonly IExpensePaymentRepository _expensePaymentRepository;
    private readonly ITransactionRepository _transactionRepository;
    private readonly ITransactionApplicationRepository _transactionApplicationRepository;
    public CreateExpensePaymentCommandHandler(IUnitOfWork unitOfWork,
        IPlaidRepository plaidRepository,
        IPaymentRepository paymentRepository,
        IExpenseRepository expenseRepository,
        IExpenseChargeRepository expenseChargeRepository,
        IExpensePaymentRepository expensePaymentRepository,
        ITransactionRepository transactionRepository,
        ITransactionApplicationRepository transactionApplicationrepository)
    {
        _unitOfWork = unitOfWork;
        _plaidRepository = plaidRepository;
        _paymentRepository = paymentRepository;
        _expenseRepository = expenseRepository;
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

        //if (plaidtx.Amount >= 0)
        //    return OperationResult<CreateExpensePaymentCommandResponse>.ErrorResult(new ErrorDetails(400, $"Plaid transaction must be less than zero"));

        if (command.Amount!.Value > Math.Abs(plaidtx.Amount))
            return OperationResult<CreateExpensePaymentCommandResponse>.ErrorResult(new ErrorDetails(400, $"The amount must be less than or equal to the Plaid transaction amount"));

        if (plaidtx.OwnerBankAccount.OwnerId != command.OwnerId)
            return OperationResult<CreateExpensePaymentCommandResponse>.ErrorResult(new ErrorDetails(400, $"Plaid transaction is not owned by the owner"));

        plaidtx.Status = PlaidTransactionStatus.RelevantTransaction;

        if (command.ExpenseChargeId.HasValue)
           return await GenerateExpensePaymentWithCharge(plaidtx, command);


        return await GenerateExpensePaymentWithoutCharge(plaidtx, command);
    }

    private async Task<OperationResult<CreateExpensePaymentCommandResponse>> GenerateExpensePaymentWithoutCharge(PlaidTransaction plaidtx,
        CreateExpensePaymentCommand command)
    {

        var expenseQuery = _expenseRepository.GetAll()
                                             .Where(e => e.Id == command.CreateExpenseCharge!.ExpenseId!.Value);

        var expense = await _expenseRepository.FirstOrDefaultAsync(expenseQuery);
        if(expense == null)
            return OperationResult<CreateExpensePaymentCommandResponse>.ErrorResult(new ErrorDetails(404, "Not found"));

        var lastPropertyPaymentQuery = _paymentRepository.GetAll()
                                                         .Where(b => b.PropertyId == command.CreateExpenseCharge!.PropertyId!.Value)
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
            Description = $"Payment of {expense.Name}",
            Date = plaidtx.Date,
            OwnerBankAccountId = plaidtx.OwnerBankAccountId,
            PropertyId = command.CreateExpenseCharge!.PropertyId!.Value,
            RunningBalance = runningBalance - command.Amount!.Value,
            BankAccountBalance = bankAccountBalance - command.Amount!.Value,
            PlaidTransactionId = plaidtx.Id,
            Type = TransactionType.Expense,
            PaymentMethod = PaymentMethod.BankTransfer,
        };

        var txQuery = _transactionRepository.GetAll()
           .Where(b => b.PropertyId == command.CreateExpenseCharge!.PropertyId!.Value)
           .OrderByDescending(o => o.Id);

        Transaction? lastTx = await _transactionRepository.FirstOrDefaultAsync(txQuery);

        decimal currentRunningBalance = 0;
        decimal currentEntityRunningBalance = 0;

        if (lastTx != null)
        {
            currentRunningBalance = lastTx.RunningBalance;
            currentEntityRunningBalance = lastTx.EntityRunningBalance;   
        }

        Transaction newExpenseChargeTx =
            Transaction.CreateExpenseCharge(command.CreateExpenseCharge!.PropertyId!.Value,
                                            command.Amount!.Value,
                                            expense.Id,
                                            expense.Name,
                                            currentRunningBalance,
                                            currentEntityRunningBalance,
                                            plaidtx.Date);

        ExpenseCharge newExpenseCharge = new()
        {
            Transaction = newExpenseChargeTx,
            ExpenseId = expense.Id,
            DueDate = DateTime.UtcNow,
            Status = ExpenseChargeStatus.Paid,
        };

        Transaction newExpensePaymentTx =
            Transaction.CreateExpensePayment(command.CreateExpenseCharge!.PropertyId!.Value,
                                             command.Amount!.Value,
                                             expense.Id,
                                             expense.Name,
                                             newExpenseChargeTx.RunningBalance,
                                             newExpenseChargeTx.EntityRunningBalance,
                                             plaidtx.Date);

        TransactionApplication txAppl = new()
        {
            AppliedAmount = (decimal)command.Amount!,
            Payment = newPayment,
            ChargeTransaction = newExpenseChargeTx,
            PaymentTransaction = newExpensePaymentTx
        };

        ExpensePayment newExpensePayment = new()
        {
            ExpenseId = expense.Id,
            Transaction = newExpensePaymentTx,
        };

        await _unitOfWork.ExecuteAsTransactionAsync(async () =>
        {
            await _paymentRepository.AddAsync(newPayment);

            await _transactionRepository.AddAsync(newExpenseChargeTx);

            await _transactionRepository.AddAsync(newExpensePaymentTx);

            await _transactionApplicationRepository.AddAsync(txAppl);

            await _expenseChargeRepository.AddAsync(newExpenseCharge);
            await _expensePaymentRepository.AddAsync(newExpensePayment);
            _plaidRepository.Update(plaidtx);
        });


        CreateExpensePaymentCommandResponse response = new()
        {
            Id = plaidtx.Id
        };

        return OperationResult<CreateExpensePaymentCommandResponse>.SuccessResult(response);
    }

    private async Task<OperationResult<CreateExpensePaymentCommandResponse>> GenerateExpensePaymentWithCharge(PlaidTransaction plaidtx,
        CreateExpensePaymentCommand command)
    {
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

        var lastPropertyPaymentQuery = _paymentRepository.GetAll()
                                                         .Where(b => b.PropertyId == expenseCharge.Transaction.PropertyId)
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
            Description = $"Payment of {expenseCharge.Expense.Name}",
            Date = plaidtx.Date,
            OwnerBankAccountId = plaidtx.OwnerBankAccountId,
            PropertyId = expenseCharge.Transaction.PropertyId,
            RunningBalance = runningBalance - command.Amount!.Value,
            BankAccountBalance = bankAccountBalance - command.Amount!.Value,
            PlaidTransactionId = plaidtx.Id,
            Type = TransactionType.Expense,
            PaymentMethod = PaymentMethod.BankTransfer,
        };

        var txQuery = _transactionRepository.GetAll()
           .Where(b => b.PropertyId == expenseCharge.Transaction.PropertyId)
           .OrderByDescending(o => o.CreatedDate);

        Transaction? lastTx = await _transactionRepository.FirstOrDefaultAsync(txQuery);
        if (lastTx == null)
            return OperationResult<CreateExpensePaymentCommandResponse>.ErrorResult(new ErrorDetails(404, "Not found"));

        Transaction tx = Transaction.CreateExpensePayment(expenseCharge.Transaction.PropertyId,
                                                          command.Amount!.Value,
                                                          expenseCharge.ExpenseId,
                                                          expenseCharge.Expense.Name,
                                                          lastTx.RunningBalance,
                                                          lastTx.EntityRunningBalance,
                                                          plaidtx.Date);

        TransactionApplication txAppl = new()
        {
            AppliedAmount = (decimal)command.Amount!,
            Payment = newPayment,
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
            await _paymentRepository.AddAsync(newPayment);
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


        var lastPropertyPaymentQuery = _paymentRepository.GetAll()
                                                         .Where(b => b.PropertyId == expenseCharge.Transaction.PropertyId)
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
            Description = $"Payment of {expenseCharge.Expense.Name}",
            Date = plaidtx.Date,
            OwnerBankAccountId = plaidtx.OwnerBankAccountId,
            PropertyId = expenseCharge.Transaction.PropertyId,
            RunningBalance = runningBalance - command.Amount!.Value,
            BankAccountBalance = bankAccountBalance - command.Amount!.Value,
            PlaidTransactionId = plaidtx.Id,
            Type = TransactionType.Expense,
            PaymentMethod = PaymentMethod.BankTransfer,
        };

        var txQuery = _transactionRepository.GetAll()
           .Where(b => b.PropertyId == expenseCharge.Transaction.PropertyId)
           .OrderByDescending(o => o.Id);

        Transaction? lastTx = await _transactionRepository.FirstOrDefaultAsync(txQuery);
        if (lastTx == null)
            return OperationResult<CreateExpensePaymentCommandResponse>.ErrorResult(new ErrorDetails(404, "Not found"));

        Transaction tx = Transaction.CreateExpensePayment(expenseCharge.Transaction.PropertyId,
                                                          command.Amount!.Value,
                                                          expenseCharge.ExpenseId,
                                                          expenseCharge.Expense.Name,
                                                          lastTx.RunningBalance,
                                                          lastTx.EntityRunningBalance,
                                                          plaidtx.Date);

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
            Payment = newPayment,
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
            await _paymentRepository.AddAsync(newPayment);
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
