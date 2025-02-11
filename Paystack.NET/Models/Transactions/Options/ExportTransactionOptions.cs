using Newtonsoft.Json;
using Paystack.NET.Models.Common.Options;

namespace Paystack.NET.Models.Transactions.Options;

public class ExportTransactionOptions : BasePaginationOptions
{
    /// <summary>
    /// Specify an ID for the customer whose transactions you want to retrieve.
    /// </summary>
    [JsonProperty("customer")]
    public int? Customer { get; set; }

    /// <summary>
    /// Filter transactions by status. ('failed', 'success', 'abandoned')
    /// </summary>
    [JsonProperty("status")]
    public string? Status { get; set; }

    /// <summary>
    /// Specify the transaction currency to export.
    /// </summary>
    [JsonProperty("currency")]
    public string? Currency { get; set; }

    /// <summary>
    /// Filter transactions by amount, using the supported currency.
    /// </summary>
    [JsonProperty("amount")]
    public int? Amount { get; set; }

    /// <summary>
    /// Set to true to export only settled transactions, false for pending transactions.
    /// Leave undefined to export all transactions.
    /// </summary>
    [JsonProperty("settled")]
    public bool? Settled { get; set; }

    /// <summary>
    /// An ID for the settlement whose transactions should be exported.
    /// </summary>
    [JsonProperty("settlement")]
    public int? Settlement { get; set; }

    /// <summary>
    /// Specify a payment page's ID to export only transactions conducted on that page.
    /// </summary>
    [JsonProperty("payment_page")]
    public int? PaymentPage { get; set; }
}