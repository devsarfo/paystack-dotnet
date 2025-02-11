using Newtonsoft.Json;

namespace Paystack.NET.Models.Common.Entities;

public class CurrencyAmount
{
    /// <summary>
    /// The currency code.
    /// </summary>
    [JsonProperty("currency")]
    public string Currency { get; set; } = string.Empty;

    /// <summary>
    /// The amount for the transaction in pesewa (GHS).
    /// Example: 5000 for 50.00 in GHS (Ghana Cedi).
    /// </summary>
    [JsonProperty("amount")]
    public string Amount { get; set; } = string.Empty;
}