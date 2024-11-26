using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Levara.ExternalService.Plaid
{
    public class PlaidTransactions
    {
        [JsonProperty("accounts")]
        public List<Account> Accounts { get; set; }

        [JsonProperty("added")]
        public List<Added> Added { get; set; }

        [JsonProperty("modified")]
        public List<Modified> Modified { get; set; }

        [JsonProperty("removed")]
        public List<Removed> Removed { get; set; }

        [JsonProperty("next_cursor")]
        public string NextCursor { get; set; }

        [JsonProperty("has_more")]
        public bool HasMore { get; set; }

        [JsonProperty("request_id")]
        public string RequestId { get; set; }

        [JsonProperty("transactions_update_status")]
        public string TransactionsUpdateStatus { get; set; }
    }
    public class Account
    {
        [JsonProperty("account_id")]
        public string AccountId { get; set; }

        [JsonProperty("balances")]
        public Balances Balances { get; set; }

        [JsonProperty("mask")]
        public string Mask { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("official_name")]
        public string OfficialName { get; set; }

        [JsonProperty("subtype")]
        public string Subtype { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }
    }

    public class Added
    {
        [JsonProperty("account_id")]
        public string AccountId { get; set; }

        [JsonProperty("account_owner")]
        public object AccountOwner { get; set; }

        [JsonProperty("amount")]
        public double? Amount { get; set; }

        [JsonProperty("iso_currency_code")]
        public string IsoCurrencyCode { get; set; }

        [JsonProperty("unofficial_currency_code")]
        public object UnofficialCurrencyCode { get; set; }

        [JsonProperty("category")]
        public List<string> Category { get; set; }

        [JsonProperty("category_id")]
        public string CategoryId { get; set; }

        [JsonProperty("check_number")]
        public object CheckNumber { get; set; }

        [JsonProperty("counterparties")]
        public List<Counterparty> Counterparties { get; set; }

        [JsonProperty("date")]
        public string Date { get; set; }

        [JsonProperty("datetime")]
        public DateTime? Datetime { get; set; }

        [JsonProperty("authorized_date")]
        public string AuthorizedDate { get; set; }

        [JsonProperty("authorized_datetime")]
        public DateTime? AuthorizedDatetime { get; set; }

        [JsonProperty("location")]
        public Location Location { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("merchant_name")]
        public string MerchantName { get; set; }

        [JsonProperty("merchant_entity_id")]
        public string MerchantEntityId { get; set; }

        [JsonProperty("logo_url")]
        public string LogoUrl { get; set; }

        [JsonProperty("website")]
        public string Website { get; set; }

        [JsonProperty("payment_meta")]
        public PaymentMeta PaymentMeta { get; set; }

        [JsonProperty("payment_channel")]
        public string PaymentChannel { get; set; }

        [JsonProperty("pending")]
        public bool Pending { get; set; }

        [JsonProperty("pending_transaction_id")]
        public string PendingTransactionId { get; set; }

        [JsonProperty("personal_finance_category")]
        public PersonalFinanceCategory PersonalFinanceCategory { get; set; }

        [JsonProperty("personal_finance_category_icon_url")]
        public string PersonalFinanceCategoryIconUrl { get; set; }

        [JsonProperty("transaction_id")]
        public string TransactionId { get; set; }

        [JsonProperty("transaction_code")]
        public object TransactionCode { get; set; }

        [JsonProperty("transaction_type")]
        public string TransactionType { get; set; }
    }

    public class Balances
    {
        [JsonProperty("available")]
        public double? Available { get; set; }

        [JsonProperty("current")]
        public double? Current { get; set; }

        [JsonProperty("iso_currency_code")]
        public string IsoCurrencyCode { get; set; }

        [JsonProperty("limit")]
        public object Limit { get; set; }

        [JsonProperty("unofficial_currency_code")]
        public object UnofficialCurrencyCode { get; set; }
    }

    public class Counterparty
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("logo_url")]
        public string LogoUrl { get; set; }

        [JsonProperty("website")]
        public string Website { get; set; }

        [JsonProperty("entity_id")]
        public string EntityId { get; set; }

        [JsonProperty("confidence_level")]
        public string ConfidenceLevel { get; set; }
    }

    public class Location
    {
        [JsonProperty("address")]
        public string Address { get; set; }

        [JsonProperty("city")]
        public string City { get; set; }

        [JsonProperty("region")]
        public string Region { get; set; }

        [JsonProperty("postal_code")]
        public string PostalCode { get; set; }

        [JsonProperty("country")]
        public string Country { get; set; }

        [JsonProperty("lat")]
        public double? Lat { get; set; }

        [JsonProperty("lon")]
        public double? Lon { get; set; }

        [JsonProperty("store_number")]
        public string StoreNumber { get; set; }
    }

    public class Modified
    {
        [JsonProperty("account_id")]
        public string AccountId { get; set; }

        [JsonProperty("account_owner")]
        public object AccountOwner { get; set; }

        [JsonProperty("amount")]
        public double? Amount { get; set; }

        [JsonProperty("iso_currency_code")]
        public string IsoCurrencyCode { get; set; }

        [JsonProperty("unofficial_currency_code")]
        public object UnofficialCurrencyCode { get; set; }

        [JsonProperty("category")]
        public List<string> Category { get; set; }

        [JsonProperty("category_id")]
        public string CategoryId { get; set; }

        [JsonProperty("check_number")]
        public object CheckNumber { get; set; }

        [JsonProperty("counterparties")]
        public List<Counterparty> Counterparties { get; set; }

        [JsonProperty("date")]
        public string Date { get; set; }

        [JsonProperty("datetime")]
        public DateTime? Datetime { get; set; }

        [JsonProperty("authorized_date")]
        public string AuthorizedDate { get; set; }

        [JsonProperty("authorized_datetime")]
        public DateTime? AuthorizedDatetime { get; set; }

        [JsonProperty("location")]
        public Location Location { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("merchant_name")]
        public string MerchantName { get; set; }

        [JsonProperty("merchant_entity_id")]
        public string MerchantEntityId { get; set; }

        [JsonProperty("logo_url")]
        public string LogoUrl { get; set; }

        [JsonProperty("website")]
        public string Website { get; set; }

        [JsonProperty("payment_meta")]
        public PaymentMeta PaymentMeta { get; set; }

        [JsonProperty("payment_channel")]
        public string PaymentChannel { get; set; }

        [JsonProperty("pending")]
        public bool Pending { get; set; }

        [JsonProperty("pending_transaction_id")]
        public object PendingTransactionId { get; set; }

        [JsonProperty("personal_finance_category")]
        public PersonalFinanceCategory PersonalFinanceCategory { get; set; }

        [JsonProperty("personal_finance_category_icon_url")]
        public string PersonalFinanceCategoryIconUrl { get; set; }

        [JsonProperty("transaction_id")]
        public string TransactionId { get; set; }

        [JsonProperty("transaction_code")]
        public object TransactionCode { get; set; }

        [JsonProperty("transaction_type")]
        public string TransactionType { get; set; }
    }

    public class PaymentMeta
    {
        [JsonProperty("by_order_of")]
        public object ByOrderOf { get; set; }

        [JsonProperty("payee")]
        public object Payee { get; set; }

        [JsonProperty("payer")]
        public object Payer { get; set; }

        [JsonProperty("payment_method")]
        public object PaymentMethod { get; set; }

        [JsonProperty("payment_processor")]
        public object PaymentProcessor { get; set; }

        [JsonProperty("ppd_id")]
        public object PpdId { get; set; }

        [JsonProperty("reason")]
        public object Reason { get; set; }

        [JsonProperty("reference_number")]
        public object ReferenceNumber { get; set; }
    }

    public class PersonalFinanceCategory
    {
        [JsonProperty("primary")]
        public string Primary { get; set; }

        [JsonProperty("detailed")]
        public string Detailed { get; set; }

        [JsonProperty("confidence_level")]
        public string ConfidenceLevel { get; set; }
    }

    public class Removed
    {
        [JsonProperty("account_id")]
        public string AccountId { get; set; }

        [JsonProperty("transaction_id")]
        public string TransactionId { get; set; }
    }

   






}
