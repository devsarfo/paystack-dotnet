using System.Threading.Tasks;
using Paystack.NET.Models.Shared.Responses;
using Paystack.NET.Models.Transactions.Entities;
using Paystack.NET.Models.Transactions.Options;
using Paystack.NET.Models.Transactions.Responses;
using Paystack.NET.Utils;

namespace Paystack.NET.Services.Transaction
{
    public class TransactionService : BaseService, ITransactionService
    {
        public async Task<ApiResponse<InitializeTransactionResponse>> InitializeAsync(InitializeTransactionOptions options)
        {
            return await PaystackClient.PostAsync<InitializeTransactionOptions, ApiResponse<InitializeTransactionResponse>>("transaction/initialize", options);
        }
    
        public async Task<ApiResponse<VerifyTransactionResponse>> VerifyAsync(string reference)
        {
            return await PaystackClient.GetAsync<ApiResponse<VerifyTransactionResponse>>($"transaction/verify/{reference}");
        }
    
        public async Task<PaginatedApiResponse<TransactionResponse>> ListAsync(ListTransactionsOptions? options = null)
        {
            var queryParams = options != null ? options.ToQueryString() : "";
            return await PaystackClient.GetAsync<PaginatedApiResponse<TransactionResponse>>($"transaction{queryParams}");
        }
    
        public async Task<ApiResponse<TransactionResponse>> FetchAsync(string id)
        {
            return await PaystackClient.GetAsync<ApiResponse<TransactionResponse>>($"transaction/{id}");
        }

        public async Task<ApiResponse<TransactionResponse>> ChargeAuthorizationAsync(ChargeAuthorizationOptions options)
        {
            return await PaystackClient.PostAsync<object, ApiResponse<TransactionResponse>>("transaction/charge_authorization", options);
        }

        public async Task<ApiResponse<TransactionLog>> TransactionTimelineAsync(string idOrReference)
        {
            return await PaystackClient.GetAsync<ApiResponse<TransactionLog>>($"transaction/timeline/{idOrReference}");
        }

        public async Task<ApiResponse<TransactionTotalsResponse>> TransactionTotalsAsync()
        {
            return await PaystackClient.GetAsync<ApiResponse<TransactionTotalsResponse>>("transaction/totals");
        }

        public async Task<ApiResponse<ExportTransactionResponse>> ExportTransactionAsync(ExportTransactionOptions? options = null)
        {
            var queryParams = options != null ? options.ToQueryString() : "";
            return await PaystackClient.GetAsync<ApiResponse<ExportTransactionResponse>>($"transaction/export{queryParams}");
        }

        public async Task<ApiResponse<PartialDebitResponse>> PartialDebitAsync(PartialDebitOptions options)
        {
            return await PaystackClient.PostAsync<object, ApiResponse<PartialDebitResponse>>("transaction/partial_debit", options);
        }
    }
}