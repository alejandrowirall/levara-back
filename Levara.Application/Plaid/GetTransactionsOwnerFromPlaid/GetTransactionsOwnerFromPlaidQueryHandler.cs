
using Levara.Application.Leases.GetForUpdate;
using Levara.Application.Leases.Update;
using Levara.Application.OwnersBankAccounts.GetForUpdate;
using Levara.Application.Plaid.GetPublicToken;
using Levara.Application.Plaid.GetTransactionsOwnerFromPlaid;
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
using System.Transactions;

namespace Levara.Application.Plaid.GetTransactionsOwnerFromPlaid;

public class GetTransactionsOwnerFromPlaidQueryHandler : IQueryHandler<GetTransactionsOwnerFromPlaidQuery, GetTransactionsOwnerQueryFromPlaidResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly HttpClient _httpClient;
    private readonly string _apikey;
    private readonly string _secret;
    private readonly IOwnerBankAccountRepository _ownerBankAccountRepository;
    private readonly IPlaidRepository _plaidRepository;
    public GetTransactionsOwnerFromPlaidQueryHandler(IUnitOfWork unitOfWork, IOptions<RemoteServicesConfig> config, IOwnerBankAccountRepository ownerBankAccountRepository, IPlaidRepository plaidRepository) 
    {
        _unitOfWork = unitOfWork;
        _httpClient = new HttpClient();
        _httpClient.BaseAddress = new Uri(config.Value.BaseAdressUrl);
        _apikey = config.Value.ApiKey;
        _secret = config.Value.Secret;
        _ownerBankAccountRepository = ownerBankAccountRepository;
        _plaidRepository = plaidRepository;
    }
    public async Task<OperationResult<GetTransactionsOwnerQueryFromPlaidResponse>> Handle(GetTransactionsOwnerFromPlaidQuery query)
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
                cursor= account_Token.LastSyncId
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
                    account_Token.LastSyncId = result.NextCursor;
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
        var plaidTransactions = allTransactions.Select(transaction => new PlaidTransaction
        {
            TransactionId = transaction.TransactionId, // Asumiendo que existe un campo equivalente en ExternalService.Plaid.Added
            Date = DateTime.Parse(transaction.Date).ToUniversalTime(),                  // Mapea al campo de tipo DateTime
            Description = transaction.Name,    // Mapea la descripción
            Amount = transaction.Amount,              // Mapea el monto
            Status = Domain.Enum.PlaidTransactionStatus.NeedReview,    // Traduce el estado (requiere método adicional)
            OwnerBankAccountId= account_Token.Id
        }).ToList();

        //Verificar del listado de transacciones cuales no existen
        //el transaction if para avanzar en el proceso de creacion
        
        var plaidTransactionIds = plaidTransactions.Select(pt => pt.TransactionId).ToList();
        var existingTransactionIds = _plaidRepository.GetAll()
                               .Where(dbTransaction => plaidTransactionIds.Contains(dbTransaction.TransactionId))
                               .Select(dbTransaction => dbTransaction.TransactionId)
                               .ToList();
        var newTransactions = plaidTransactions
                        .Where(pt => !existingTransactionIds.Contains(pt.TransactionId))
                        .ToList();

        await _unitOfWork.ExecuteAsTransactionAsync(async () =>
        {
            foreach(var transaction in newTransactions)
            { 
                await _plaidRepository.AddAsync(transaction);

            }
        });
            
       
        _ownerBankAccountRepository.Update(account_Token);
        var responseFunction = new GetTransactionsOwnerQueryFromPlaidResponse(allTransactions.Count);
       
        return OperationResult<GetTransactionsOwnerQueryFromPlaidResponse>.SuccessResult(responseFunction);


    }
}


