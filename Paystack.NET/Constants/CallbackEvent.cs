namespace Paystack.NET.Constants;

/// <summary>
/// Contains constants for all Paystack webhook event types.
/// </summary>
public static class CallbackEvent
{
    // Charge Disputes
    public const string ChargeDisputeCreate = "charge.dispute.create";
    public const string ChargeDisputeRemind = "charge.dispute.remind";
    public const string ChargeDisputeResolve = "charge.dispute.resolve";

    // Charges
    public const string ChargeSuccess = "charge.success";

    // Customer Identification
    public const string CustomerIdentificationFailed = "customeridentification.failed";
    public const string CustomerIdentificationSuccess = "customeridentification.success";

    // Dedicated Virtual Accounts
    public const string DedicatedAccountAssignFailed = "dedicatedaccount.assign.failed";
    public const string DedicatedAccountAssignSuccess = "dedicatedaccount.assign.success";

    // Invoices
    public const string InvoiceCreate = "invoice.create";
    public const string InvoicePaymentFailed = "invoice.payment_failed";
    public const string InvoiceUpdate = "invoice.update";

    // Payment Requests
    public const string PaymentRequestPending = "paymentrequest.pending";
    public const string PaymentRequestSuccess = "paymentrequest.success";

    // Refunds
    public const string RefundFailed = "refund.failed";
    public const string RefundPending = "refund.pending";
    public const string RefundProcessed = "refund.processed";
    public const string RefundProcessing = "refund.processing";

    // Subscriptions
    public const string SubscriptionCreate = "subscription.create";
    public const string SubscriptionDisable = "subscription.disable";
    public const string SubscriptionExpiringCards = "subscription.expiring_cards";
    public const string SubscriptionNotRenew = "subscription.not_renew";

    // Transfers
    public const string TransferFailed = "transfer.failed";
    public const string TransferSuccess = "transfer.success";
    public const string TransferReversed = "transfer.reversed";
}