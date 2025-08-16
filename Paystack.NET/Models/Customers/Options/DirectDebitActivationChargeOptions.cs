using Newtonsoft.Json;

namespace Paystack.NET.Models.Customers.Options
{
    public class DirectDebitActivationChargeOptions
    {
        /// <summary>
        /// The authorization ID gotten from the initiation response
        /// </summary>
        [JsonProperty("authorization_id")]
        public string AuthorizationId { get; set; } = string.Empty;
    }
}