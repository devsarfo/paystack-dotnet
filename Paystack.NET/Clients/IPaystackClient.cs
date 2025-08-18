using System.Threading.Tasks;

namespace Paystack.NET.Clients
{
    public interface IPaystackClient
    {
        Task<TResponse> GetAsync<TResponse>(string endpoint);
        Task<TResponse> PostAsync<TRequest, TResponse>(string endpoint, TRequest? data = null) where TRequest : class;
        Task<TResponse> PutAsync<TRequest, TResponse>(string endpoint, TRequest? data = null) where TRequest : class;
        Task<TResponse> DeleteAsync<TResponse>(string endpoint);
    }
}