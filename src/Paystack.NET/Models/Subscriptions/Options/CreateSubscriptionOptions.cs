using Newtonsoft.Json;

namespace Paystack.NET.Models.Subscriptions.Options
{
    /// <summary>
    /// Represents the request body for creating a subscription.
    /// </summary>
    public class CreateSubscriptionOptions
    {
        /// <summary>
        /// The customer's email address or code.
        /// </summary>
        [JsonProperty("customer")]
        public string Customer { get; set; } = string.Empty;

        /// <summary>
        /// The plan code the customer is subscribing to.
        /// </summary>
        [JsonProperty("plan")]
        public string Plan { get; set; } = string.Empty;

        /// <summary>
        /// (Optional) If the customer has multiple authorizations, 
        /// specify the authorization code to use for this subscription.
        /// If not provided, the most recent authorization will be used.
        /// </summary>
        [JsonProperty("authorization", NullValueHandling = NullValueHandling.Ignore)]
        public string? Authorization { get; set; }

        /// <summary>
        /// (Optional) Set the date for the first debit. 
        /// Must be in ISO 8601 format (e.g., 2017-05-16T00:30:13+01:00).
        /// </summary>
        [JsonProperty("start_date", NullValueHandling = NullValueHandling.Ignore)]
        public string? StartDate { get; set; }
    }
}