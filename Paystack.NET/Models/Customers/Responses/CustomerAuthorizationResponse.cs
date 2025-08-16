using Newtonsoft.Json;

namespace Paystack.NET.Models.Customers.Responses
{
    public class CustomerAuthorizationResponse
    {
        /// <summary>
        /// The authorization code generated for the customer.
        /// </summary>
        [JsonProperty("authorization_code")]
        public string AuthorizationCode { get; set; } = string.Empty;

        /// <summary>
        /// The payment channel (e.g., direct_debit).
        /// </summary>
        [JsonProperty("channel")]
        public string Channel { get; set; } = string.Empty;

        /// <summary>
        /// The bank associated with the authorization.
        /// </summary>
        [JsonProperty("bank")]
        public string Bank { get; set; } = string.Empty;

        /// <summary>
        /// Indicates whether this authorization is active.
        /// </summary>
        [JsonProperty("active")]
        public bool Active { get; set; }

        /// <summary>
        /// The customer details associated with this authorization.
        /// </summary>
        [JsonProperty("customer")]
        public CustomerInfo Customer { get; set; } = new CustomerInfo();
    }

    public class CustomerInfo
    {
        /// <summary>
        /// The Paystack-generated customer code.
        /// </summary>
        [JsonProperty("code")]
        public string Code { get; set; } = string.Empty;

        /// <summary>
        /// The customer's email address.
        /// </summary>
        [JsonProperty("email")]
        public string Email { get; set; } = string.Empty;
    }
}