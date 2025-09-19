using Newtonsoft.Json;

namespace Paystack.NET.Models.Plans.Options
{
    /// <summary>
    /// Represents the request body for updating a subscription plan.
    /// </summary>
    public class UpdatePlanOptions
    {
        /// <summary>
        /// Name of the plan (required).
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Amount should be in the subunit of the supported currency (required).
        /// Example: 5000 for 50.00 in GHS (Ghana Cedi).
        /// </summary>
        [JsonProperty("amount")]
        public int Amount { get; set; }

        /// <summary>
        /// Interval in words. 
        /// Valid intervals: daily, weekly, monthly, quarterly, biannually, annually (required).
        /// </summary>
        [JsonProperty("interval")]
        public string Interval { get; set; } = string.Empty;

        /// <summary>
        /// A description for this plan (optional).
        /// </summary>
        [JsonProperty("description")]
        public string? Description { get; set; }

        /// <summary>
        /// Set to false if you don’t want invoices sent to customers (optional).
        /// Default is true.
        /// </summary>
        [JsonProperty("send_invoices")]
        public bool? SendInvoices { get; set; }

        /// <summary>
        /// Set to false if you don’t want SMS notifications sent to customers (optional).
        /// Default is true.
        /// </summary>
        [JsonProperty("send_sms")]
        public bool? SendSms { get; set; }

        /// <summary>
        /// Currency in which the amount is set (optional).
        /// Example: "GHS", "NGN".
        /// </summary>
        [JsonProperty("currency", NullValueHandling = NullValueHandling.Ignore)]
        public string? Currency { get; set; }

        /// <summary>
        /// Number of invoices to raise during subscription (optional).
        /// Can be overridden when subscribing.
        /// </summary>
        [JsonProperty("invoice_limit", NullValueHandling = NullValueHandling.Ignore)]
        public int? InvoiceLimit { get; set; }
        
           
        /// <summary>
        /// Set to true if you want the existing subscriptions to use the new changes.
        /// Set to false and only new subscriptions will be changed.
        /// Defaults to true when not set.
        /// </summary>
        [JsonProperty("update_existing_subscriptions")]
        public bool? UpdateExistingSubscriptions { get; set; }
    }
}