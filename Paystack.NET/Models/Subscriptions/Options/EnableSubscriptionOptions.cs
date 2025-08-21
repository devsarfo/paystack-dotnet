using Newtonsoft.Json;

namespace Paystack.NET.Models.Subscriptions.Options
{
    /// <summary>
    /// Represents the request body for enabling a subscription.
    /// </summary>
    public class EnableSubscriptionOptions
    {
        /// <summary>
        /// The unique subscription code assigned by Paystack.
        /// </summary>
        [JsonProperty("code")]
        public string Code { get; set; } = string.Empty;

        /// <summary>
        /// Email token used for managing the subscription.
        /// </summary>
        [JsonProperty("token")]
        public string Token { get; set; } = string.Empty;

    }
}