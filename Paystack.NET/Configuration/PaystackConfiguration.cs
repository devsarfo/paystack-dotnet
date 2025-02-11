namespace Paystack.NET.Configuration
{
    public static class PaystackConfiguration
    {
        /// <summary>
        /// The Paystack secret API key used for authentication.
        /// </summary>
        public static string ApiKey { get; private set; } = string.Empty;

        /// <summary>
        /// The base URL for Paystack API (can be overridden for testing).
        /// </summary>
        public static string BaseUrl { get; private set; } = "https://api.paystack.co";

        /// <summary>
        /// Set the API key and optionally override the base URL.
        /// </summary>
        public static void Configure(string apiKey, string? baseUrl = null)
        {
            if (string.IsNullOrWhiteSpace(apiKey))
            {
                throw new ArgumentException("Paystack secret API key cannot be null or empty.", nameof(apiKey));
            }

            ApiKey = apiKey;

            if (!string.IsNullOrWhiteSpace(baseUrl))
            {
                BaseUrl = baseUrl;
            }
        }
    }
}