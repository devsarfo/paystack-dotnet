using Newtonsoft.Json;

namespace Paystack.NET.Models.Shared.Responses;

/// <summary>
/// A generic model that represents the paginated response structure from the Paystack API.
/// This is used for all API responses from Paystack, containing status, message, data (payload), and the meta (pagination).
/// </summary>
/// <typeparam name="T">The type of data contained in the response.</typeparam>
public class PaginatedApiResponse<T>
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
    public List<T?> Data { get; set; } = new List<T?>();


    /// <summary>
    /// Metadata about pagination for large sets of transactions.
    /// </summary>
    [JsonProperty("meta")]
    public Meta Meta { get; set; } = new ();
}

/// <summary>
/// Represents metadata for pagination.
/// </summary>
public class Meta
{
    /// <summary>
    /// The next page token for paginated responses.
    /// </summary>
    [JsonProperty("next")]
    public string Next { get; set; } = string.Empty;

    /// <summary>
    /// The previous page token, if available.
    /// </summary>
    [JsonProperty("previous")]
    public string Previous { get; set; } = string.Empty;

    /// <summary>
    /// The number of records per page.
    /// </summary>
    [JsonProperty("perPage")]
    public int PerPage { get; set; }
}