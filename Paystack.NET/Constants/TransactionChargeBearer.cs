namespace Paystack.NET.Constants
{
    /// <summary>
    /// Defines the possible entities that can bear transaction charges in Paystack transactions.
    /// </summary>
    public static class TransactionChargeBearer
    {
        /// <summary>
        /// The main account bears the transaction charges.
        /// </summary>
        public const string Account = "account";

        /// <summary>
        /// A subaccount bears the transaction charges.
        /// </summary>
        public const string SubAccount = "subaccount";
    }
}