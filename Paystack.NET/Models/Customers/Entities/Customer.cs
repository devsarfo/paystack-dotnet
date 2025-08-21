using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Paystack.NET.Models.Customers.Entities
{
    /// <summary>
    /// Represents a customer involved in a Paystack transaction,  
    /// including their contact details and unique customer code.
    /// </summary>
    public class Customer
    {
        /// <summary>
        /// The unique identifier for the customer.
        /// </summary>
        [JsonProperty("id")]
        public long Id { get; set; }

        /// <summary>
        /// The first name of the customer (if available).
        /// </summary>
        [JsonProperty("first_name")]
        public string? FirstName { get; set; }

        /// <summary>
        /// The last name of the customer (if available).
        /// </summary>
        [JsonProperty("last_name")]
        public string? LastName { get; set; }

        /// <summary>
        /// The email address associated with the customer.
        /// </summary>
        [JsonProperty("email")]
        public string Email { get; set; } = string.Empty;

        /// <summary>
        /// The phone number of the customer (if available).
        /// </summary>
        [JsonProperty("phone")]
        public string? Phone { get; set; }
        
        /// <summary>
        /// Additional metadata related to the customer.
        /// </summary>
        [JsonProperty("metadata")]
        public JToken? Metadata { get; set; }

        /// <summary>
        /// The domain of the customer (e.g., live, test).
        /// </summary>
        [JsonProperty("domain")]
        public string? Domain { get; set; }
        
        /// <summary>
        /// A unique code assigned to the customer by Paystack.
        /// </summary>
        [JsonProperty("customer_code")]
        public string CustomerCode { get; set; } = string.Empty;

        /// <summary>
        /// The risk action associated with the customer (e.g., "default").
        /// </summary>
        [JsonProperty("risk_action")]
        public string RiskAction { get; set; } = string.Empty;
        
        
        /// <summary>
        /// The integration ID associated with the customer.
        /// </summary>
        [JsonProperty("integration")]
        public long Integration { get; set; }

        /// <summary>
        /// The date and time when the customer record was created.
        /// </summary>
        [JsonProperty("createdAt")]
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// The date and time when the customer record was last updated.
        /// </summary>
        [JsonProperty("updatedAt")]
        public DateTime UpdatedAt { get; set; }
    }
}