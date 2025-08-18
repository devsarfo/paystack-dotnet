using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Paystack.NET.Models.Plans.Entities
{
    /// <summary>
    /// Represents a subscription plan entity returned by Paystack.
    /// </summary>
    public class PlanListData : Plan
    {
        /// <summary>
        /// URL of the hosted page (optional).
        /// </summary>
        [JsonProperty("hosted_page_url")]
        public string? HostedPageUrl { get; set; }

        /// <summary>
        /// Hosted page summary (optional).
        /// </summary>
        [JsonProperty("hosted_page_summary")]
        public string? HostedPageSummary { get; set; }

        /// <summary>
        /// Whether the plan has been deleted.
        /// </summary>
        [JsonProperty("is_deleted")]
        public bool IsDeleted { get; set; }
        
        /// <summary>
        /// Total number of subscriptions.
        /// </summary>
        [JsonProperty("total_subscriptions")]
        public int TotalSubscriptions { get; set; }

        /// <summary>
        /// Total number of active subscriptions.
        /// </summary>
        [JsonProperty("active_subscriptions")]
        public int ActiveSubscriptions { get; set; }

        /// <summary>
        /// Total revenue from this plan (in subunits of the currency).
        /// </summary>
        [JsonProperty("total_subscriptions_revenue")]
        public int TotalSubscriptionsRevenue { get; set; }

        /// <summary>
        /// List of subscriptions under this plan.
        /// </summary>
        [JsonProperty("subscriptions")]
        public List<JToken> Subscriptions { get; set; } = new List<JToken>();
        
        /// <summary>
        /// List of pages associated with the plan (optional).
        /// </summary>
        [JsonProperty("pages")]
        public List<JToken> Pages { get; set; } = new List<JToken>();
    }
}