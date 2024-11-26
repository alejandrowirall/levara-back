
using Levara.Application.Leases.GetForUpdate;
using Levara.Application.Leases.Update;
using Levara.Application.OwnersBankAccounts.GetForUpdate;
using Levara.Application.Plaid.GetPublicToken;
using Levara.Application.Plaid.GetTransactionsOwner;
using Levara.Domain.DAL;
using Levara.Domain.DAL.Repositories;
using Levara.Domain.Models;
using Levara.ExternalService.Plaid;
using Levara.Shared.Domain.Bus.Queries;
using Levara.Shared.Domain.Models;
using Levara.Shared.Results;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Text;

namespace Levara.Application.Plaid.GetTransactionsOwner;

public class GetTransactionsOwnerQueryHandler : IQueryHandler<GetTransactionsOwnerQuery, GetTransactionsOwnerQueryResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly HttpClient _httpClient;
    private readonly string _apikey;
    private readonly string _secret;
    private readonly IOwnerBankAccountRepository _ownerBankAccountRepository;

    public GetTransactionsOwnerQueryHandler(IUnitOfWork unitOfWork, IOptions<RemoteServicesConfig> config, IOwnerBankAccountRepository ownerBankAccountRepository) 
    {
        _unitOfWork = unitOfWork;
        _httpClient = new HttpClient();
        _httpClient.BaseAddress = new Uri(config.Value.BaseAdressUrl);
        _apikey = config.Value.ApiKey;
        _secret = config.Value.Secret;
        _ownerBankAccountRepository = ownerBankAccountRepository;

    }
    public async Task<OperationResult<GetTransactionsOwnerQueryResponse>> Handle(GetTransactionsOwnerQuery query)
    {
        var bankAccountQuery = _ownerBankAccountRepository.GetAll()
                                               .Where(p => p.OwnerId == query.ownerId);

        OwnerBankAccount account_Token = await _ownerBankAccountRepository.FirstOrDefaultAsync<OwnerBankAccount>(bankAccountQuery);
        var startDate = DateTime.UtcNow.AddDays(-1).ToString("yyyy-MM-dd"); // Ayer
        var endDate = DateTime.UtcNow.ToString("yyyy-MM-dd");             // Hoy
        const int maxCount = 500; // Máximo permitido
        int offset = 0;           // Inicia desde 0

        var allTransactions = new List<ExternalService.Plaid.Added>();


        if (account_Token == null)
            throw new Exception($"The owner doesn´t have an account or not exist"); 


        var url= _httpClient.BaseAddress+ $"transactions/sync";
        while (true)
        {
            var payload = new
            {
                client_id = _apikey,
                secret = _secret,
                access_token = account_Token.PlaidAccountId,
                count=500,
                cursor= ""
            };

            try
            {
                var jsonPayload = JsonConvert.SerializeObject(payload);
                Console.WriteLine($"Payload for offset {offset}:");
                Console.WriteLine(jsonPayload);

                var content = new StringContent(jsonPayload, Encoding.UTF8, "application/json");
                var response = await _httpClient.PostAsync(url, content);

                if (response.IsSuccessStatusCode)
                {
                    var resultContent = await response.Content.ReadAsStringAsync();
                    // var result = JObject.Parse(resultContent);
                    var settings = new JsonSerializerSettings
                    {
                        NullValueHandling = NullValueHandling.Include, // Incluye valores nulos
                        DefaultValueHandling = DefaultValueHandling.Include // Incluye valores predeterminados
                    };

                    var result = JsonConvert.DeserializeObject<PlaidTransactions>(resultContent, settings);
                    allTransactions.AddRange(result.Added);

                    // Incrementa el offset para la siguiente iteración
                    offset += maxCount;

                    // Agrega transacciones a la lista
                    //var transactions = result["transactions"]?.ToObject<List<JObject>>();
                    if (result.HasMore == null || !result.HasMore)
                        break; // Sale del bucle si no hay más transacciones

                    
                }
                else
                {
                    var errorContent = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Request failed with status {response.StatusCode}: {errorContent}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                throw new Exception($"An error occurred while fetching transactions: {ex.Message}", ex);
            }
        }

        var responseFunction = new GetTransactionsOwnerQueryResponse(allTransactions.Count);
       
        return OperationResult<GetTransactionsOwnerQueryResponse>.SuccessResult(responseFunction);


    }
}


