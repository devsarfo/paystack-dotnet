using System.Threading.Tasks;
using Paystack.NET.Models.Shared.Responses;
using Paystack.NET.Models.Transactions.Entities;
using Paystack.NET.Models.Transactions.Options;
using Paystack.NET.Models.Transactions.Responses;

namespace Paystack.NET.Services.Transaction
{
    public interface ITransactionService
    {
        public Task<ApiResponse<InitializeTransactionResponse>> InitializeAsync(InitializeTransactionOptions options);
    
        public Task<ApiResponse<VerifyTransactionResponse>> VerifyAsync(string reference);

        public Task<PaginatedApiResponse<TransactionResponse>> ListAsync(ListTransactionsOptions? options = null);
    
        public Task<ApiResponse<TransactionResponse>> FetchAsync(string id);
    
        public Task<ApiResponse<TransactionResponse>> ChargeAuthorizationAsync(ChargeAuthorizationOptions options);
    
        public Task<ApiResponse<TransactionLog>> TransactionTimelineAsync(string idOrReference);
    
        public Task<ApiResponse<TransactionTotalsResponse>> TransactionTotalsAsync();
    
        public Task<ApiResponse<ExportTransactionResponse>> ExportTransactionAsync(ExportTransactionOptions? options = null);
    
        public Task<ApiResponse<PartialDebitResponse>> PartialDebitAsync(PartialDebitOptions options);
    }
}