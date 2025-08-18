using Newtonsoft.Json;

namespace Paystack.NET.Models.Customers.Entities
{
    public class CustomerInfo
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("customer_code")]
        public string? CustomerCode { get; set; }

        [JsonProperty("email")]
        public string? Email { get; set; }

        [JsonProperty("first_name")]
        public string? FirstName { get; set; }

        [JsonProperty("last_name")]
        public string? LastName { get; set; }
    }
}