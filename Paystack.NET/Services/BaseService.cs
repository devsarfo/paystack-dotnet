using Paystack.NET.Clients;

namespace Paystack.NET.Services;

public abstract class BaseService
{
    protected readonly PaystackClient PaystackClient = new();
}