using System.Text.Json.Serialization;

namespace Paystack.NET.Models.Transactions.Options;

public class PartialDebitOptions
{
    /// <summary>
    /// The authorization code for the transaction.
    /// </summary>
    [JsonPropertyName("authorization_code")]
    public string AuthorizationCode { get; set; } = string.Empty;

    /// <summary>
    /// The currency of the transaction. Defaults to integration's currency.
    /// You can default to "GHS" for Ghana Cedis or allow other currencies.
    /// </summary>
    [JsonPropertyName("currency")]
    public string Currency { get; set; } = string.Empty;

    /// <summary>
    /// The amount to be charged, in the subunit of the supported currency.
    /// Example: 5000 for 50.00 in GHS (Ghana Cedi).
    /// </summary>
    [JsonPropertyName("amount")]
    public string Amount { get; set; } = string.Empty;

    /// <summary>
    /// The email address of the customer attached to the authorization code.
    /// </summary>
    [JsonPropertyName("email")]
    public string Email { get; set; } = string.Empty;

    /// <summary>
    /// A unique transaction reference. Only -, ., = and alphanumeric characters allowed.
    /// </summary>
    [JsonPropertyName("reference")]
    public string Reference { get; set; } = string.Empty;

    /// <summary>
    /// The minimum amount that should be debited (optional).
    /// </summary>
    [JsonPropertyName("at_least")]
    public string? AtLeast { get; set; }
}