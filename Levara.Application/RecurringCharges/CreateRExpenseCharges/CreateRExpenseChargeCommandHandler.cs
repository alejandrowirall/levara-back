using Levara.Domain.DAL;
using Levara.Domain.DAL.Repositories;
using Levara.Domain.Models;
using Levara.Shared.Domain.Bus.Commands;
using Levara.Shared.Results;

namespace Levara.Application.RecurringCharges.CreateRExpenseCharges;

public class CreateRExpenseChargeCommandHandler : ICommandHandler<CreateRExpenseChargeCommand, CreateRExpenseChargeCommandResponse>
{
    private readonly IUnitOfWork _unitOfWork;

    private readonly IPropertyRepository _propertyRepository;
    private readonly IExpenseRepository _expenseRepository;

    private readonly IRecurringChargeRepository _recurringChargeRepository;
    
    public CreateRExpenseChargeCommandHandler(IUnitOfWork unitOfWork,
        IPropertyRepository propertyRepository,
        IExpenseRepository expenseRepository,
        IRecurringChargeRepository recurringChargeRepository)
    {
        _unitOfWork = unitOfWork;
        _propertyRepository = propertyRepository;
        _expenseRepository = expenseRepository;
        _recurringChargeRepository = recurringChargeRepository;
    }
    public async Task<OperationResult<CreateRExpenseChargeCommandResponse>> Handle(CreateRExpenseChargeCommand command)
    {
        Property? property = await _propertyRepository.FirstOrDefaultAsync(p => p.Id == command.PropertyId && 
                                                                                p.OwnerId == command.OwnerId);

        if (property == null)
            return OperationResult<CreateRExpenseChargeCommandResponse>.ErrorResult(new ErrorDetails(404, $"Not found Property with id {command.PropertyId} for Owner with id {command.OwnerId}"));

        if (!await _expenseRepository.AnyAsync(lct => lct.Id == command.ExpenseId))
            return OperationResult<CreateRExpenseChargeCommandResponse>.ErrorResult(new ErrorDetails(404, $"Not found Expense with id {command.ExpenseId}"));

        var validationResult = ValidateBusinessRules(command);
        if (!validationResult.Success)
            return validationResult;


        var newRecurringCharge = RecurringCharge.CreateForExpense(
            property.Id,
            command.ExpenseId!.Value,
            command.IsRecurrent!.Value,
            command.Amount,
            command.Frequency,
            command.StartDate,
            command.EndDate,
            command.Active!.Value,
            command.MatchTags);

        await _recurringChargeRepository.AddAsync(newRecurringCharge);
        await _unitOfWork.SaveChangesAsync();


        CreateRExpenseChargeCommandResponse response = new()
        {
            Id = newRecurringCharge.Id
        };

        return OperationResult<CreateRExpenseChargeCommandResponse>.SuccessResult(response);

    }

    private OperationResult<CreateRExpenseChargeCommandResponse> ValidateBusinessRules(CreateRExpenseChargeCommand command)
    {
        if (command.IsRecurrent == true)
        {
            if (!command.Amount.HasValue)
                return OperationResult<CreateRExpenseChargeCommandResponse>.ErrorResult(
                    new ErrorDetails(400, "Amount is required for recurrent charges"));

            if (!command.Frequency.HasValue)
                return OperationResult<CreateRExpenseChargeCommandResponse>.ErrorResult(
                    new ErrorDetails(400, "Frequency is required for recurrent charges"));

            if (!command.StartDate.HasValue)
                return OperationResult<CreateRExpenseChargeCommandResponse>.ErrorResult(
                    new ErrorDetails(400, "StartDate is required for recurrent charges"));

            if (!command.EndDate.HasValue)
                return OperationResult<CreateRExpenseChargeCommandResponse>.ErrorResult(
                    new ErrorDetails(400, "EndDate is required for recurrent charges"));

            if (command.StartDate >= command.EndDate)
                return OperationResult<CreateRExpenseChargeCommandResponse>.ErrorResult(
                    new ErrorDetails(400, "StartDate must be before EndDate"));
        }
        else
        {
            if (command.MatchTags == null || !command.MatchTags.Any())
                return OperationResult<CreateRExpenseChargeCommandResponse>.ErrorResult(
                    new ErrorDetails(400, "At least one MatchTag is required for non-recurrent charges"));
        }

        return OperationResult<CreateRExpenseChargeCommandResponse>.SuccessResult(new());
    }
}
