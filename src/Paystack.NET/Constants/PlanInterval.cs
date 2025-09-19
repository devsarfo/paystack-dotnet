namespace Paystack.NET.Constants
{
    /// <summary>
    /// Defines valid billing intervals for a Paystack plan.
    /// </summary>
    public static class PlanInterval
    {
        /// <summary>
        /// Daily billing interval.
        /// </summary>
        public const string Daily = "daily";

        /// <summary>
        /// Weekly billing interval.
        /// </summary>
        public const string Weekly = "weekly";

        /// <summary>
        /// Monthly billing interval.
        /// </summary>
        public const string Monthly = "monthly";

        /// <summary>
        /// Quarterly billing interval (every 3 months).
        /// </summary>
        public const string Quarterly = "quarterly";

        /// <summary>
        /// Biannual billing interval (every 6 months).
        /// </summary>
        public const string Biannually = "biannually";

        /// <summary>
        /// Annual billing interval (once a year).
        /// </summary>
        public const string Annually = "annually";
    }
}