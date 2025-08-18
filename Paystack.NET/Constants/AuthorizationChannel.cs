namespace Paystack.NET.Constants
{
    /// <summary>
    /// Defines available authorization channels used in payment processing.
    /// </summary>
    public static class AuthorizationChannel
    {
        /// <summary>
        /// Direct debit channel, typically used for recurring charges or automated withdrawals.
        /// </summary>
        public const string DirectDebit = "direct_debit";
    }
}