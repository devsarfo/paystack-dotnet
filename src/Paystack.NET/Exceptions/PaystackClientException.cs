using System;
using Paystack.NET.Models.Shared.Responses;

namespace Paystack.NET.Exceptions
{
    public class PaystackClientException : Exception
    {
        /// <summary>
        /// The error response model containing the details of the error.
        /// </summary>
        public ErrorResponse Error { get; }

        public PaystackClientException(ErrorResponse errorResponse) : base($"{errorResponse.Message} ({errorResponse.Code})")
        {
            Error = errorResponse;
        }
    }
}