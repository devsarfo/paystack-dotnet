using Paystack.NET.Clients;

namespace Paystack.NET.Services._base;

public abstract class BaseService
{
    protected readonly PaystackClient PaystackClient = new();
}