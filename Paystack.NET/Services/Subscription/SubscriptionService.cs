using System.Threading.Tasks;
using Paystack.NET.Models.Shared.Responses;
using Paystack.NET.Models.Subscriptions.Options;
using Paystack.NET.Models.Subscriptions.Responses;

namespace Paystack.NET.Services.Subscription
{
    public class SubscriptionService: BaseService, ISubscriptionService
    {
        public async Task<ApiResponse<CreateSubscriptionResponse>> CreateAsync(CreateSubscriptionOptions options)
        {
            return await PaystackClient.PostAsync<CreateSubscriptionOptions, ApiResponse<CreateSubscriptionResponse>>("subscription", options);
        }
    }
}