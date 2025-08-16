using Newtonsoft.Json;

namespace Paystack.NET.Models.Shared.Entities
{
    public class CustomField
    {
        /// <summary>
        /// Display name of the custom field (visible on the dashboard).
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
}