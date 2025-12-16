using Levara.Domain.DAL.Repositories;
using Levara.Domain.Enum;
using Levara.Shared.Domain.Bus.Queries;
using Levara.Shared.Domain.Models;
using Levara.Shared.Extensions;
using Levara.Shared.Results;

namespace Levara.Application.RecurringCharges.GetRExpenseChargeForUpdate;


public class GetRExpenseChargeForUpdateQueryHandler : IQueryHandler<GetRExpenseChargeForUpdateQuery, GetRExpenseChargeForUpdateQueryResponse>
{
    private readonly IPropertyRepository _propertyRepository;
    private readonly IExpenseRepository _expenseRepository;

    private readonly IRecurringChargeRepository _recurringChargeRepository;

    public GetRExpenseChargeForUpdateQueryHandler(IPropertyRepository propertyRepository,
        IExpenseRepository expenseRepository,
        IRecurringChargeRepository recurringChargeRepository)
    {
        _propertyRepository = propertyRepository;
        _expenseRepository = expenseRepository;
        _recurringChargeRepository = recurringChargeRepository;
    }
    public async Task<OperationResult<GetRExpenseChargeForUpdateQueryResponse>> Handle(GetRExpenseChargeForUpdateQuery query)
    {
        var recurringCharge = await _recurringChargeRepository.GetByIdAsync(query.Id!.Value);
        if (recurringCharge == null || !recurringCharge.ExpenseId.HasValue)
            return OperationResult<GetRExpenseChargeForUpdateQueryResponse>.ErrorResult(
                new ErrorDetails(404, $"RecurringCharge with id {query.Id} not found "));


        var propertyQuery = _propertyRepository.GetAllWithAddress()
                                            .Where(l => l.Id == recurringCharge.PropertyId);

        var property = await _propertyRepository.FirstOrDefaultAsync(propertyQuery);
        if (property == null)
            return OperationResult<GetRExpenseChargeForUpdateQueryResponse>.ErrorResult(
                new ErrorDetails(404, $"Property with id {recurringCharge.PropertyId} not found"));

        var expenseQuery = _expenseRepository.GetAll()
                                             .Select(e => new ListModel { Id = e.Id, Text = e.Name });

        var expenses = await _expenseRepository.ToListAsync(expenseQuery);


        GetRExpenseChargeForUpdateQueryResponse response = new(recurringCharge,
                                                             property,
                                                             EnumExtensions.ToListModel<FrequencyType>(),
                                                             expenses);

        return OperationResult<GetRExpenseChargeForUpdateQueryResponse>.SuccessResult(response);
    }
}
