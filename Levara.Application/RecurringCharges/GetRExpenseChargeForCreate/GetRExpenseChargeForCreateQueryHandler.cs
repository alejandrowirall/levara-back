using Levara.Domain.DAL.Repositories;
using Levara.Domain.Enum;
using Levara.Shared.Domain.Bus.Queries;
using Levara.Shared.Domain.Models;
using Levara.Shared.Extensions;
using Levara.Shared.Results;

namespace Levara.Application.RecurringCharges.GetRExpenseChargeForCreate;


public class GetExpenseChargeForCreateQueryHandler : IQueryHandler<GetRExpenseChargeForCreateQuery, GetRExpenseChargeForCreateQueryResponse>
{
    private readonly IPropertyRepository _propertyRepository;
    private readonly IExpenseRepository _expenseRepository;
    public GetExpenseChargeForCreateQueryHandler(IPropertyRepository propertyRepository,
        IExpenseRepository expenseRepository)
    {
        _propertyRepository = propertyRepository;
        _expenseRepository = expenseRepository;
    }
    public async Task<OperationResult<GetRExpenseChargeForCreateQueryResponse>> Handle(GetRExpenseChargeForCreateQuery query)
    {
        var propertyQuery = _propertyRepository.GetAllWithAddress()
                                               .Where(l => l.Id == query.PropertyId);

        var property = await _propertyRepository.FirstOrDefaultAsync(propertyQuery);
        if (property == null)
            return OperationResult<GetRExpenseChargeForCreateQueryResponse>.ErrorResult(
                new ErrorDetails(404, $"Property with id {query.PropertyId} not found"));

        var expenseQuery = _expenseRepository.GetAll()
                                             .Select(lct => new ListModel { Id = lct.Id, Text = lct.Name });

        var expenses = await _expenseRepository.ToListAsync(expenseQuery);


        GetRExpenseChargeForCreateQueryResponse response = new(property,
                                                             EnumExtensions.ToListModel<FrequencyType>(),
                                                             expenses);

        return OperationResult<GetRExpenseChargeForCreateQueryResponse>.SuccessResult(response);
    }
}
