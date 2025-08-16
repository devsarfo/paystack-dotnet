using System.Collections.Generic;
using Newtonsoft.Json;
using Paystack.NET.Models.Transactions.Entities;

namespace Paystack.NET.Models.Customers.Entities
{
    /// <summary>
    /// Represents the detailed customer object returned by the Paystack API.
    /// </summary>
    public class CustomerData : Customer
    {
        /// <summary>
        /// A list of transactions associated with the customer.
        /// </summary>
        [JsonProperty("transactions")]
        public List<object> Transactions { get; set; } = new List<object>();

        /// <summary>
        /// A list of subscriptions associated with the customer.
        /// </summary>
        [JsonProperty("subscriptions")]
        public List<object> Subscriptions { get; set; } = new List<object>();

        /// <summary>
        /// A list of payment authorizations linked to the customer.
        /// </summary>
        [JsonProperty("authorizations")]
        public List<TransactionAuthorization> Authorizations { get; set; } = new List<TransactionAuthorization>();

        /// <summary>
        /// Total number of transactions made by the customer.
        /// </summary>
        [JsonProperty("total_transactions")]
        public int TotalTransactions { get; set; }

        /// <summary>
        /// Total transaction value grouped by currency.
        /// </summary>
        [JsonProperty("total_transaction_value")]
        public List<object> TotalTransactionValue { get; set; } = new List<object>();

        /// <summary>
        /// Indicates whether the customer has been identified (KYC).
        /// </summary>
        [JsonProperty("identified")]
        public bool Identified { get; set; }

        /// <summary>
        /// Identification details if available.
        /// </summary>
        [JsonProperty("identifications")]
        public object? Identifications { get; set; }
    }
}