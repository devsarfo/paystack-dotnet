namespace Paystack.NET.Constants
{
    /// <summary>
    /// Contains constants for all Paystack webhook event types.
    /// Use these to compare against the <c>event</c> field in webhook payloads.
    /// </summary>
    public static class CallbackEvent
    {
        // Charge Disputes

        /// <summary>
        /// Triggered when a new dispute is created against a charge.
        /// </summary>
        public const string ChargeDisputeCreate = "charge.dispute.create";

        /// <summary>
        /// Triggered as a reminder for an unresolved dispute.
        /// </summary>
        public const string ChargeDisputeRemind = "charge.dispute.remind";

        /// <summary>
        /// Triggered when a dispute is resolved.
        /// </summary>
        public const string ChargeDisputeResolve = "charge.dispute.resolve";

        // Charges

        /// <summary>
        /// Triggered when a charge is successfully completed.
        /// </summary>
        public const string ChargeSuccess = "charge.success";

        // Customer Identification

        /// <summary>
        /// Triggered when customer identification fails (e.g., BVN or KYC check).
        /// </summary>
        public const string CustomerIdentificationFailed = "customeridentification.failed";

        /// <summary>
        /// Triggered when customer identification succeeds.
        /// </summary>
        public const string CustomerIdentificationSuccess = "customeridentification.success";

        // Dedicated Virtual Accounts

        /// <summary>
        /// Triggered when assignment of a dedicated virtual account fails.
        /// </summary>
        public const string DedicatedAccountAssignFailed = "dedicatedaccount.assign.failed";

        /// <summary>
        /// Triggered when assignment of a dedicated virtual account succeeds.
        /// </summary>
        public const string DedicatedAccountAssignSuccess = "dedicatedaccount.assign.success";

        // Invoices

        /// <summary>
        /// Triggered when an invoice is created.
        /// </summary>
        public const string InvoiceCreate = "invoice.create";

        /// <summary>
        /// Triggered when payment for an invoice fails.
        /// </summary>
        public const string InvoicePaymentFailed = "invoice.payment_failed";

        /// <summary>
        /// Triggered when an invoice is updated.
        /// </summary>
        public const string InvoiceUpdate = "invoice.update";

        // Payment Requests

        /// <summary>
        /// Triggered when a payment request is pending.
        /// </summary>
        public const string PaymentRequestPending = "paymentrequest.pending";

        /// <summary>
        /// Triggered when a payment request is successfully paid.
        /// </summary>
        public const string PaymentRequestSuccess = "paymentrequest.success";

        // Refunds

        /// <summary>
        /// Triggered when a refund fails.
        /// </summary>
        public const string RefundFailed = "refund.failed";

        /// <summary>
        /// Triggered when a refund is pending.
        /// </summary>
        public const string RefundPending = "refund.pending";

        /// <summary>
        /// Triggered when a refund is fully processed.
        /// </summary>
        public const string RefundProcessed = "refund.processed";

        /// <summary>
        /// Triggered when a refund is currently processing.
        /// </summary>
        public const string RefundProcessing = "refund.processing";

        // Subscriptions

        /// <summary>
        /// Triggered when a new subscription is created.
        /// </summary>
        public const string SubscriptionCreate = "subscription.create";

        /// <summary>
        /// Triggered when a subscription is disabled.
        /// </summary>
        public const string SubscriptionDisable = "subscription.disable";

        /// <summary>
        /// Triggered when cards tied to a subscription are expiring.
        /// </summary>
        public const string SubscriptionExpiringCards = "subscription.expiring_cards";

        /// <summary>
        /// Triggered when a subscription will not be renewed.
        /// </summary>
        public const string SubscriptionNotRenew = "subscription.not_renew";

        // Transfers

        /// <summary>
        /// Triggered when a transfer fails.
        /// </summary>
        public const string TransferFailed = "transfer.failed";

        /// <summary>
        /// Triggered when a transfer is successful.
        /// </summary>
        public const string TransferSuccess = "transfer.success";

        /// <summary>
        /// Triggered when a transfer is reversed.
        /// </summary>
        public const string TransferReversed = "transfer.reversed";
    }
}