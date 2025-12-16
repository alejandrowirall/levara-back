using Levara.DAL;
using Levara.DAL.Repositories;
using Levara.Domain;
using Levara.Domain.DAL;
using Levara.Domain.DAL.Repositories;
using Levara.Domain.Enum;
using Levara.Domain.Models;
using Levara.Shared.Extensions;
using Levara.Shared.Results;

namespace Levara.Application.Plaid.CreateExpensePayment;

public class CreateExpensePaymentCommandService : Service
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IPlaidRepository _plaidRepository;
    private readonly IPaymentRepository _paymentRepository;
    private readonly IExpenseRepository _expenseRepository;
    private readonly IExpenseChargeRepository _expenseChargeRepository;
    private readonly IExpensePaymentRepository _expensePaymentRepository;
    private readonly ITransactionRepository _transactionRepository;
    private readonly ITransactionApplicationRepository _transactionApplicationRepository;
    public CreateExpensePaymentCommandService(IUnitOfWork unitOfWork,
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

        if (plaidtx.Status != PlaidTransactionStatus.Created &&
            plaidtx.Status != PlaidTransactionStatus.NeedReview &&
            plaidtx.Status != PlaidTransactionStatus.NoMatch &&
            plaidtx.Status != PlaidTransactionStatus.Error)
            return OperationResult<CreateExpensePaymentCommandResponse>.ErrorResult(new ErrorDetails(400, $"Plaid transaction must be in state {EnumExtensions.GetEnumDescription(PlaidTransactionStatus.Created)} or {EnumExtensions.GetEnumDescription(PlaidTransactionStatus.NeedReview)} or {EnumExtensions.GetEnumDescription(PlaidTransactionStatus.NoMatch)} or {EnumExtensions.GetEnumDescription(PlaidTransactionStatus.Error)}"));

        //if (plaidtx.Amount >= 0)
        //    return OperationResult<CreateExpensePaymentCommandResponse>.ErrorResult(new ErrorDetails(400, $"Plaid transaction must be less than zero"));

        if (command.Amount!.Value > Math.Abs(plaidtx.Amount))
            return OperationResult<CreateExpensePaymentCommandResponse>.ErrorResult(new ErrorDetails(400, $"The amount must be less than or equal to the Plaid transaction amount"));

        if (plaidtx.OwnerBankAccount.OwnerId != command.OwnerId)
            return OperationResult<CreateExpensePaymentCommandResponse>.ErrorResult(new ErrorDetails(400, $"Plaid transaction is not owned by the owner"));

        plaidtx.Status = PlaidTransactionStatus.Reconciled;

        if (command.TransactionId.HasValue)
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

        decimal runningBalance = await _paymentRepository.GetLastPropertyPaymentRunningBalanceAsync(command.CreateExpenseCharge!.PropertyId!.Value);
        decimal bankAccountRunningBalance = await _paymentRepository.GetLastBankAccountRunningBalanceAsync(plaidtx.OwnerBankAccountId);

        Payment newPayment = new()
        {
            Amount = command.Amount!.Value,
            Description = $"Payment of {expense.Name}",
            Date = plaidtx.Date,
            OwnerBankAccountId = plaidtx.OwnerBankAccountId,
            PropertyId = command.CreateExpenseCharge!.PropertyId!.Value,
            RunningBalance = runningBalance - command.Amount!.Value,
            BankAccountRunningBalance = bankAccountRunningBalance - command.Amount!.Value,
            PlaidTransactionId = plaidtx.Id,
            Type = TransactionType.Expense,
            PaymentMethod = PaymentMethod.BankTransfer,
        };

        decimal currentRunningBalance = await _transactionRepository.GetLastPropertyRunningBalanceAsync(command.CreateExpenseCharge!.PropertyId!.Value);

        Transaction newExpenseChargeTx =
            ExpenseCharge.CreateTransaction(command.CreateExpenseCharge!.PropertyId!.Value,
                                            command.Amount!.Value,
                                            expense.Name,
                                            currentRunningBalance,
                                            DateTime.UtcNow,
                                            plaidtx.Date);

        newExpenseChargeTx.Status = TransactionStatus.Paid;

        ExpenseCharge newExpenseCharge = new()
        {
            Transaction = newExpenseChargeTx,
            ExpenseId = expense.Id,
        };

        Transaction newExpensePaymentTx =
            ExpensePayment.CreateTransaction(command.CreateExpenseCharge!.PropertyId!.Value,
                                             command.Amount!.Value,
                                             expense.Name,
                                             newExpenseChargeTx.RunningBalance,
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

        await _paymentRepository.AddAsync(newPayment);

        await _transactionRepository.AddAsync(newExpenseChargeTx);

        await _transactionRepository.AddAsync(newExpensePaymentTx);

        await _transactionApplicationRepository.AddAsync(txAppl);

        await _expenseChargeRepository.AddAsync(newExpenseCharge);
        await _expensePaymentRepository.AddAsync(newExpensePayment);
        _plaidRepository.Update(plaidtx);

        await _unitOfWork.SaveChangesAsync();

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
                                                         .Where(b => b.TransactionId == command.TransactionId);

        ExpenseCharge? expenseCharge = await _expenseChargeRepository.FirstOrDefaultAsync(expenseChargeQuery);
        if (expenseCharge == null)
            return OperationResult<CreateExpensePaymentCommandResponse>.ErrorResult(new ErrorDetails(404, $"Not found expense charge with TransactionId: {command.TransactionId}"));

        if (expenseCharge.Transaction.Property.OwnerId != command.OwnerId)
            return OperationResult<CreateExpensePaymentCommandResponse>.ErrorResult(new ErrorDetails(400, "The charge does not belong to a property of the owner"));

        if (expenseCharge.Transaction.Status == TransactionStatus.Paid)
            return OperationResult<CreateExpensePaymentCommandResponse>.ErrorResult(new ErrorDetails(400, "The charge must not be in paid status"));

        if (expenseCharge.Transaction.Status == TransactionStatus.Unpaid)
            return await GenerateExpensePaymentFromUnpaid(plaidtx, expenseCharge, command);

        return await GenerateExpensePaymentFromPartpaid(plaidtx, expenseCharge, command);
    }

    private async Task<OperationResult<CreateExpensePaymentCommandResponse>> GenerateExpensePaymentFromUnpaid(PlaidTransaction plaidtx,
        ExpenseCharge expenseCharge,
        CreateExpensePaymentCommand command)

    {

        decimal runningBalance = await _paymentRepository.GetLastPropertyPaymentRunningBalanceAsync(expenseCharge.Transaction.PropertyId);
        decimal bankAccountRunningBalance = await _paymentRepository.GetLastBankAccountRunningBalanceAsync(plaidtx.OwnerBankAccountId);

        Payment newPayment = new()
        {
            Amount = command.Amount!.Value,
            Description = $"Payment of {expenseCharge.Expense.Name}",
            Date = plaidtx.Date,
            OwnerBankAccountId = plaidtx.OwnerBankAccountId,
            PropertyId = expenseCharge.Transaction.PropertyId,
            RunningBalance = runningBalance - command.Amount!.Value,
            BankAccountRunningBalance = bankAccountRunningBalance - command.Amount!.Value,
            PlaidTransactionId = plaidtx.Id,
            Type = TransactionType.Expense,
            PaymentMethod = PaymentMethod.BankTransfer,
        };

        decimal currentRunningBalance = await _transactionRepository.GetLastPropertyRunningBalanceAsync(expenseCharge.Transaction.PropertyId);

        Transaction tx = ExpensePayment.CreateTransaction(expenseCharge.Transaction.PropertyId,
                                                          command.Amount!.Value,
                                                          expenseCharge.Expense.Name,
                                                          currentRunningBalance,
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

        expenseCharge.Transaction.Status = expenseCharge.Transaction.Amount == txAppl.AppliedAmount ? TransactionStatus.Paid : TransactionStatus.PartiallyPaid;

        await _paymentRepository.AddAsync(newPayment);
        await _transactionRepository.AddAsync(tx);
        await _transactionApplicationRepository.AddAsync(txAppl);
        _transactionRepository.Update(expenseCharge.Transaction);
        _expenseChargeRepository.Update(expenseCharge);
        await _expensePaymentRepository.AddAsync(expensePayment);
        _plaidRepository.Update(plaidtx);

        await _unitOfWork.SaveChangesAsync();

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


        decimal runningBalance = await _paymentRepository.GetLastPropertyPaymentRunningBalanceAsync(expenseCharge.Transaction.PropertyId);
        decimal bankAccountRunningBalance = await _paymentRepository.GetLastBankAccountRunningBalanceAsync(plaidtx.OwnerBankAccountId);

        Payment newPayment = new()
        {
            Amount = command.Amount!.Value,
            Description = $"Payment of {expenseCharge.Expense.Name}",
            Date = plaidtx.Date,
            OwnerBankAccountId = plaidtx.OwnerBankAccountId,
            PropertyId = expenseCharge.Transaction.PropertyId,
            RunningBalance = runningBalance - command.Amount!.Value,
            BankAccountRunningBalance = bankAccountRunningBalance - command.Amount!.Value,
            PlaidTransactionId = plaidtx.Id,
            Type = TransactionType.Expense,
            PaymentMethod = PaymentMethod.BankTransfer,
        };

        decimal currentRunningBalance = await _transactionRepository.GetLastPropertyRunningBalanceAsync(expenseCharge.Transaction.PropertyId);

        Transaction tx = ExpensePayment.CreateTransaction(expenseCharge.Transaction.PropertyId,
                                                          command.Amount!.Value,
                                                          expenseCharge.Expense.Name,
                                                          currentRunningBalance,
                                                          plaidtx.Date);

        var currentTotalAmountTxAp = await _transactionApplicationRepository.GetTotalAppliedAmountByChargeTransactionAsync(expenseCharge.TransactionId);

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


        expenseCharge.Transaction.Status = expenseCharge.Transaction.Amount == newTotalAmountTxAp ? TransactionStatus.Paid : TransactionStatus.PartiallyPaid;

        await _paymentRepository.AddAsync(newPayment);
        await _transactionRepository.AddAsync(tx);
        await _transactionApplicationRepository.AddAsync(txAppl);
        _transactionRepository.Update(expenseCharge.Transaction);
        _expenseChargeRepository.Update(expenseCharge);
        await _expensePaymentRepository.AddAsync(expensePayment);
        _plaidRepository.Update(plaidtx);

        await _unitOfWork.SaveChangesAsync();

        CreateExpensePaymentCommandResponse response = new()
        {
            Id = plaidtx.Id
        };

        return OperationResult<CreateExpensePaymentCommandResponse>.SuccessResult(response);

    }
}
