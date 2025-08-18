using System.Threading.Tasks;
using Paystack.NET.Models.Plans.Entities;
using Paystack.NET.Models.Plans.Options;
using Paystack.NET.Models.Shared.Responses;
using Paystack.NET.Utils;

namespace Paystack.NET.Services.Plan
{
    public class PlanService : BaseService, IPlanService
    {
        public async Task<ApiResponse<Models.Plans.Entities.Plan>> CreateAsync(CreatePlanOptions options)
        {
            return await PaystackClient.PostAsync<CreatePlanOptions, ApiResponse<Models.Plans.Entities.Plan>>("plan", options);
        }

        public async Task<PaginatedApiResponse<PlanListData>> ListAsync(ListPlansOptions? options = null)
        {
            var queryParams = options != null ? options.ToQueryString() : "";
            return await PaystackClient.GetAsync<PaginatedApiResponse<Models.Plans.Entities.PlanListData>>($"plan{queryParams}");
        }

        public async Task<ApiResponse<PlanData>> FetchAsync(string idOrCode)
        {
            return await PaystackClient.GetAsync<ApiResponse<PlanData>>($"plan/{idOrCode}");
        }

        public async Task<ApiResponse> UpdateAsync(string code, UpdatePlanOptions options)
        {
            return await PaystackClient.PutAsync<UpdatePlanOptions, ApiResponse>($"plan/{code}", options);
        }
    }
}