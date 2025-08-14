using Newtonsoft.Json;
using Paystack.NET.Models.Shared.Options;

namespace Paystack.NET.Models.Transactions.Options;

/// <summary>
/// Represents the query parameters for retrieving transactions from the Paystack API.
/// </summary>
public class ListTransactionOptions : BasePaginationOptions
{
    /// <summary>
    /// The ID of the customer whose transactions you want to retrieve.
    /// </summary>
    [JsonProperty("customer")]
    public int? Customer { get; set; }

    /// <summary>
    /// The Terminal ID for the transactions you want to retrieve.
    /// </summary>
    [JsonProperty("terminalid")]
    public string? TerminalId { get; set; }

    /// <summary>
    /// Filter transactions by status ('failed', 'success', 'abandoned').
    /// </summary>
    [JsonProperty("status")]
    public string? Status { get; set; }
    
    /// <summary>
    /// Filter transactions by amount using the supported currency code.
    /// </summary>
    [JsonProperty("amount")]
    public int? Amount { get; set; }
}