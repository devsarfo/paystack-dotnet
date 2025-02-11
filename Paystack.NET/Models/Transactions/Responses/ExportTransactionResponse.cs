using Newtonsoft.Json;

namespace Paystack.NET.Models.Transactions.Responses;

public class ExportTransactionResponse
{
    /// <summary>
    /// The URL of the exported transaction file.
    /// </summary>
    [JsonProperty("path")]
    public string Path { get; set; } = string.Empty;

    /// <summary>
    /// The expiration date and time of the export URL.
    /// </summary>
    [JsonProperty("expiresAt")]
    public string ExpiresAt { get; set; } = string.Empty;
}