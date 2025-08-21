using System.Threading.Tasks;
using Paystack.NET.Models.Shared.Responses;
using Paystack.NET.Models.Subscriptions.Entities;
using Paystack.NET.Models.Subscriptions.Options;
using Paystack.NET.Models.Subscriptions.Responses;
using Paystack.NET.Utils;

namespace Paystack.NET.Services.Subscription
{
    public class SubscriptionService: BaseService, ISubscriptionService
    {
        public async Task<ApiResponse<CreateSubscriptionResponse>> CreateAsync(CreateSubscriptionOptions options)
        {
            return await PaystackClient.PostAsync<CreateSubscriptionOptions, ApiResponse<CreateSubscriptionResponse>>("subscription", options);
        }

        public async Task<PaginatedApiResponse<Models.Subscriptions.Entities.Subscription>> ListAsync(ListSubscriptionsOptions? options = null)
        {
            var queryParams = options != null ? options.ToQueryString() : "";
            return await PaystackClient.GetAsync<PaginatedApiResponse<Models.Subscriptions.Entities.Subscription>>($"subscription{queryParams}");
        }

        public async Task<ApiResponse<SubscriptionData>> FetchAsync(string idOrCode)
        {
            return await PaystackClient.GetAsync<ApiResponse<SubscriptionData>>($"subscription/{idOrCode}");
        }

        public async Task<ApiResponse> EnableAsync(EnableSubscriptionOptions options)
        {
            return await PaystackClient.PostAsync<EnableSubscriptionOptions, ApiResponse>("subscription/enable", options);
        }

        public async Task<ApiResponse> DisableAsync(DisableSubscriptionOptions options)
        {
            return await PaystackClient.PostAsync<DisableSubscriptionOptions, ApiResponse>("subscription/disable", options);
        }

        public async Task<ApiResponse<UpdateSubscriptionLinkResponse>> GenerateUpdateSubscriptionLinkAsync(string idOrCode)
        {
            return await PaystackClient.GetAsync<ApiResponse<UpdateSubscriptionLinkResponse>>($"subscription/{idOrCode}/manage/link");
        }

        public async Task<ApiResponse> SendUpdateSubscriptionLinkAsync(string idOrCode)
        {
            return await PaystackClient.PostAsync<string, ApiResponse>($"subscription/{idOrCode}/manage/email");
        }
    }
}