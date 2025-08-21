using System.Threading.Tasks;
using Paystack.NET.Models.Shared.Responses;
using Paystack.NET.Models.Subscriptions.Entities;
using Paystack.NET.Models.Subscriptions.Options;
using Paystack.NET.Models.Subscriptions.Responses;

namespace Paystack.NET.Services.Subscription
{
    public interface ISubscriptionService
    {
        public Task<ApiResponse<CreateSubscriptionResponse>> CreateAsync(CreateSubscriptionOptions options);
        
        public Task<PaginatedApiResponse<Models.Subscriptions.Entities.Subscription>> ListAsync(ListSubscriptionsOptions? options = null);
        
        public Task<ApiResponse<SubscriptionData>> FetchAsync(string idOrCode);

        public Task<ApiResponse> EnableAsync(EnableSubscriptionOptions options);
        
        public Task<ApiResponse> DisableAsync(DisableSubscriptionOptions options);
        
        public Task<ApiResponse<UpdateSubscriptionLinkResponse>> GenerateUpdateSubscriptionLinkAsync(string idOrCode);
        
        public Task<ApiResponse> SendUpdateSubscriptionLinkAsync(string idOrCode);
    }
}