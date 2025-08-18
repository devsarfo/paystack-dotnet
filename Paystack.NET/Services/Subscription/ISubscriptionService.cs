using System.Threading.Tasks;
using Paystack.NET.Models.Shared.Responses;
using Paystack.NET.Models.Subscriptions.Options;
using Paystack.NET.Models.Subscriptions.Responses;

namespace Paystack.NET.Services.Subscription
{
    public interface ISubscriptionService
    {
        public Task<ApiResponse<CreateSubscriptionResponse>> CreateAsync(CreateSubscriptionOptions options);
    }
}