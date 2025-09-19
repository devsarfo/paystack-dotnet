using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Paystack.NET.Models.Plans.Entities
{
    /// <summary>
    /// Represents a subscription plan entity returned by Paystack.
    /// </summary>
    public class PlanData : Plan
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
        /// Total number of pages associated with the plan.
        /// </summary>
        [JsonProperty("pages_count")]
        public int PagesCount { get; set; }

        /// <summary>
        /// Total number of subscribers.
        /// </summary>
        [JsonProperty("subscribers_count")]
        public int SubscribersCount { get; set; }

        /// <summary>
        /// Total number of subscriptions.
        /// </summary>
        [JsonProperty("subscriptions_count")]
        public int SubscriptionsCount { get; set; }

        /// <summary>
        /// Total number of active subscriptions.
        /// </summary>
        [JsonProperty("active_subscriptions_count")]
        public int ActiveSubscriptionsCount { get; set; }

        /// <summary>
        /// Total revenue from this plan (in subunits of the currency).
        /// </summary>
        [JsonProperty("total_revenue")]
        public int TotalRevenue { get; set; }

        /// <summary>
        /// List of subscriptions under this plan.
        /// </summary>
        [JsonProperty("subscriptions")]
        public List<JToken> Subscriptions { get; set; } = new List<JToken>();

        /// <summary>
        /// Summary of subscribers.
        /// </summary>
        [JsonProperty("subscribers")]
        public List<JToken> Subscribers { get; set; } = new List<JToken>();

        /// <summary>
        /// List of pages associated with the plan (optional).
        /// </summary>
        [JsonProperty("pages")]
        public List<JToken> Pages { get; set; } = new List<JToken>();
    }
}