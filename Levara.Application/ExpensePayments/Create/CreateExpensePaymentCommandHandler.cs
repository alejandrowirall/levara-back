using Levara.Domain.DAL;
using Levara.Domain.DAL.Repositories;
using Levara.Domain.Enum;
using Levara.Domain.Models;
using Levara.Shared.Domain.Bus.Commands;
using Levara.Shared.Results;

namespace Levara.Application.ExpensePayments.Create;

public class CreateExpensePaymentCommandHandler : ICommandHandler<CreateExpensePaymentCommand, CreateExpensePaymentCommandResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IPaymentRepository _paymentRepository;
    private readonly IExpenseRepository _expenseRepository;
    private readonly IExpenseChargeRepository _expenseChargeRepository;
    private readonly IExpensePaymentRepository _expensePaymentRepository;
    private readonly ITransactionRepository _transactionRepository;
    private readonly ITransactionApplicationRepository _transactionApplicationRepository;
    public CreateExpensePaymentCommandHandler(IUnitOfWork unitOfWork,
        IPaymentRepository paymentRepository,
        IExpenseRepository expenseRepository,
        IExpenseChargeRepository expenseChargeRepository,
        IExpensePaymentRepository expensePaymentRepository,
        ITransactionRepository transactionRepository,
        ITransactionApplicationRepository transactionApplicationrepository)
    {
        _unitOfWork = unitOfWork;
        _paymentRepository = paymentRepository;
        _expenseRepository = expenseRepository;
        _expenseChargeRepository = expenseChargeRepository;
        _expensePaymentRepository = expensePaymentRepository;
        _transactionRepository = transactionRepository;
        _transactionApplicationRepository = transactionApplicationrepository;
    }
    public async Task<OperationResult<CreateExpensePaymentCommandResponse>> Handle(CreateExpensePaymentCommand command)
    {
        if (command.TransactionId.HasValue)
            return await GenerateExpensePaymentWithCharge(command);


        return await GenerateExpensePaymentWithoutCharge(command);
    }

    private async Task<OperationResult<CreateExpensePaymentCommandResponse>> GenerateExpensePaymentWithoutCharge(CreateExpensePaymentCommand command)
    {

        var expenseQuery = _expenseRepository.GetAll()
                                             .Where(e => e.Id == command.CreateExpenseCharge!.ExpenseId!.Value);

        var expense = await _expenseRepository.FirstOrDefaultAsync(expenseQuery);
        if (expense == null)
            return OperationResult<CreateExpensePaymentCommandResponse>.ErrorResult(new ErrorDetails(404, "Not found"));

        decimal paymentRunningBalance = await _paymentRepository.GetLastPropertyPaymentRunningBalanceAsync(command.CreateExpenseCharge!.PropertyId!.Value);

        Payment newPayment = new()
        {
            Amount = command.Amount!.Value,
            Description = $"Payment of {expense.Name}",
            Date = command.Date.HasValue ? command.Date!.Value : DateTime.UtcNow,
            OwnerBankAccountId = null,
            PropertyId = command.CreateExpenseCharge!.PropertyId!.Value,
            RunningBalance = paymentRunningBalance - command.Amount!.Value,
            BankAccountRunningBalance = null,
            PlaidTransactionId = null,
            Type = TransactionType.Expense,
            PaymentMethod = PaymentMethod.Cash,
        };

        decimal currentPropertyRunningBalance = await _transactionRepository.GetLastPropertyRunningBalanceAsync(command.CreateExpenseCharge!.PropertyId!.Value);

        Transaction newExpenseChargeTx =
            ExpenseCharge.CreateTransaction(command.CreateExpenseCharge!.PropertyId!.Value,
                                            command.Amount!.Value,
                                            expense.Name,
                                            currentPropertyRunningBalance,
                                            newPayment.Date);

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
                                             newPayment.Date);

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
        });


        CreateExpensePaymentCommandResponse response = new()
        {
            Id = newPayment.Id
        };

        return OperationResult<CreateExpensePaymentCommandResponse>.SuccessResult(response);
    }

    private async Task<OperationResult<CreateExpensePaymentCommandResponse>> GenerateExpensePaymentWithCharge(CreateExpensePaymentCommand command)
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
            return await GenerateExpensePaymentFromUnpaid(expenseCharge, command);

        return await GenerateExpensePaymentFromPartpaid(expenseCharge, command);
    }

    private async Task<OperationResult<CreateExpensePaymentCommandResponse>> GenerateExpensePaymentFromUnpaid(ExpenseCharge expenseCharge,
        CreateExpensePaymentCommand command)

    {

        decimal paymentRunningBalance = await _paymentRepository.GetLastPropertyPaymentRunningBalanceAsync(expenseCharge.Transaction.PropertyId);

        Payment newPayment = new()
        {
            Amount = command.Amount!.Value,
            Description = $"Payment of {expenseCharge.Expense.Name}",
            Date = command.Date.HasValue ? command.Date!.Value : DateTime.UtcNow,
            OwnerBankAccountId = null,
            PropertyId = expenseCharge.Transaction.PropertyId,
            RunningBalance = paymentRunningBalance - command.Amount!.Value,
            BankAccountRunningBalance = null,
            PlaidTransactionId = null,
            Type = TransactionType.Expense,
            PaymentMethod = PaymentMethod.Cash,
        };


        decimal currentPropertyRunningBalance = await _transactionRepository.GetLastPropertyRunningBalanceAsync(expenseCharge.Transaction.PropertyId);

        Transaction tx = ExpensePayment.CreateTransaction(expenseCharge.Transaction.PropertyId,
                                                          command.Amount!.Value,
                                                          expenseCharge.Expense.Name,
                                                          currentPropertyRunningBalance,
                                                          newPayment.Date);

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

        expenseCharge.Transaction.Status = expenseCharge.Transaction.Amount == txAppl.AppliedAmount ? TransactionStatus.Paid : TransactionStatus.PartiallyPaid;

        await _unitOfWork.ExecuteAsTransactionAsync(async () =>
        {
            await _paymentRepository.AddAsync(newPayment);
            await _transactionRepository.AddAsync(tx);
            await _transactionApplicationRepository.AddAsync(txAppl);
            _transactionRepository.Update(expenseCharge.Transaction);
            _expenseChargeRepository.Update(expenseCharge);
            await _expensePaymentRepository.AddAsync(expensePayment);
        });


        CreateExpensePaymentCommandResponse response = new()
        {
            Id = newPayment.Id
        };

        return OperationResult<CreateExpensePaymentCommandResponse>.SuccessResult(response);

    }

    private async Task<OperationResult<CreateExpensePaymentCommandResponse>> GenerateExpensePaymentFromPartpaid(ExpenseCharge expenseCharge,
        CreateExpensePaymentCommand command)
    {

        decimal paymentRunningBalance = await _paymentRepository.GetLastPropertyPaymentRunningBalanceAsync(expenseCharge.Transaction.PropertyId);

        Payment newPayment = new()
        {
            Amount = command.Amount!.Value,
            Description = $"Payment of {expenseCharge.Expense.Name}",
            Date = command.Date.HasValue ? command.Date!.Value : DateTime.UtcNow,
            OwnerBankAccountId = null,
            PropertyId = expenseCharge.Transaction.PropertyId,
            RunningBalance = paymentRunningBalance - command.Amount!.Value,
            BankAccountRunningBalance = null,
            PlaidTransactionId = null,
            Type = TransactionType.Expense,
            PaymentMethod = PaymentMethod.Cash,
        };

        decimal currentPropertyRunningBalance = await _transactionRepository.GetLastPropertyRunningBalanceAsync(expenseCharge.Transaction.PropertyId);

        Transaction tx = ExpensePayment.CreateTransaction(expenseCharge.Transaction.PropertyId,
                                                          command.Amount!.Value,
                                                          expenseCharge.Expense.Name,
                                                          currentPropertyRunningBalance,
                                                          newPayment.Date);

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

        await _unitOfWork.ExecuteAsTransactionAsync(async () =>
        {
            await _paymentRepository.AddAsync(newPayment);
            await _transactionRepository.AddAsync(tx);
            await _transactionApplicationRepository.AddAsync(txAppl);
            _transactionRepository.Update(expenseCharge.Transaction);
            _expenseChargeRepository.Update(expenseCharge);
            await _expensePaymentRepository.AddAsync(expensePayment);
        });


        CreateExpensePaymentCommandResponse response = new()
        {
            Id = newPayment.Id
        };

        return OperationResult<CreateExpensePaymentCommandResponse>.SuccessResult(response);

    }
}
