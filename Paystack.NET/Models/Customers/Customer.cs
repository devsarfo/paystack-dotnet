using Newtonsoft.Json;

namespace Paystack.NET.Models.Customers;

/// <summary>
/// Represents a customer involved in a Paystack transaction,  
/// including their contact details and unique customer code.
/// </summary>
public class Customer
{
    /// <summary>
    /// The unique identifier for the customer.
    /// </summary>
    [JsonProperty("id")]
    public int Id { get; set; }

    /// <summary>
    /// The first name of the customer (if available).
    /// </summary>
    [JsonProperty("first_name")]
    public string? FirstName { get; set; }

    /// <summary>
    /// The last name of the customer (if available).
    /// </summary>
    [JsonProperty("last_name")]
    public string? LastName { get; set; }

    /// <summary>
    /// The email address associated with the customer.
    /// </summary>
    [JsonProperty("email")]
    public string Email { get; set; } = string.Empty;

    /// <summary>
    /// The phone number of the customer (if available).
    /// </summary>
    [JsonProperty("phone")]
    public string? Phone { get; set; }

    /// <summary>
    /// Additional metadata related to the customer.
    /// </summary>
    [JsonProperty("metadata")]
    public CustomerMetadata Metadata { get; set; } = new();

    /// <summary>
    /// A unique code assigned to the customer by Paystack.
    /// </summary>
    [JsonProperty("customer_code")]
    public string CustomerCode { get; set; } = string.Empty;

    /// <summary>
    /// The risk action associated with the customer (e.g., "default").
    /// </summary>
    [JsonProperty("risk_action")]
    public string RiskAction { get; set; } = string.Empty;
    
    /// <summary>
    /// The international format phone for the customer.
    /// </summary>
    [JsonProperty("international_format_phone")]
    public string? InternationalFormatPhone { get; set; }
}

/// <summary>
/// Represents the metadata for a customer.
/// </summary>
public class CustomerMetadata
{
    /// <summary>
    /// A list of custom fields associated with the customer.
    /// </summary>
    [JsonProperty("custom_fields")]
    public List<CustomField>? CustomFields { get; set; }
}

/// <summary>
/// Represents a custom field within customer metadata.
/// </summary>
public class CustomField
{
    /// <summary>
    /// The display name of the custom field.
    /// </summary>
    [JsonProperty("display_name")]
    public string DisplayName { get; set; } = string.Empty;

    /// <summary>
    /// The variable name of the custom field.
    /// </summary>
    [JsonProperty("variable_name")]
    public string VariableName { get; set; } = string.Empty;

    /// <summary>
    /// The value of the custom field.
    /// </summary>
    [JsonProperty("value")]
    public string Value { get; set; } = string.Empty;
}