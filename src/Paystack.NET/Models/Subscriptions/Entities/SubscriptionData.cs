using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Paystack.NET.Models.Customers.Entities;
using Paystack.NET.Models.Plans.Entities;
using Paystack.NET.Models.Transactions.Entities;

namespace Paystack.NET.Models.Subscriptions.Entities
{
    /// <summary>
    /// Represents a detailed subscription object from Paystack, including 
    /// invoices, invoice history, and other extended subscription data.
    /// </summary>
    public class SubscriptionData
    {
         /// <summary>
        /// The unique identifier for the subscription.
        /// </summary>
        [JsonProperty("id")]
        public long Id { get; set; }

        /// <summary>
        /// The operating domain of the subscription (e.g., "test" or "live").
        /// </summary>
        [JsonProperty("domain")]
        public string Domain { get; set; } = string.Empty;

        /// <summary>
        /// The status of the subscription (e.g., "active", "cancelled").
        /// </summary>
        [JsonProperty("status")]
        public string Status { get; set; } = string.Empty;

        /// <summary>
        /// The unique subscription code assigned by Paystack.
        /// </summary>
        [JsonProperty("subscription_code")]
        public string SubscriptionCode { get; set; } = string.Empty;

        /// <summary>
        /// The email token used for confirming subscription actions.
        /// </summary>
        [JsonProperty("email_token")]
        public string EmailToken { get; set; } = string.Empty;

        /// <summary>
        /// The total subscription amount in cedis (smallest currency unit).
        /// </summary>
        [JsonProperty("amount")]
        public int Amount { get; set; }

        /// <summary>
        /// The cron expression describing the billing schedule.
        /// </summary>
        [JsonProperty("cron_expression")]
        public string CronExpression { get; set; } = string.Empty;

        /// <summary>
        /// The next scheduled payment date.
        /// </summary>
        [JsonProperty("next_payment_date")]
        public DateTime? NextPaymentDate { get; set; }

        /// <summary>
        /// The timestamp the subscription was created.
        /// </summary>
        [JsonProperty("createdAt")]
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// The timestamp the subscription was cancelled.
        /// </summary>
        [JsonProperty("cancelledAt")]
        public DateTime? CancelledAt { get; set; }

        /// <summary>
        /// The integration ID associated with the subscription.
        /// </summary>
        [JsonProperty("integration")]
        public long Integration { get; set; }

        /// <summary>
        /// The plan associated with the subscription.
        /// </summary>
        [JsonProperty("plan")]
        public Plan Plan { get; set; } = new Plan();

        /// <summary>
        /// The payment authorization details used for this subscription.
        /// </summary>
        [JsonProperty("authorization")]
        public TransactionAuthorization Authorization { get; set; } = new TransactionAuthorization();

        /// <summary>
        /// The customer linked to this subscription.
        /// </summary>
        [JsonProperty("customer")]
        public Customer Customer { get; set; } = new Customer();
        
        /// <summary>
        /// List of invoices generated for this subscription.
        /// </summary>
        [JsonProperty("invoices")]
        public List<JToken> Invoices { get; set; } = new List<JToken>();

        /// <summary>
        /// Historical invoice records for this subscription.
        /// </summary>
        [JsonProperty("invoices_history")]
        public List<JToken> InvoicesHistory { get; set; } = new List<JToken>();
        
        /// <summary>
        /// The maximum number of invoices allowed (0 = unlimited).
        /// </summary>
        [JsonProperty("invoice_limit")]
        public int InvoiceLimit { get; set; }

        /// <summary>
        /// The split code associated with revenue splits, if any.
        /// </summary>
        [JsonProperty("split_code")]
        public string? SplitCode { get; set; }

        /// <summary>
        /// The most recent invoice associated with this subscription.
        /// </summary>
        [JsonProperty("most_recent_invoice")]
        public JToken? MostRecentInvoice { get; set; }
        
        /// <summary>
        /// Additional metadata associated with the subscription.
        /// </summary>
        [JsonProperty("metadata")]
        public JToken? Metadata { get; set; }

        /// <summary>
        /// The number of payments that have been made under this subscription.
        /// </summary>
        [JsonProperty("payments_count")]
        public int PaymentsCount { get; set; }
    }
}