using Paystack.NET.Clients;

namespace Paystack.NET.Services
{
    public abstract class BaseService
    {
        protected readonly IPaystackClient PaystackClient = new PaystackClient();
    }
}