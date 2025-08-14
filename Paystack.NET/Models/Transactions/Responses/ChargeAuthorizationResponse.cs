using Newtonsoft.Json;
using Paystack.NET.Models.Customers;
using Paystack.NET.Models.Customers.Entities;
using Paystack.NET.Models.Transactions.Entities;

namespace Paystack.NET.Models.Transactions.Responses;

/// <summary>
/// Represents the response from charging an authorization.
/// </summary>
public class ChargeAuthorizationResponse
{
    
    /// <summary>
    /// The unique ID of the transaction.
    /// </summary>
    [JsonProperty("id")]
    public long Id { get; set; }

    /// <summary>
    /// The amount for the transaction in pesewa (GHS).
    /// Example: 5000 for 50.00 in GHS (Ghana Cedi).
    /// </summary>
    [JsonProperty("amount")]
    public string Amount { get; set; } = string.Empty;

    /// <summary>
    /// The currency of the transaction (e.g., "GHS").
    /// </summary>
    [JsonProperty("currency")]
    public string Currency { get; set; } = string.Empty;

    /// <summary>
    /// The date and time of the transaction.
    /// </summary>
    [JsonProperty("transaction_date")]
    public DateTime TransactionDate { get; set; }

    /// <summary>
    /// The status of the transaction (e.g., success, failed).
    /// </summary>
    [JsonProperty("status")]
    public string Status { get; set; } = string.Empty;

    /// <summary>
    /// The unique reference for the transaction.
    /// </summary>
    [JsonProperty("reference")]
    public string Reference { get; set; } = string.Empty;

    /// <summary>
    /// The domain of the transaction (e.g., live, test).
    /// </summary>
    [JsonProperty("domain")]
    public string Domain { get; set; } = string.Empty;

    /// <summary>
    /// Metadata associated with the transaction.
    /// </summary>
    [JsonProperty("metadata")]
    public object? Metadata { get; set; }

    /// <summary>
    /// The response message from the payment gateway.
    /// </summary>
    [JsonProperty("gateway_response")]
    public string GatewayResponse { get; set; } = string.Empty;

    /// <summary>
    /// An optional message from the transaction (often null).
    /// </summary>
    [JsonProperty("message")]
    public string? Message { get; set; }

    /// <summary>
    /// The payment channel used (e.g., card, bank).
    /// </summary>
    [JsonProperty("channel")]
    public string Channel { get; set; } = string.Empty;

    /// <summary>
    /// The IP address of the customer if available.
    /// </summary>
    [JsonProperty("ip_address")]
    public string? IpAddress { get; set; }

    /// <summary>
    /// The transaction log, if available.
    /// </summary>
    [JsonProperty("log")]
    public object? Log { get; set; }

    /// <summary>
    /// The fees charged for the transaction.
    /// </summary>
    [JsonProperty("fees")]
    public int Fees { get; set; }

    /// <summary>
    /// The authorization details for the transaction.
    /// </summary>
    [JsonProperty("authorization")]
    public TransactionAuthorization? Authorization { get; set; }

    /// <summary>
    /// The customer associated with the transaction.
    /// </summary>
    [JsonProperty("customer")]
    public Customer? Customer { get; set; }

    /// <summary>
    /// The plan associated with the transaction, if any.
    /// </summary>
    [JsonProperty("plan")]
    public object? Plan { get; set; }
}