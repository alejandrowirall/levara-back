using Levara.Domain.Contexts;
using Levara.Domain.DAL;
using Levara.Domain.DAL.Repositories;
using Levara.Domain.Models;
using Levara.Shared.Domain.Bus.Commands;
using Levara.Shared.Results;

namespace Levara.Application.Expenses.Update;

public class UpdateExpenseCommandHandler : ICommandHandler<UpdateExpenseCommand, UpdateExpenseCommandResponse>
{
    private readonly IUserContext _userContext;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IExpenseRepository _expenseRepository;
    public UpdateExpenseCommandHandler(IUserContext userContext,
        IUnitOfWork unitOfWork,
        IExpenseRepository expenseRepository) 
    {
        _userContext = userContext;
        _unitOfWork = unitOfWork;
        _expenseRepository = expenseRepository;
    }
    public async Task<OperationResult<UpdateExpenseCommandResponse>> Handle(UpdateExpenseCommand command)
    {
        var expenseQuery = _expenseRepository.GetAll()
                                               .Where(p => p.Id == command.Id!.Value);

        Expense? expense = await _expenseRepository.FirstOrDefaultAsync(expenseQuery);
        if (expense == null)
            return OperationResult<UpdateExpenseCommandResponse>.ErrorResult(new ErrorDetails(404, "Not found"));

        if (_userContext.IsOwner && expense.Property.OwnerId != _userContext.OwnerId!.Value)
            return OperationResult<UpdateExpenseCommandResponse>.ErrorResult(new ErrorDetails(403, "The owner does not have permissions to update this expense."));

        //property.Address.Street = command.Street!;
        //property.Address.Number = command.StreetNumber!.Value;
        //property.Address.AdditionalLine = command.AdditionalLine;
        //property.Address.City = command.City!;
        //property.Address.State = command.State!;
        //property.Address.PostalCode = command.PostalCode!;
        //property.Price = command.Price!;
        //property.RoomsQuantity = command.RoomsQuantity.Value;
        //property.BathroomQuantity = command.BathroomQuantity.Value;
        //property.AreaQuantity = command.AreaQuantity.Value;
        //property.HasPool = command.HasPool.Value;
        //property.HasBalcony = command.HasBalcony.Value;
        //property.HasGarage = command.HasGarage.Value;
        //property.DetailDepositAndAdittionalInfo = command.DetailDepositAndAdittionalInfo;
        //property.PetsPoliticAndRate = command.PetsPoliticAndRate;
        //property.TenantRequirements = command.TenantRequirements;
        //property.AvaliableFrom = command.AvaliableFromDate.Value.ToUniversalTime();
        await _unitOfWork.ExecuteAsTransactionAsync(() =>
        {
            _expenseRepository.Update(expense);
            return Task.CompletedTask;
        });

        var response = new UpdateExpenseCommandResponse
        {
            Id = expense.Id
        };

        return OperationResult<UpdateExpenseCommandResponse>.SuccessResult(response);

    }
}
