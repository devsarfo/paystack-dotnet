using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Paystack.NET.Models.Callback.Responses;

/// <summary>
/// Represents a webhook callback payload received from Paystack.  
/// Contains the event type and raw JSON data for the user to deserialize as needed.
/// </summary>
public class CallbackResponse
{
    /// <summary>
    /// The type of event triggered by Paystack (e.g., "charge.success").
    /// </summary>
    [JsonProperty("event")]
    public string Event { get; set; } = string.Empty;

    /// <summary>
    /// The raw JSON string containing the event-specific data.  
    /// The consumer of this library should deserialize this into the appropriate type.
    /// </summary>
    [JsonProperty("data")]
    public JToken Data { get; set; } = default!;
}