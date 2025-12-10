using Levara.Application.Owners.GetForCreate;
using Levara.Shared.Domain.Bus.Queries;
using System.ComponentModel.DataAnnotations;

namespace Levara.Application.Plaid.GetLinkToken
{
    public class GetLinkTokenQuery : Query<GetLinkTokenQueryResponse>
    {
        [Range(1, int.MaxValue)]
        public int? OwnerId { get; set; }

        public string? Webhook { get; set; }

        public string? AccessToken { get; set; }


        public string? LinkCustomizationName { get; set; }
    }
    
}

