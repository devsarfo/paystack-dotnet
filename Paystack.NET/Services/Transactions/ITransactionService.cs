using Paystack.NET.Models.Common.Responses;
using Paystack.NET.Models.Transactions.Entities;
using Paystack.NET.Models.Transactions.Options;
using Paystack.NET.Models.Transactions.Responses;

namespace Paystack.NET.Services.Transactions;

public interface ITransactionService
{
    public Task<ApiResponse<InitializeTransactionResponse>> Initialize(InitializeTransactionOptions options);
    
    public Task<ApiResponse<VerifyTransactionResponse>> Verify(string reference);

    public Task<PaginatedApiResponse<TransactionResponse>> List(ListTransactionOptions? options = default);
    
    public Task<ApiResponse<TransactionResponse>> Fetch(string id);
    
    public Task<ApiResponse<TransactionResponse>> ChargeAuthorization(ChargeAuthorizationOptions options);
    
    public Task<ApiResponse<TransactionLog>> TransactionTimeline(string idOrReference);
    
    public Task<ApiResponse<TransactionTotalsResponse>> TransactionTotals();
    
    public Task<ApiResponse<ExportTransactionResponse>> ExportTransaction(ExportTransactionOptions? options = default);
    
    public Task<ApiResponse<PartialDebitResponse>> PartialDebit(PartialDebitOptions options);
}