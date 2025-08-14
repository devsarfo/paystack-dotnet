using Newtonsoft.Json;
using Paystack.NET.Models.Shared.Entities;

namespace Paystack.NET.Models.Transactions.Responses;

public class TransactionTotalsResponse
{
    /// <summary>
    /// Total number of transactions.
    /// </summary>
    [JsonProperty("total_transactions")]
    public int TotalTransactions { get; set; }

    /// <summary>
    /// Total volume of transactions (in subunit of the currency).
    /// </summary>
    [JsonProperty("total_volume")]
    public int TotalVolume { get; set; }

    /// <summary>
    /// Total volume by currency.
    /// </summary>
    [JsonProperty("total_volume_by_currency")]
    public List<CurrencyAmount> TotalVolumeByCurrency { get; set; } = new List<CurrencyAmount>();

    /// <summary>
    /// Pending transfers.
    /// </summary>
    [JsonProperty("pending_transfers")]
    public int PendingTransfers { get; set; }

    /// <summary>
    /// Pending transfers by currency.
    /// </summary>
    [JsonProperty("pending_transfers_by_currency")]
    public List<CurrencyAmount> PendingTransfersByCurrency { get; set; } = new List<CurrencyAmount>();
}