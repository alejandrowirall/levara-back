using Levara.Domain.Contexts;
using Levara.Domain.DAL;
using Levara.Domain.DAL.Repositories;
using Levara.Domain.Models;
using Levara.Shared.Domain.Bus.Commands;
using Levara.Shared.Results;

namespace Levara.Application.Transactions.Update;

public class UpdateTransactionCommandHandler : ICommandHandler<UpdateTransactionCommand, UpdateTransactionCommandResponse>
{
    private readonly IUserContext _userContext;
    private readonly IUnitOfWork _unitOfWork;
    private readonly ITransactionRepository _transactionRepository;
    public UpdateTransactionCommandHandler(IUserContext userContext,
        IUnitOfWork unitOfWork,
        ITransactionRepository transactionRepository) 
    {
        _userContext = userContext;
        _unitOfWork = unitOfWork;
        _transactionRepository = transactionRepository;
    }
    public async Task<OperationResult<UpdateTransactionCommandResponse>> Handle(UpdateTransactionCommand command)
    {
        var transactionQuery = _transactionRepository.GetAll()
                                               .Where(p => p.Id == command.Id!.Value);

        Transaction? transaction = await _transactionRepository.FirstOrDefaultAsync(transactionQuery);
        if (transaction == null)
            return OperationResult<UpdateTransactionCommandResponse>.ErrorResult(new ErrorDetails(404, "Not found"));

        if (_userContext.IsOwner && transaction.EntityId != _userContext.OwnerId!.Value)
            return OperationResult<UpdateTransactionCommandResponse>.ErrorResult(new ErrorDetails(403, "The owner does not have permissions to update this property."));

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
            _transactionRepository.Update(transaction);
            return Task.CompletedTask;
        });

        var response = new UpdateTransactionCommandResponse
        {
            Id = transaction.Id
        };

        return OperationResult<UpdateTransactionCommandResponse>.SuccessResult(response);

    }
}
