using Newtonsoft.Json;

namespace Paystack.NET.Models.Transactions.Responses;

public class InitializeTransactionResponse
{
    /// <summary>
    /// This URL is used to redirect the user to Paystack's checkout page for completing the payment.
    /// </summary>
    [JsonProperty("authorization_url")]
    public string AuthorizationUrl { get; set; } = string.Empty;
    
    /// <summary>
    /// The access code is required to authenticate the transaction on Paystack's side.
    /// </summary>
    [JsonProperty("access_code")]
    public string AccessCode { get; set; } = string.Empty;

    /// <summary>
    /// The reference is a unique identifier for the transaction, used to track or verify the transaction on Paystack.
    /// </summary>
    [JsonProperty("reference")]
    public string Reference { get; set; } = string.Empty;
}