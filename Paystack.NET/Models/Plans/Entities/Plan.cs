using System;
using Newtonsoft.Json;

namespace Paystack.NET.Models.Plans.Entities
{
    /// <summary>
    /// Represents a subscription plan entity returned by Paystack.
    /// </summary>
    public class Plan
    {
        /// <summary>
        /// The unique identifier for the plan.
        /// </summary>
        [JsonProperty("id")]
        public long Id { get; set; }
        
        /// <summary>
        /// Unique code for the plan.
        /// </summary>
        [JsonProperty("plan_code")]
        public string PlanCode { get; set; } = string.Empty;
        
        /// <summary>
        /// The display name of the plan.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// The currency for this plan (e.g., GHS, USD).
        /// </summary>
        [JsonProperty("currency")]
        public string Currency { get; set; } = string.Empty;
        
        /// <summary>
        /// The plan amount (in subunits of the currency).
        /// Example: 5000 for 50.00 in GHS (Ghana Cedi).
        /// </summary>
        [JsonProperty("amount")]
        public int Amount { get; set; }

        /// <summary>
        /// Billing interval (daily, weekly, monthly, quarterly, biannually, annually).
        /// </summary>
        [JsonProperty("interval")]
        public string Interval { get; set; } = string.Empty;

        /// <summary>
        /// Optional description for this plan.
        /// </summary>
        [JsonProperty("description")]
        public string? Description { get; set; }

        /// <summary>
        /// ID of the integration this plan belongs to.
        /// </summary>
        [JsonProperty("integration")]
        public int Integration { get; set; }

        /// <summary>
        /// The domain of the plan (e.g. test or live).
        /// </summary>
        [JsonProperty("domain")]
        public string Domain { get; set; } = string.Empty;

        /// <summary>
        /// Maximum number of invoices to raise during subscription (optional).
        /// </summary>
        [JsonProperty("invoice_limit")]
        public int InvoiceLimit { get; set; }

        /// <summary>
        /// Whether invoices are automatically sent to customers.
        /// </summary>
        [JsonProperty("send_invoices")]
        public bool SendInvoices { get; set; }

        /// <summary>
        /// Whether SMS notifications are sent to customers.
        /// </summary>
        [JsonProperty("send_sms")]
        public bool SendSms { get; set; }

        /// <summary>
        /// Indicates if hosted page is enabled.
        /// </summary>
        [JsonProperty("hosted_page")]
        public bool HostedPage { get; set; }

        /// <summary>
        /// Whether the plan was migrated.
        /// </summary>
        [JsonProperty("migrate")]
        public bool Migrate { get; set; }

        /// <summary>
        /// Whether the plan is archived.
        /// </summary>
        [JsonProperty("is_archived")]
        public bool IsArchived { get; set; }
        
        /// <summary>
        /// Date when the plan was created.
        /// </summary>
        [JsonProperty("createdAt")]
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// Date when the plan was last updated.
        /// </summary>
        [JsonProperty("updatedAt")]
        public DateTime UpdatedAt { get; set; }
    }
}