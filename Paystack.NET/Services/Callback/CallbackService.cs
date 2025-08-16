using System;
using System.Security.Cryptography;
using System.Text;
using Newtonsoft.Json;
using Paystack.NET.Configuration;
using Paystack.NET.Models.Callback.Responses;

namespace Paystack.NET.Services.Callback
{
    public class CallbackService : BaseService, ICallbackService
    {
        public void VerifyPayload(string body, string signature)
        {
            using var hmac = new HMACSHA512(Encoding.UTF8.GetBytes(PaystackConfiguration.ApiKey));
            var hashBytes = hmac.ComputeHash(Encoding.UTF8.GetBytes(body));
            var computedSignature = BitConverter.ToString(hashBytes).Replace("-", "").ToLowerInvariant();

            if (!string.Equals(signature.ToLowerInvariant(), computedSignature, StringComparison.Ordinal))
                throw new UnauthorizedAccessException("Invalid Paystack Signature.");
        }

        public CallbackResponse HandleCallback(string body, string signature)
        {
            VerifyPayload(body, signature);

            var results = JsonConvert.DeserializeObject<CallbackResponse>(body);
            if (results is null)
            {
                throw new InvalidOperationException("Failed to deserialize callback payload.");
            }

            return results;
        }
    }
}