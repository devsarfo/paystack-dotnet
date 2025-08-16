using Newtonsoft.Json;

namespace Paystack.NET.Models.Customers.Options
{
    public class DeactivateAuthorizationOptions
    {
        /// <summary>
        /// The authorization code  to be deactivated
        /// </summary>
        [JsonProperty("authorization_code")]
        public string AuthorizationCode { get; set; } = string.Empty;
    }
}