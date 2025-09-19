using Newtonsoft.Json;

namespace Paystack.NET.Models.Customers.Shared
{
    /// <summary>
    /// Represents the customer's address details.
    /// </summary>
    public class AddressDetails
    {
        /// <summary>
        /// The customer's street.
        /// </summary>
        [JsonProperty("street")]
        public string? Street { get; set; }

        /// <summary>
        /// The customer's city.
        /// </summary>
        [JsonProperty("city")]
        public string? City { get; set; }

        /// <summary>
        /// The customer's state.
        /// </summary>
        [JsonProperty("state")]
        public string? State { get; set; }
    }
}