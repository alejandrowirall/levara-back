
using Levara.Domain.DAL;
using Levara.Domain.DAL.Repositories;
using Levara.Domain.Models;
using Levara.Shared.Domain.Bus.Queries;
using Levara.Shared.Domain.Models;
using Levara.Shared.Results;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Text;

namespace Levara.Application.Plaid.GetLinkToken;

public class GetLinkTokenQueryHandler : IQueryHandler<GetLinkTokenQuery, GetLinkTokenQueryResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly HttpClient _httpClient;
    private readonly string _apikey;
    private readonly string _secret;

    public GetLinkTokenQueryHandler(IUnitOfWork unitOfWork, IOptions<RemoteServicesConfig> config) 
    {
        _unitOfWork = unitOfWork;
        _httpClient = new HttpClient();
        _httpClient.BaseAddress = new Uri(config.Value.BaseAdressUrl);
        _apikey = config.Value.ApiKey;
        _secret = config.Value.Secret;

    }
    public async Task<OperationResult<GetLinkTokenQueryResponse>> Handle(GetLinkTokenQuery query)
    {

        var url= _httpClient.BaseAddress+ $"link/token/create";
        var payload = new
        {
            client_id = _apikey,
            secret = _secret,
            client_name = query.ClientName,
            country_codes = new[] { "US" },
            language = "en",
            user = new
            {
                client_user_id =query.ClientId
            },
            products = new[] { "auth", "transactions" }
        };
        try
        {
            var jsonPayload = JsonConvert.SerializeObject(payload);
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


