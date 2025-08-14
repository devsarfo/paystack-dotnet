using Newtonsoft.Json;

namespace Paystack.NET.Models.Shared.Responses;

/// <summary>
/// A generic model that represents the standard response structure from the Paystack API.
/// This is used for all API responses from Paystack, containing status, message, and the data (payload).
/// </summary>
/// <typeparam name="T">The type of data contained in the response.</typeparam>
public class ApiResponse<T>
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
    /// This is the actual content of the response, and its type depends on the API endpoint called.
    /// It can be a complex object or a simple value, depending on the request made.
    /// </summary>
    [JsonProperty("data")]
    public T? Data { get; set; }
}