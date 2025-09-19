using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using Newtonsoft.Json;

namespace Paystack.NET.Utils
{
    public static class QueryStringHelper
    {
        /// <summary>
        /// Converts an object with properties into a query string format.
        /// Uses the JsonProperty name if available.
        /// </summary>
        public static string ToQueryString<T>(this T obj) where T : class
        {
            var properties = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            var queryParams = new Dictionary<string, object>();

            foreach (var prop in properties)
            {
                var value = prop.GetValue(obj);
                if (value == null) continue;

                // Get the JsonPropertyAttribute name if it exists; otherwise, use the property name
                var name = prop.GetCustomAttribute<JsonPropertyAttribute>()?.PropertyName ?? prop.Name;

                var stringValue = value switch
                {
                    DateTime dt => dt.ToString("yyyy-MM-ddTHH:mm:ss.fffZ"), // Format DateTime properly
                    _ => value.ToString()
                };

                queryParams[name] = stringValue ?? "";
            }

            return queryParams.Count != 0 
                ? "?" + string.Join("&", queryParams.Select(kvp => $"{HttpUtility.UrlEncode(kvp.Key)}={HttpUtility.UrlEncode(kvp.Value.ToString() ?? "")}")) 
                : string.Empty;
        }
    }
}