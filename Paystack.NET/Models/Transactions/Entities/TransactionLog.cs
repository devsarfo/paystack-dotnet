using Newtonsoft.Json;

namespace Paystack.NET.Models.Transactions.Entities;

public class TransactionLog
{
    /// <summary>
    /// The start time of the transaction process (Unix timestamp).
    /// </summary>
    [JsonProperty("start_time")]
    public int StartTime { get; set; }

    /// <summary>
    /// The total time spent processing the transaction (in seconds).
    /// </summary>
    [JsonProperty("time_spent")]
    public int TimeSpent { get; set; }

    /// <summary>
    /// The number of attempts made for the transaction.
    /// </summary>
    [JsonProperty("attempts")]
    public int Attempts { get; set; }

    /// <summary>
    /// The number of errors encountered during processing.
    /// </summary>
    [JsonProperty("errors")]
    public int Errors { get; set; }

    /// <summary>
    /// Indicates whether the transaction was successfully processed.
    /// </summary>
    [JsonProperty("success")]
    public bool Success { get; set; }

    /// <summary>
    /// Indicates whether the transaction was attempted via a mobile device.
    /// </summary>
    [JsonProperty("mobile")]
    public bool Mobile { get; set; }

    /// <summary>
    /// A list of input parameters used for processing the transaction.
    /// </summary>
    [JsonProperty("input")]
    public List<object> Input { get; set; } = new List<object>();

    /// <summary>
    /// A chronological history of actions taken during the transaction process.
    /// </summary>
    [JsonProperty("history")]
    public List<TransactionHistory> History { get; set; } = new List<TransactionHistory>();
}