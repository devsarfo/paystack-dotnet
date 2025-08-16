using Newtonsoft.Json;
using Paystack.NET.Constants;
using Paystack.NET.Models.Customers.Shared;

namespace Paystack.NET.Models.Customers.Options
{
    /// <summary>
    /// Options to initialize a reusable authorization code for a customer.
    /// </summary>
    public class InitializeAuthorizationOptions
    {
        /// <summary>
        /// The customer's email address.
        /// </summary>
        [JsonProperty("email")]
        public string Email { get; set; } = string.Empty;

        /// <summary>
        /// The payment channel. Currently, only "direct_debit" is supported.
        /// </summary>
        [JsonProperty("channel")]
        public string Channel { get; set; } = AuthorizationChannel.DirectDebit;

        /// <summary>
        /// Fully qualified URL to redirect the customer after authorization (optional).
        /// </summary>
        [JsonProperty("callback_url", NullValueHandling = NullValueHandling.Ignore)]
        public string? CallbackUrl { get; set; }

        /// <summary>
        /// The customer's account details (optional).
        /// </summary>
        [JsonProperty("account", NullValueHandling = NullValueHandling.Ignore)]

        public AccountDetails? Account { get; set; }

        /// <summary>
        /// The customer's address details (optional).
        /// </summary>
        [JsonProperty("address", NullValueHandling = NullValueHandling.Ignore)]
        public AddressDetails? Address { get; set; }
    }
}