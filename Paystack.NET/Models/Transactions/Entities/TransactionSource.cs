using Newtonsoft.Json;

namespace Paystack.NET.Models.Transactions.Entities;

public class TransactionSource
{
    /// <summary>
    /// The source of the transaction.
    /// </summary>
    [JsonProperty("source")]
    public string Source { get; set; } = string.Empty;

    /// <summary>
    /// The type of the transaction source.
    /// </summary>
    [JsonProperty("type")]
    public string Type { get; set; } = string.Empty;

    /// <summary>
    /// The identifier for the source (nullable).
    /// </summary>
    [JsonProperty("identifier")]
    public string? Identifier { get; set; }

    /// <summary>
    /// The entry point for the transaction.
    /// </summary>
    [JsonProperty("entry_point")]
    public string EntryPoint { get; set; } = string.Empty;

}