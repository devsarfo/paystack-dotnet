using Newtonsoft.Json;
using Paystack.NET.Models.Customers.Shared;

namespace Paystack.NET.Models.Customers.Options
{
    /// <summary>
    /// Options to initialize a reusable authorization code for a customer.
    /// </summary>
    public class InitializeDirectDebitOptions
    {
        /// <summary>
        /// The customer's account details (optional).
        /// </summary>
        [JsonProperty("account")]
        public AccountDetails Account { get; set; } = new AccountDetails();

        /// <summary>
        /// The customer's address details (optional).
        /// </summary>
        [JsonProperty("address")]
        public AddressDetails Address { get; set; } = new AddressDetails();
    }
}