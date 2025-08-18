using Newtonsoft.Json;

namespace Paystack.NET.Models.Customers.Shared
{
    /// <summary>
    /// Represents the customer's bank account details.
    /// </summary>
    public class AccountDetails
    {
        /// <summary>
        /// The customer's bank account number.
        /// </summary>
        [JsonProperty("number")]
        public string Number { get; set; } = string.Empty;

        /// <summary>
        /// The bank code of the customer's bank.
        /// </summary>
        [JsonProperty("bank_code")]
        public string BankCode { get; set; } = string.Empty;
    }
}