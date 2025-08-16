using Newtonsoft.Json;

namespace Paystack.NET.Models.Transactions.Options
{
    /// <summary>
    /// Represents the options for charging an authorization in Paystack.
    /// </summary>
    public class ChargeAuthorizationOptions
    {
        /// <summary>
        /// The amount to be charged, in the subunit of the supported currency.
        /// Example: 5000 for 50.00 in GHS (Ghana Cedi).
        /// </summary>
        [JsonProperty("amount")]
        public string Amount { get; set; } = string.Empty;

        /// <summary>
        /// The email address of the customer to be charged.
        /// </summary>
        [JsonProperty("email")]
        public string Email { get; set; } = string.Empty;

        /// <summary>
        /// A valid authorization code to charge the customer.
        /// This must have been previously obtained from a successful transaction.
        /// </summary>
        [JsonProperty("authorization_code")]
        public string AuthorizationCode { get; set; } = string.Empty;
    }
}