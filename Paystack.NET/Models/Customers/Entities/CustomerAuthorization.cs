using System;
using Newtonsoft.Json;

namespace Paystack.NET.Models.Customers.Entities
{
    public class CustomerAuthorization
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("status")]
        public string? Status { get; set; }

        [JsonProperty("mandate_id")]
        public long MandateId { get; set; }

        [JsonProperty("authorization_id")]
        public long AuthorizationId { get; set; }

        [JsonProperty("authorization_code")]
        public string? AuthorizationCode { get; set; }

        [JsonProperty("integration_id")]
        public long IntegrationId { get; set; }

        [JsonProperty("account_number")]
        public string? AccountNumber { get; set; }

        [JsonProperty("bank_code")]
        public string? BankCode { get; set; }

        [JsonProperty("bank_name")]
        public string? BankName { get; set; }

        [JsonProperty("customer")]
        public CustomerInfo? Customer { get; set; }

        [JsonProperty("authorized_at")]
        public DateTime? AuthorizedAt { get; set; }
    }
    
    
}