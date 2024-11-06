using Levara.Shared.Domain.Models;

namespace Levara.Application.Owners.GetForCreate;

public class GetOwnerForCreateQueryResponse
{
    public GetOwnerForCreateQueryResponse(List<ListModel> personTypes,
        List<ListModel> identificationTypes)
    {
        PersonTypes = personTypes;
        IdentificationTypes = identificationTypes;
    }
    public List<ListModel> PersonTypes { get; }

    public List<ListModel> IdentificationTypes { get; }

}
