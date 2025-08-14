using Paystack.NET.Models.Shared.Responses;
using Paystack.NET.Models.Transactions.Entities;
using Paystack.NET.Models.Transactions.Options;
using Paystack.NET.Models.Transactions.Responses;
using Paystack.NET.Utils;

namespace Paystack.NET.Services.Transaction;

public class TransactionService : BaseService, ITransactionService
{
    public async Task<ApiResponse<InitializeTransactionResponse>> Initialize(InitializeTransactionOptions options)
    {
        return await PaystackClient.PostAsync<InitializeTransactionOptions, ApiResponse<InitializeTransactionResponse>>("transaction/initialize", options);
    }
    
    public async Task<ApiResponse<VerifyTransactionResponse>> Verify(string reference)
    {
        return await PaystackClient.GetAsync<ApiResponse<VerifyTransactionResponse>>($"transaction/verify/{reference}");
    }
    
    public async Task<PaginatedApiResponse<TransactionResponse>> List(ListTransactionOptions? options = null)
    {
        var queryParams = (options is not null) ? options.ToQueryString() : "";
        return await PaystackClient.GetAsync<PaginatedApiResponse<TransactionResponse>>($"transaction{queryParams}");
    }
    
    public async Task<ApiResponse<TransactionResponse>> Fetch(string id)
    {
        return await PaystackClient.GetAsync<ApiResponse<TransactionResponse>>($"transaction/{id}");
    }

    public async Task<ApiResponse<TransactionResponse>> ChargeAuthorization(ChargeAuthorizationOptions options)
    {
        return await PaystackClient.PostAsync<object, ApiResponse<TransactionResponse>>($"transaction/charge_authorization", options);
    }

    public async Task<ApiResponse<TransactionLog>> TransactionTimeline(string idOrReference)
    {
        return await PaystackClient.GetAsync<ApiResponse<TransactionLog>>($"transaction/timeline/{idOrReference}");
    }

    public async Task<ApiResponse<TransactionTotalsResponse>> TransactionTotals()
    {
        return await PaystackClient.GetAsync<ApiResponse<TransactionTotalsResponse>>($"transaction/totals");
    }

    public async Task<ApiResponse<ExportTransactionResponse>> ExportTransaction(ExportTransactionOptions? options = null)
    {
        var queryParams = options is not null ? options.ToQueryString() : "";
        return await PaystackClient.GetAsync<ApiResponse<ExportTransactionResponse>>($"transaction/export{queryParams}");
    }

    public async Task<ApiResponse<PartialDebitResponse>> PartialDebit(PartialDebitOptions options)
    {
        return await PaystackClient.PostAsync<object, ApiResponse<PartialDebitResponse>>($"transaction/partial_debit", options);
    }
}