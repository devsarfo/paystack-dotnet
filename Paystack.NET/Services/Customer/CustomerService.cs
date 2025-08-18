using System.Threading.Tasks;
using Paystack.NET.Models.Customers.Entities;
using Paystack.NET.Models.Customers.Options;
using Paystack.NET.Models.Customers.Responses;
using Paystack.NET.Models.Shared.Responses;
using Paystack.NET.Utils;

namespace Paystack.NET.Services.Customer
{
    public class CustomerService : BaseService, ICustomerService
    {
        public async Task<ApiResponse<Models.Customers.Entities.Customer>> CreateAsync(CreateCustomerOptions options)
        {
            return await PaystackClient.PostAsync<CreateCustomerOptions, ApiResponse<Models.Customers.Entities.Customer>>("customer", options);
        }
    
        public async Task<PaginatedApiResponse<Models.Customers.Entities.Customer>> ListAsync(ListCustomersOptions? options = null)
        {
            var queryParams = options != null ? options.ToQueryString() : "";
            return await PaystackClient.GetAsync<PaginatedApiResponse<Models.Customers.Entities.Customer>>($"customer{queryParams}");
        }
    
        public async Task<ApiResponse<Models.Customers.Entities.CustomerData>> FetchAsync(string emailOrCode)
        {
            return await PaystackClient.GetAsync<ApiResponse<Models.Customers.Entities.CustomerData>>($"customer/{emailOrCode}");
        }

        public async Task<ApiResponse<Models.Customers.Entities.Customer>> UpdateAsync(string code, UpdateCustomerOptions options)
        {
            return await PaystackClient.PutAsync<UpdateCustomerOptions, ApiResponse<Models.Customers.Entities.Customer>>($"customer/{code}", options);
        }

        public async Task<ApiResponse> ValidateAsync(string code, ValidateCustomerOptions options)
        {
            return await PaystackClient.PostAsync<ValidateCustomerOptions, ApiResponse>($"customer/{code}/identification", options);
        }

        public async Task<ApiResponse<Models.Customers.Entities.Customer>> UpdateRiskActionAsync(CustomerRiskActionOptions options)
        {
            return await PaystackClient.PostAsync<CustomerRiskActionOptions, ApiResponse<Models.Customers.Entities.Customer>>("customer/set_risk_action", options);
        }

        public async Task<ApiResponse<InitializeAuthorizationResponse>> InitializeAuthorizationAsync(InitializeAuthorizationOptions options)
        {
            return await PaystackClient.PostAsync<InitializeAuthorizationOptions, ApiResponse<InitializeAuthorizationResponse>>("customer/authorization/initialize", options);
        }

        public async Task<ApiResponse<CustomerAuthorizationResponse>> VerifyAuthorizationAsync(string reference)
        {
            return await PaystackClient.GetAsync<ApiResponse<CustomerAuthorizationResponse>>($"customer/authorization/verify/{reference}");
        }

        public async Task<ApiResponse<InitializeAuthorizationResponse>> InitializeDirectDebitAsync(string id, InitializeDirectDebitOptions options)
        {
            return await PaystackClient.PostAsync<InitializeDirectDebitOptions, ApiResponse<InitializeAuthorizationResponse>>($"customer/{id}/initialize-direct-debit", options);
        }

        public async Task<ApiResponse> DirectDebitActivationChargeAsync(string id, DirectDebitActivationChargeOptions options)
        {
            return await PaystackClient.PostAsync<DirectDebitActivationChargeOptions, ApiResponse>($"customer/{id}/directdebit-activation-charge", options);
        }

        public async Task<PaginatedApiResponse<CustomerAuthorization>> FetchMandateAuthorizationsAsync(string id, FetchMandateAuthorizationsOptions? options = null)
        {
            var queryParams = options != null ? options.ToQueryString() : "";
            return await PaystackClient.GetAsync<PaginatedApiResponse<CustomerAuthorization>>($"customer/{id}/directdebit-mandate-authorizations{queryParams}");
        }

        public async Task<ApiResponse> DeactivateAuthorizationAsync(DeactivateAuthorizationOptions options)
        {
            return await PaystackClient.PostAsync<DeactivateAuthorizationOptions, ApiResponse>("customer/authorization/deactivate", options);
        }
    }
}