using Newtonsoft.Json;

namespace Paystack.NET.Models.Transactions.Entities
{
    /// <summary>
    /// Represents authorization details for a transaction, including  
    /// card information, bank details, and reusable payment status.
    /// </summary>
    public class TransactionAuthorization
    {
        /// <summary>
        /// The unique authorization code for the transaction.
        /// </summary>
        [JsonProperty("authorization_code")]
        public string AuthorizationCode { get; set; } = string.Empty;

        /// <summary>
        /// The first six digits of the card used.
        /// </summary>
        [JsonProperty("bin")]
        public string Bin { get; set; } = string.Empty;

        /// <summary>
        /// The last four digits of the card used.
        /// </summary>
        [JsonProperty("last4")]
        public string Last4 { get; set; } = string.Empty;

        /// <summary>
        /// The card's expiration month.
        /// </summary>
        [JsonProperty("exp_month")]
        public string ExpMonth { get; set; } = string.Empty;

        /// <summary>
        /// The card's expiration year.
        /// </summary>
        [JsonProperty("exp_year")]
        public string ExpYear { get; set; } = string.Empty;

        /// <summary>
        /// The payment channel (e.g., "card").
        /// </summary>
        [JsonProperty("channel")]
        public string Channel { get; set; } = string.Empty;

        /// <summary>
        /// The type of card used (e.g., "visa").
        /// </summary>
        [JsonProperty("card_type")]
        public string CardType { get; set; } = string.Empty;

        /// <summary>
        /// The bank associated with the card.
        /// </summary>
        [JsonProperty("bank")]
        public string Bank { get; set; } = string.Empty;

        /// <summary>
        /// The country code of the bank.
        /// </summary>
        [JsonProperty("country_code")]
        public string CountryCode { get; set; } = string.Empty;

        /// <summary>
        /// The card brand (e.g., "visa").
        /// </summary>
        [JsonProperty("brand")]
        public string Brand { get; set; } = string.Empty;

        /// <summary>
        /// Indicates whether the authorization is reusable for future payments.
        /// </summary>
        [JsonProperty("reusable")]
        public bool Reusable { get; set; }

        /// <summary>
        /// The signature for this authorization.
        /// </summary>
        [JsonProperty("signature")]
        public string Signature { get; set; } = string.Empty;

        /// <summary>
        /// The name on the card, if available.
        /// </summary>
        [JsonProperty("account_name")]
        public string? AccountName { get; set; }
    }
}