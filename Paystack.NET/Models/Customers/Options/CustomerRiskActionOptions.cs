using Newtonsoft.Json;

namespace Paystack.NET.Models.Customers.Options
{
    public class CustomerRiskActionOptions
    {
        /// <summary>
        /// The customer's code, or email address
        /// </summary>
        [JsonProperty("customer")]
        public string Customer { get; set; } = string.Empty;
        
        /// <summary>
        /// The customer's risk action.
        /// One of the possible risk actions [ default, allow, deny ]. Allow to whitelist. Deny to blacklist.
        /// Customers start with a default risk action.
        /// </summary>
        [JsonProperty("risk_action")]
        public string RiskAction { get; set; } = string.Empty;

    }
}