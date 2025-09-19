using Newtonsoft.Json;
using Paystack.NET.Models.Shared.Options;

namespace Paystack.NET.Models.Subscriptions.Options
{
    /// <summary>
    /// Represents the query parameters for retrieving subscriptions from the Paystack API.
    /// </summary>
    public class ListSubscriptionsOptions: BasePaginationOptions
    {
        /// <summary>
        /// Filter list by customer
        /// </summary>
        [JsonProperty("customer")]
        public string Customer { get; set; } = string.Empty;

        /// <summary>
        /// Filter list by plan
        /// </summary>
        [JsonProperty("plan")]
        public string Plan { get; set; } = string.Empty;

    }
}