using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Paystack.NET.Configuration;
using Paystack.NET.Exceptions;
using Paystack.NET.Models.Shared.Responses;

namespace Paystack.NET.Clients
{
    public class PaystackClient : IPaystackClient
    {
        private readonly HttpClient _httpClient;

        public PaystackClient(HttpClient? httpClient = null)
        {
            if (string.IsNullOrWhiteSpace(PaystackConfiguration.ApiKey))
            {
                throw new InvalidOperationException(
                    "Paystack API keys must be configured before using PaystackClient.");
            }

            _httpClient = httpClient ?? new HttpClient
            {
                BaseAddress = new Uri(PaystackConfiguration.BaseUrl)
            };

            _httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {PaystackConfiguration.ApiKey}");
        }

        public async Task<TResponse> GetAsync<TResponse>(string endpoint)
        {
            var response = await _httpClient.GetAsync($"{PaystackConfiguration.BaseUrl}/{endpoint}");
            return await ParseResponse<TResponse>(response);
        }

        public async Task<TResponse> PostAsync<TRequest, TResponse>(string endpoint, TRequest? data = null) where TRequest : class
        {
            var content = new StringContent(data != null ? JsonConvert.SerializeObject(data) : string.Empty,
                Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync($"{PaystackConfiguration.BaseUrl}/{endpoint}", content);
            return await ParseResponse<TResponse>(response);
        }

        public async Task<TResponse> PutAsync<TRequest, TResponse>(string endpoint, TRequest? data = null) where TRequest : class
        {
            var content = new StringContent(data != null ? JsonConvert.SerializeObject(data) : string.Empty,
                Encoding.UTF8, "application/json");
            
            var response = await _httpClient.PutAsync($"{PaystackConfiguration.BaseUrl}/{endpoint}", content);
            return await ParseResponse<TResponse>(response);
        }

        public async Task<TResponse> DeleteAsync<TResponse>(string endpoint)
        {
            var response = await _httpClient.DeleteAsync($"{PaystackConfiguration.BaseUrl}/{endpoint}");
            return await ParseResponse<TResponse>(response);
        }

        private static async Task<TResponse> ParseResponse<TResponse>(HttpResponseMessage response)
        {
            var responseContent = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                var errorResponse = JsonConvert.DeserializeObject<ErrorResponse>(responseContent);
                if (errorResponse is { Status: false })
                {
                    throw new PaystackClientException(errorResponse);
                }
            }

            var result = JsonConvert.DeserializeObject<TResponse>(responseContent);

            if (result == null)
            {
                throw new InvalidOperationException("Failed to deserialize API response.");
            }

            return result;
        }
    }
}