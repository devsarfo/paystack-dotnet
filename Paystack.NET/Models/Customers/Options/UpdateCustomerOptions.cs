using System.Collections.Generic;
using Newtonsoft.Json;

namespace Paystack.NET.Models.Customers.Options
{
    public class UpdateCustomerOptions
    {
        /// <summary>
        /// The customer's first name.
        /// </summary>
        [JsonProperty("first_name")]
        public string FirstName { get; set; } = string.Empty;

        /// <summary>
        /// The customer's last name.
        /// </summary>
        [JsonProperty("last_name")]
        public string LastName { get; set; } = string.Empty;

        /// <summary>
        /// The customer's phone number.
        /// </summary>
        [JsonProperty("phone")]
        public string? Phone { get; set; }

        /// <summary>
        /// An optional collection of additional metadata to store with the customer.
        /// </summary>
        [JsonProperty("metadata")]
        public Dictionary<string, object>? Metadata { get; set; }
    }
}