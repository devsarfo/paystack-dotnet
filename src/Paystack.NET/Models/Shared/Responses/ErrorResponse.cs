using Newtonsoft.Json;

namespace Paystack.NET.Models.Shared.Responses
{
    /// <summary>
    /// A generic model that represents the standard response structure from the Paystack API.
    /// This is used for all API responses from Paystack, containing status, message, and the data (payload).
    /// </summary>
    public class ErrorResponse
    {
        /// <summary>
        /// Indicates whether the request was successful or not.
        /// </summary>
        [JsonProperty("status")]
        public bool Status { get; set; }
    
        /// <summary>
        /// This could be a success message or an error message, providing context on the request's result.
        /// </summary>
        [JsonProperty("message")]
        public string Message { get; set; } = string.Empty;
    
        /// <summary>
        /// The error code returned by Paystack.
        /// </summary>
        [JsonProperty("code")]
        public string Code { get; set; } = string.Empty;

        /// <summary>
        /// The type of error, such as validation error.
        /// </summary>
        [JsonProperty("type")]
        public string Type { get; set; } = string.Empty;

        /// <summary>
        /// Any additional metadata returned by Paystack.
        /// </summary>
        [JsonProperty("meta")]
        public ErrorMeta? Meta { get; set; }
    }

    public class ErrorMeta
    {
        /// <summary>
        /// The next step to resolve the error, if available.
        /// </summary>
        [JsonProperty("nextStep")]
        public string? NextStep { get; set; }
    }
}