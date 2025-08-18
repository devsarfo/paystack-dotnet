using System.Threading.Tasks;
using Paystack.NET.Models.Plans.Entities;
using Paystack.NET.Models.Plans.Options;
using Paystack.NET.Models.Shared.Responses;

namespace Paystack.NET.Services.Plan
{
    public interface IPlanService
    {
        public Task<ApiResponse<Models.Plans.Entities.Plan>> CreateAsync(CreatePlanOptions options);
        
        public Task<PaginatedApiResponse<PlanListData>> ListAsync(ListPlansOptions? options = null);
        
        public Task<ApiResponse<PlanData>> FetchAsync(string idOrCode);
        
        public Task<ApiResponse> UpdateAsync(string code, UpdatePlanOptions options);
    }
}