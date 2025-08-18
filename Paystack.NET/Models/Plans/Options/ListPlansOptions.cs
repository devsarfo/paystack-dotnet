using Newtonsoft.Json;
using Paystack.NET.Models.Shared.Options;

namespace Paystack.NET.Models.Plans.Options
{
    /// <summary>
    /// Represents the query parameters for retrieving plans from the Paystack API.
    /// </summary>
    public class ListPlansOptions : BasePaginationOptions
    {
        /// <summary>
        /// Filter list by plans with specified status
        /// </summary>
        [JsonProperty("status")]
        public string? Status { get; set; }
        
        /// <summary>
        /// Filter list by plans with specified interval
        /// </summary>
        [JsonProperty("interval")]
        public string? Interval { get; set; }
        
        /// <summary>
        /// Filter list by plans with specified amount using the supported currency
        /// </summary>
        [JsonProperty("amount")]
        public int? Amount { get; set; }
    }
}