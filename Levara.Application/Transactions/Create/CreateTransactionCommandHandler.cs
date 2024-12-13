
using Levara.Domain.DAL;
using Levara.Domain.DAL.Repositories;
using Levara.Domain.Models;
using Levara.Shared.Domain.Bus.Commands;
using Levara.Shared.Results;

namespace Levara.Application.Transactions.Create;

public class CreateTransactionCommandHandler : ICommandHandler<CreateTransactionCommand, CreateTransactionCommandResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ITransactionRepository _transactionRepository;
    public CreateTransactionCommandHandler(IUnitOfWork unitOfWork,
        ITransactionRepository transactionRepository) 
    {
        _unitOfWork = unitOfWork;
        _transactionRepository = transactionRepository;
    }
    public async Task<OperationResult<CreateTransactionCommandResponse>> Handle(CreateTransactionCommand command)
    {
        Transaction transaction = new()
        {
            //OwnerId = command.OwnerId!.Value,
            //Price=command.Price!.Value,
            //RoomsQuantity=command.RoomsQuantity.Value,
            //BathroomQuantity = command.BathroomQuantity.Value,
            //AreaQuantity = command.AreaQuantity.Value,
            //HasPool = command.HasPool.Value,
            //HasBalcony = command.HasBalcony.Value,
            //HasGarage = command.HasGarage.Value,
            //DetailDepositAndAdittionalInfo = command.DetailDepositAndAdittionalInfo,
            //PetsPoliticAndRate = command.PetsPoliticAndRate,
            //TenantRequirements = command.TenantRequirements,
            //AvaliableFrom = command.AvaliableFromDate.Value.ToUniversalTime(),
            //Address = new()
            //{
            //    Street = command.Street!,
            //    Number = command.StreetNumber.GetValueOrDefault(),
            //    AdditionalLine = command.AdditionalLine,
            //    City = command.City!,
            //    State = command.State!,
            //    PostalCode = command.PostalCode!,
            //},
        };

        await _unitOfWork.ExecuteAsTransactionAsync(async () =>
        {
            int numberCurrentProperties = await _transactionRepository.CountAsync(p => p.EntityId == command.OwnerId);

            //property.Number = numberCurrentProperties;

            await _transactionRepository.AddAsync(transaction);

        });

        CreateTransactionCommandResponse response = new ()
        {
            Id = transaction.Id
        };

        return OperationResult<CreateTransactionCommandResponse>.SuccessResult(response);

    }
}
