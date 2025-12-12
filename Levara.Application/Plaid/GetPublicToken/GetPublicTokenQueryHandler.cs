
using Levara.Application.Plaid.GetLinkToken;
using Levara.Domain.DAL;
using Levara.Domain.DAL.Repositories;
using Levara.Domain.Models;
using Levara.Shared.Domain.Bus.Queries;
using Levara.Shared.Domain.Models;
using Levara.Shared.Results;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Text;

namespace Levara.Application.Plaid.GetPublicToken;

public class GetPublicTokenQueryHandler : IQueryHandler<GetPublicTokenQuery, GetPublicTokenQueryResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly HttpClient _httpClient;
    private readonly string _apikey;
    private readonly string _secret;
    private readonly ILogger<GetPublicTokenQueryHandler> _logger;

    public GetPublicTokenQueryHandler(IUnitOfWork unitOfWork, IOptions<RemoteServicesConfig> config, ILogger<GetPublicTokenQueryHandler> logger) 
    {
        _unitOfWork = unitOfWork;
        _httpClient = new HttpClient();
        _httpClient.BaseAddress = new Uri(config.Value.BaseAdressUrl);
        _apikey = config.Value.ApiKey;
        _secret = config.Value.Secret;
        _logger = logger;

    }
    public async Task<OperationResult<GetPublicTokenQueryResponse>> Handle(GetPublicTokenQuery query)
    {

        var url= _httpClient.BaseAddress+ $"item/public_token/exchange";
        var payload = new
        {
            client_id = _apikey,
            secret = _secret,
            public_token = query.Public_token
        };
        try
        {
            var jsonPayload = JsonConvert.SerializeObject(payload);
            var content = new StringContent(jsonPayload, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync(url, content);
            var responseContent = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
            {
                var result = JsonConvert.DeserializeObject<GetPublicTokenQueryResponse>(responseContent);
                _logger.LogError("PLAID PUBLIC Token:" + result);
                return OperationResult<GetPublicTokenQueryResponse>.SuccessResult(result);
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


