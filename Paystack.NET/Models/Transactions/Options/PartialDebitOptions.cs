
using Newtonsoft.Json;

namespace Paystack.NET.Models.Transactions.Options
{
    public class PartialDebitOptions
    {
        /// <summary>
        /// The authorization code for the transaction.
        /// </summary>
        [JsonProperty("authorization_code")]
        public string AuthorizationCode { get; set; } = string.Empty;

        /// <summary>
        /// The currency of the transaction. Defaults to integration's currency.
        /// You can default to "GHS" for Ghana Cedis or allow other currencies.
        /// </summary>
        [JsonProperty("currency")]
        public string Currency { get; set; } = string.Empty;

        /// <summary>
        /// The amount to be charged, in the subunit of the supported currency.
        /// Example: 5000 for 50.00 in GHS (Ghana Cedi).
        /// </summary>
        [JsonProperty("amount")]
        public string Amount { get; set; } = string.Empty;

        /// <summary>
        /// The email address of the customer attached to the authorization code.
        /// </summary>
        [JsonProperty("email")]
        public string Email { get; set; } = string.Empty;

        /// <summary>
        /// A unique transaction reference. Only -, ., = and alphanumeric characters allowed.
        /// </summary>
        [JsonProperty("reference")]
        public string Reference { get; set; } = string.Empty;

        /// <summary>
        /// The minimum amount that should be debited (optional).
        /// </summary>
        [JsonProperty("at_least")]
        public string? AtLeast { get; set; }
    }
}