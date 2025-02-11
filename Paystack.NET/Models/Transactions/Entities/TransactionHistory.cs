using Newtonsoft.Json;

namespace Paystack.NET.Models.Transactions.Entities;

public class TransactionHistory
{
    /// <summary>
    /// The type of transaction event (e.g., "action", "success", "failure").
    /// </summary>
    [JsonProperty("type")]
    public string Type { get; set; } = string.Empty;

    /// <summary>
    /// A message describing the event (e.g., "Attempted to pay with card").
    /// </summary>
    [JsonProperty("message")]
    public string Message { get; set; } = string.Empty;

    /// <summary>
    /// The time (in seconds) at which the event occurred relative to the transaction start.
    /// </summary>
    [JsonProperty("time")]
    public int Time { get; set; }
}