namespace Paystack.NET.Constants
{
    /// <summary>
    /// Defines the possible risk actions that can be applied to a customer.
    /// </summary>
    public static class RiskAction
    {
        /// <summary>
        /// Default risk behavior (Paystack decides the appropriate action).
        /// </summary>
        public const string Default = "default";

        /// <summary>
        /// Explicitly allow the customer to make payments.
        /// </summary>
        public const string Allow = "allow";

        /// <summary>
        /// Deny the customer from making payments.
        /// </summary>
        public const string Deny = "deny";
    }
}