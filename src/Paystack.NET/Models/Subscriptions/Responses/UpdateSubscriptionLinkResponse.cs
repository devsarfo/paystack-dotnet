using Newtonsoft.Json;

namespace Paystack.NET.Models.Subscriptions.Responses
{
    /// <summary>
    /// Represents the response returned when retrieving an update subscription link from Paystack.
    /// </summary>
    public class UpdateSubscriptionLinkResponse
    {
        /// <summary>
        /// Returns the link to the Paystack subscription management page.
        /// </summary>
        [JsonProperty("link")]
        public string Link { get; set; } = string.Empty;
    }
}