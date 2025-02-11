namespace Paystack.NET.Constants;

/// <summary>
/// Represents possible statuses of a Paystack transaction.
/// </summary>
public static class TransactionStatus
{
    /// <summary>
    /// The customer has not completed the transaction.
    /// </summary>
    public const string Abandoned = "abandoned";

    /// <summary>
    /// The transaction failed. Check the message or gateway response for details.
    /// </summary>
    public const string Failed = "failed";

    /// <summary>
    /// The customer is currently trying to complete the transaction.
    /// This may be waiting for OTP input or a bank transfer confirmation.
    /// </summary>
    public const string Ongoing = "ongoing";

    /// <summary>
    /// The transaction is currently in progress.
    /// </summary>
    public const string Pending = "pending";

    /// <summary>
    /// Same as pending, but specifically for direct debit transactions.
    /// </summary>
    public const string Processing = "processing";

    /// <summary>
    /// The transaction has been queued to be processed later.
    /// This is only possible for bulk charge transactions.
    /// </summary>
    public const string Queued = "queued";

    /// <summary>
    /// The transaction was reversed, meaning it was either refunded or a chargeback was successfully logged.
    /// </summary>
    public const string Reversed = "reversed";

    /// <summary>
    /// The transaction was successfully processed.
    /// </summary>
    public const string Success = "success";
}