using Newtonsoft.Json;

namespace Paystack.NET.Models.Shared.Options;

public class BasePaginationOptions
{
    /// <summary>
    /// Specify how many records you want to retrieve per page.
    /// Default value is 50 if not specified.
    /// </summary>
    [JsonProperty("perPage")]
    public int? PerPage { get; set; }

    /// <summary>
    /// Specify exactly what page you want to retrieve.
    /// Default value is 1 if not specified.
    /// </summary>
    [JsonProperty("page")]
    public int? Page { get; set; }
    
    /// <summary>
    /// A timestamp from which to start listing data.
    /// Format: yyyy-MM-ddTHH:mm:ss.fffZ (ISO 8601 format)
    /// </summary>
    [JsonProperty("from")]
    public DateTime? From { get; set; }

    /// <summary>
    /// A timestamp at which to stop listing data.
    /// Format: yyyy-MM-ddTHH:mm:ss.fffZ (ISO 8601 format)
    /// </summary>
    [JsonProperty("to")]
    public DateTime? To { get; set; }

}