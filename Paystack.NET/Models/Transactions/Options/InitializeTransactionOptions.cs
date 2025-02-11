using Newtonsoft.Json;
using Paystack.NET.Constants;

namespace Paystack.NET.Models.Transactions.Options;

public class InitializeTransactionOptions
{
    /// <summary>
    /// The amount to be charged, in the subunit of the supported currency.
    /// Example: 5000 for 50.00 in GHS (Ghana Cedi).
    /// </summary>
    [JsonProperty("amount")]
    public string Amount { get; set; } = string.Empty;

    /// <summary>
    /// The customer's email address.
    /// </summary>
    [JsonProperty("email")]
    public string Email { get; set; } = string.Empty;

    /// <summary>
    /// The currency of the transaction. Defaults to integration's currency.
    /// You can default to "GHS" for Ghana Cedis or allow other currencies.
    /// </summary>
    [JsonProperty("currency")]
    public string Currency { get; set; } = "GHS"; 

    /// <summary>
    /// A unique reference for the transaction. Allowed characters: -, ., =, alphanumeric.
    /// </summary>
    [JsonProperty("reference")]
    public string Reference { get; set; } = string.Empty;

    /// <summary>
    /// A callback URL where Paystack will send the response.
    /// </summary>
    [JsonProperty("callback_url")]
    public string CallbackUrl { get; set; } = string.Empty;

    /// <summary>
    /// If the transaction is for a subscription, provide the plan code here.
    /// </summary>
    [JsonProperty("plan")]
    public string? Plan { get; set; }

    /// <summary>
    /// The number of times to charge the customer for the subscription plan.
    /// </summary>
    [JsonProperty("invoice_limit")]
    public int? InvoiceLimit { get; set; }

    /// <summary>
    /// Metadata for custom data in stringified JSON format.
    /// Either a Key/value pair or using the CustomField class for Custom Fields
    /// </summary>
    [JsonProperty("metadata")]
    public object? Metadata { get; set; }

    /// <summary>
    /// An array of payment channels. Default is all available channels.
    /// </summary>
    [JsonProperty("channels")]
    public string[] Channels { get; set; } = new string[] { };

    /// <summary>
    /// The transaction split code.
    /// </summary>
    [JsonProperty("split_code")]
    public string? SplitCode { get; set; }

    /// <summary>
    /// The code for the subaccount to own the payment.
    /// </summary>
    [JsonProperty("subaccount")]
    public string? Subaccount { get; set; }

    /// <summary>
    /// An amount to override the split configuration for the payment.
    /// </summary>
    [JsonProperty("transaction_charge")]
    public int? TransactionCharge { get; set; }

    /// <summary>
    /// Who bears the transaction charges: "account" or "subaccount" (defaults to "account").
    /// </summary>
    [JsonProperty("bearer")]
    public string Bearer { get; set; } = TransactionChargeBearer.Account;
}