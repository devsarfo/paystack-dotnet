using System;
using Newtonsoft.Json;
using Paystack.NET.Models.Customers.Entities;
using Paystack.NET.Models.Transactions.Entities;

namespace Paystack.NET.Models.Transactions.Responses
{
    /// <summary>
    /// Represents the response from Paystack when retrieving transactions.
    /// </summary>
    public class VerifyTransactionResponse
    {
        /// <summary>
        /// The unique identifier for the transaction.
        /// </summary>
        [JsonProperty("id")]
        public long Id { get; set; }

        /// <summary>
        /// The domain of the transaction (e.g., "test" or "live").
        /// </summary>
        [JsonProperty("domain")]
        public string Domain { get; set; } = string.Empty;

        /// <summary>
        /// The current status of the transaction (e.g., "success", "failed").
        /// </summary>
        [JsonProperty("status")]
        public string Status { get; set; } = string.Empty;

        /// <summary>
        /// Unique reference string assigned to the transaction.
        /// </summary>
        [JsonProperty("reference")]
        public string Reference { get; set; } = string.Empty;
    
        /// <summary>
        /// The receipt number assigned to the transaction.
        /// </summary>
        [JsonProperty("receipt_number")]
        public string? ReceiptNumber { get; set; }

        /// <summary>
        /// The amount for the transaction in pesewa (GHS).
        /// Example: 5000 for 50.00 in GHS (Ghana Cedi).
        /// </summary>
        [JsonProperty("amount")]
        public string Amount { get; set; } = string.Empty;

        /// <summary>
        /// An optional message from the transaction (often null).
        /// </summary>
        [JsonProperty("message")]
        public string? Message { get; set; }
    
        /// <summary>
        /// The gateway response message (e.g., "Successful").
        /// </summary>
        [JsonProperty("gateway_response")]
        public string GatewayResponse { get; set; } = string.Empty;

        /// <summary>
        /// The date and time when the payment was made.
        /// </summary>
        [JsonProperty("paid_at")]
        public DateTime? PaidAt { get; set; }

        /// <summary>
        /// The date and time when the transaction was created.
        /// </summary>
        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// The payment channel used (e.g., "card", "bank").
        /// </summary>
        [JsonProperty("channel")]
        public string Channel { get; set; } = string.Empty;

        /// <summary>
        /// The currency of the transaction (e.g., "GHS").
        /// </summary>
        [JsonProperty("currency")]
        public string Currency { get; set; } = string.Empty;

        /// <summary>
        /// The IP address from which the transaction was initiated.
        /// </summary>
        [JsonProperty("ip_address")]
        public string IpAddress { get; set; } = string.Empty;

        /// <summary>
        /// The metadata of the transaction
        /// </summary>
        [JsonProperty("metadata")]
        public object? Metadata { get; set; }
    
        /// <summary>
        /// Details about the transaction log.
        /// </summary>
        [JsonProperty("log")]
        public TransactionLog? Log { get; set; }

        /// <summary>
        /// The fees deducted for the transaction.
        /// </summary>
        [JsonProperty("fees")]
        public int Fees { get; set; }
    
        /// <summary>
        /// Authorization details for the transaction.
        /// </summary>
        [JsonProperty("authorization")]
        public TransactionAuthorization Authorization { get; set; } = new TransactionAuthorization();
    
        /// <summary>
        /// Customer details related to the transaction.
        /// </summary>
        [JsonProperty("customer")]
        public Customer Customer { get; set; } = new Customer();
    
        /// <summary>
        /// The plan id for the transaction.
        /// </summary>
        [JsonProperty("plan")]
        public string? Plan { get; set; }
    
        /// <summary>
        /// The split object for the transaction.
        /// </summary>
        [JsonProperty("split")]
        public object Split { get; set; } = new object();
    
        /// <summary>
        /// The order id for the transaction.
        /// </summary>
        [JsonProperty("order_id")]
        public string? OrderId { get; set; }
    
        /// <summary>
        /// The requested amount for the transaction in pesewa (GHS).
        /// Example: 5000 for 50.00 in GHS (Ghana Cedi).
        /// </summary>
        [JsonProperty("requested_amount")]
        public int RequestedAmount { get; set; }
    
        /// <summary>
        /// The pos transaction data.
        /// </summary>
        [JsonProperty("pos_transaction_data")]
        public object? PosTransactionData { get; set; }
    
        /// <summary>
        /// The source of the transaction.
        /// </summary>
        [JsonProperty("source")]
        public TransactionSource? Source { get; set; }
    
        /// <summary>
        /// The fees breakdown of the transaction.
        /// </summary>
        [JsonProperty("fees_breakdown")]
        public object? FeesBreakdown { get; set; }
    
        /// <summary>
        /// The connect for the transaction.
        /// </summary>
        [JsonProperty("connect")]
        public object? Connect { get; set; }
    
        /// <summary>
        /// The date and time when the transaction was created.
        /// </summary>
        [JsonProperty("transaction_date")]
        public DateTime TransactionDate { get; set; }

        /// <summary>
        /// The plan for the transaction.
        /// </summary>
        [JsonProperty("plan_object")]
        public object PlanObject { get; set; } = new object();
    
        /// <summary>
        /// The sub account for the transaction.
        /// </summary>
        [JsonProperty("subaccount")]
        public object Subaccount { get; set; } = new object();
    }
}