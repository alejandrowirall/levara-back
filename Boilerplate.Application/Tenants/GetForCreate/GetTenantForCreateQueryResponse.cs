using Boilerplate.Shared.Domain.Models;

namespace Boilerplate.Application.Tenants.GetForCreate;

public class GetTenantForCreateQueryResponse
{
    public GetTenantForCreateQueryResponse(List<ListModel> personTypes,
        List<ListModel> identificationTypes)
    {
        PersonTypes = personTypes;
        IdentificationTypes = identificationTypes;
    }
    public List<ListModel> PersonTypes { get; }

    public List<ListModel> IdentificationTypes { get; }

}
