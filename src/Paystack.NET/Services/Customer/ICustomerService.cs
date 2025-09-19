using System.Threading.Tasks;
using Paystack.NET.Models.Customers.Entities;
using Paystack.NET.Models.Customers.Options;
using Paystack.NET.Models.Customers.Responses;
using Paystack.NET.Models.Shared.Responses;

namespace Paystack.NET.Services.Customer
{
    public interface ICustomerService
    {
        public Task<ApiResponse<Models.Customers.Entities.Customer>> CreateAsync(CreateCustomerOptions options);

        public Task<PaginatedApiResponse<Models.Customers.Entities.Customer>> ListAsync(ListCustomersOptions? options = null);

        public Task<ApiResponse<CustomerData>> FetchAsync(string emailOrCode);
    
        public Task<ApiResponse<Models.Customers.Entities.Customer>> UpdateAsync(string code, UpdateCustomerOptions options);
        
        public Task<ApiResponse> ValidateAsync(string code, ValidateCustomerOptions options);
        
        public Task<ApiResponse<Models.Customers.Entities.Customer>> UpdateRiskActionAsync(CustomerRiskActionOptions options);
        
        public Task<ApiResponse<InitializeAuthorizationResponse>> InitializeAuthorizationAsync(InitializeAuthorizationOptions options);
        
        public Task<ApiResponse<CustomerAuthorizationResponse>> VerifyAuthorizationAsync(string reference);
        
        public Task<ApiResponse<InitializeAuthorizationResponse>> InitializeDirectDebitAsync(string id, InitializeDirectDebitOptions options);
        
        public Task<ApiResponse> DirectDebitActivationChargeAsync(string id, DirectDebitActivationChargeOptions options);
        
        public Task<PaginatedApiResponse<CustomerAuthorization>> FetchMandateAuthorizationsAsync(string id, FetchMandateAuthorizationsOptions? options = null);

        public Task<ApiResponse> DeactivateAuthorizationAsync(DeactivateAuthorizationOptions options);
    }
}