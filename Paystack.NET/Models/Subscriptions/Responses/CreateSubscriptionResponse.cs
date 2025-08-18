using System;
using Newtonsoft.Json;

namespace Paystack.NET.Models.Subscriptions.Responses
{
    /// <summary>
    /// Represents the response returned after creating a subscription.
    /// </summary>
    public class CreateSubscriptionResponse
    {
        /// <summary>
        /// Unique ID of the subscription.
        /// </summary>
        [JsonProperty("id")]
        public long Id { get; set; }

        /// <summary>
        /// Unique code identifying the subscription.
        /// </summary>
        [JsonProperty("subscription_code")]
        public string SubscriptionCode { get; set; } = string.Empty;

        /// <summary>
        /// The ID of the customer linked to this subscription.
        /// </summary>
        [JsonProperty("customer")]
        public long Customer { get; set; }

        /// <summary>
        /// The ID of the plan subscribed to.
        /// </summary>
        [JsonProperty("plan")]
        public long Plan { get; set; }

        /// <summary>
        /// The integration ID associated with this subscription.
        /// </summary>
        [JsonProperty("integration")]
        public long Integration { get; set; }

        /// <summary>
        /// The domain environment (e.g., "test" or "live").
        /// </summary>
        [JsonProperty("domain")]
        public string Domain { get; set; } = string.Empty;

        /// <summary>
        /// The start time of the subscription in Unix timestamp format.
        /// </summary>
        [JsonProperty("start")]
        public long Start { get; set; }

        /// <summary>
        /// Current status of the subscription (e.g., "active").
        /// </summary>
        [JsonProperty("status")]
        public string Status { get; set; } = string.Empty;

        /// <summary>
        /// The quantity of the subscription (default: 1).
        /// </summary>
        [JsonProperty("quantity")]
        public int Quantity { get; set; }

        /// <summary>
        /// The amount for the transaction in the subunit of the supported currency.
        /// Example: 5000 for 50.00 in GHS (Ghana Cedi).
        /// </summary>
        [JsonProperty("amount")]
        public int Amount { get; set; }

        /// <summary>
        /// The authorization linked to this subscription.
        /// This may be just an ID (long) or a full authorization object.
        /// </summary>
        [JsonProperty("authorization")]
        public long Authorization { get; set; }

        /// <summary>
        /// Limit on the number of invoices that can be generated for this subscription.
        /// </summary>
        [JsonProperty("invoice_limit")]
        public int InvoiceLimit { get; set; }

        /// <summary>
        /// The split code for revenue sharing, if applicable.
        /// </summary>
        [JsonProperty("split_code")]
        public string? SplitCode { get; set; }

        /// <summary>
        /// Custom metadata associated with the subscription.
        /// </summary>
        [JsonProperty("metadata")]
        public string? Metadata { get; set; }

        /// <summary>
        /// Email token used for managing the subscription.
        /// </summary>
        [JsonProperty("email_token")]
        public string EmailToken { get; set; } = string.Empty;

        /// <summary>
        /// Date and time the subscription was cancelled, if applicable.
        /// </summary>
        [JsonProperty("cancelledAt")]
        public DateTime? CancelledAt { get; set; }

        /// <summary>
        /// Date and time the subscription was created.
        /// </summary>
        [JsonProperty("createdAt")]
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// Date and time the subscription was last updated.
        /// </summary>
        [JsonProperty("updatedAt")]
        public DateTime UpdatedAt { get; set; }

        /// <summary>
        /// Cron expression describing the subscription billing schedule.
        /// </summary>
        [JsonProperty("cron_expression")]
        public string CronExpression { get; set; } = string.Empty;

        /// <summary>
        /// The next payment date for this subscription.
        /// </summary>
        [JsonProperty("next_payment_date")]
        public DateTime NextPaymentDate { get; set; }

        /// <summary>
        /// EasyCron ID if Paystack schedules via EasyCron.
        /// </summary>
        [JsonProperty("easy_cron_id")]
        public string? EasyCronId { get; set; }

        /// <summary>
        /// Open invoice reference if applicable.
        /// </summary>
        [JsonProperty("open_invoice")]
        public string? OpenInvoice { get; set; }
    }
}