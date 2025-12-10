using Levara.Domain.DAL.Repositories;
using Levara.Shared.Domain.Bus.Queries;
using Levara.Shared.Domain.Models;
using Levara.Shared.Results;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Text;

namespace Levara.Application.Plaid.GetLinkToken;

public class GetLinkTokenQueryHandler : IQueryHandler<GetLinkTokenQuery, GetLinkTokenQueryResponse>
{
    private readonly IOwnerRepository _ownerRepository;
    private readonly HttpClient _httpClient;
    private readonly string _apikey;
    private readonly string _secret;
    private readonly string _redirect_url;
    private readonly string _webhook;

    public GetLinkTokenQueryHandler(IOwnerRepository ownerRepository,
        IOptions<RemoteServicesConfig> config)
    {
        _ownerRepository = ownerRepository;
        _httpClient = new HttpClient();
        _httpClient.BaseAddress = new Uri(config.Value.BaseAdressUrl);
        _httpClient.DefaultRequestHeaders.Add("Plaid-Version", "2020-09-14");
        _apikey = config.Value.ApiKey;
        _secret = config.Value.Secret;
        _redirect_url = config.Value.Redirect_URL;
        _webhook = config.Value.Webhook;

    }
    public async Task<OperationResult<GetLinkTokenQueryResponse>> Handle(GetLinkTokenQuery query)
    {
        var owner = await _ownerRepository.FirstOrDefaultAsync(o => o.Id == query.OwnerId!.Value);
        if (owner == null)
            return OperationResult<GetLinkTokenQueryResponse>.ErrorResult(new ErrorDetails(404, $"Owner with id {query.OwnerId!.Value} not found"));


        var url = _httpClient.BaseAddress + $"link/token/create";
        
        // Build the payload dynamically based on available query parameters
        var payload = new
        {
            client_id = _apikey,
            secret = _secret,
            client_name = owner.Email,
            country_codes = new[] { "US" },
            language = "en",
            user = new
            {
                client_user_id = owner.Id.ToString()
            },
            products = new[] { "auth", "transactions" },
            webhook = _webhook,
            access_token = query.AccessToken,
            link_customization_name = query.LinkCustomizationName,
            redirect_uri = _redirect_url,
            update = new
            {
                account_selection_enabled = true
            }
        };

        try
        {
            var jsonPayload = JsonConvert.SerializeObject(payload, new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore
            });
            var content = new StringContent(jsonPayload, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync(url, content);
            var responseContent = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
            {
                var result = JsonConvert.DeserializeObject<GetLinkTokenQueryResponse>(responseContent);
                return OperationResult<GetLinkTokenQueryResponse>.SuccessResult(result);
            }
            var errorContent = await response.Content.ReadAsStringAsync();

            throw new Exception($"Request failed with status {response.StatusCode}: {errorContent}");
        }
        catch (Exception ex)
        {
            // Manejo de errores adicional si es necesario
            throw new Exception($"An error occurred while creating the link token: {ex.Message}", ex);
        }

    }
}


