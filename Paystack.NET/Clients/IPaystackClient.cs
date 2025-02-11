namespace Paystack.NET.Clients
{
    public interface IPaystackClient
    {
        Task<TResponse> GetAsync<TResponse>(string endpoint);
        Task<TResponse> PostAsync<TRequest, TResponse>(string endpoint, TRequest? data = default);
        Task<TResponse> PutAsync<TRequest, TResponse>(string endpoint, TRequest? data = default);
        Task<TResponse> DeleteAsync<TResponse>(string endpoint);
    }
}