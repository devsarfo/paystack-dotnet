using Paystack.NET.Models.Callback.Responses;

namespace Paystack.NET.Services.Callback
{
    public interface ICallbackService
    { 
        void VerifyPayload(string body, string signature);
    
        CallbackResponse HandleCallback(string body, string signature);
    }
}