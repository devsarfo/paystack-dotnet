using Newtonsoft.Json;
using Paystack.NET.Constants;

namespace Paystack.NET.Models.Customers.Options
{
    public class ValidateCustomerOptions
    {
        /// <summary>
        /// The customer's first name.
        /// </summary>
        [JsonProperty("first_name")]
        public string FirstName { get; set; } = string.Empty;

        /// <summary>
        /// The customer's last name.
        /// </summary>
        [JsonProperty("middle_name")]
        public string? MiddleName { get; set; }

        /// <summary>
        /// The customer's last name.
        /// </summary>
        [JsonProperty("last_name")]
        public string LastName { get; set; } = string.Empty;

        /// <summary>
        /// Predefined types of identification. Only bank_account is supported at the moment
        /// </summary>
        [JsonProperty("type")]
        public string Type { get; set; } = IdentificationType.BankAccount;

        /// <summary>
        /// The customer's identification number
        /// </summary>
        [JsonProperty("value")]
        public string Value { get; set; } = string.Empty;

        /// <summary>
        /// The 2-letter country code of identification issuer
        /// </summary>
        [JsonProperty("country")]
        public string Country { get; set; } = string.Empty;

        /// <summary>
        /// The customer's bank verification number
        /// </summary>
        [JsonProperty("bvn")]
        public string Bvn { get; set; } = string.Empty;

        /// <summary>
        /// The customer's bank code
        /// You can get the list of Bank Codes by calling the List Banks endpoint. (required if type is bank_account)
        /// </summary>
        [JsonProperty("bank_code")]
        public string BankCode { get; set; } = string.Empty;

        /// <summary>
        /// The customer's bank account number. (required if type is bank_account)
        /// </summary>
        [JsonProperty("account_number")]
        public string AccountNumber { get; set; } = string.Empty;
    }
}