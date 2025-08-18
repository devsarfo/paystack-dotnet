using System.Globalization;
using System.Net;
using System.Net.Sockets;
using System.Text;
using Paystack.NET.Constants;
using Paystack.NET.Models.Callback.Responses;
using Paystack.NET.Services.Callback;

namespace Paystack.NET.Examples.Handlers
{
    public class CallbackHandler
    {
        private readonly CallbackService _callbackService = new();

        public async Task Init(CancellationToken cancellationToken = default)
        {
            // Get a random free port
            using var tempTcp = new TcpListener(IPAddress.Loopback, 0);
            tempTcp.Start();
            var port = ((IPEndPoint)tempTcp.LocalEndpoint).Port;
            tempTcp.Stop();

            // Configure HTTP listener
            using var listener = new HttpListener();
            listener.Prefixes.Add($"http://localhost:{port}/callback/");
            listener.Start();

            Console.WriteLine("--- Starting Callback (Webhook) Server ---\n");
            Console.WriteLine($"Callback server listening at http://localhost:{port}/callback");
            Console.WriteLine("Press Ctrl+C to stop...\n");

            try
            {
                while (!cancellationToken.IsCancellationRequested)
                {
                    var contextTask = listener.GetContextAsync();
                    var completedTask = await Task.WhenAny(contextTask, Task.Delay(-1, cancellationToken));

                    if (completedTask != contextTask) continue;

                    var context = contextTask.Result;
                    var request = context.Request;
                    var response = context.Response;

                    // Only handle POST requests
                    if (request.HttpMethod != "POST")
                    {
                        response.StatusCode = 405;
                        response.Close();
                        continue;
                    }

                    using var reader = new StreamReader(request.InputStream, request.ContentEncoding);
                    var body = await reader.ReadToEndAsync(cancellationToken);

                    var signatureHeader = request.Headers["X-Paystack-Signature"] ?? string.Empty;

                    try
                    {
                        // Verify signature and parse callback
                        var callback = _callbackService.HandleCallback(body, signatureHeader);

                        // Log
                        Console.WriteLine($"[Callback] Event: {callback.Event}");
                        Console.WriteLine($"[Callback] Data: {callback.Data}");
                        Console.WriteLine($"[Callback] Time: {DateTime.UtcNow.ToString(CultureInfo.InvariantCulture)}");
                        Console.WriteLine("-------\n");

                        // Process callback here
                        HandleCallbackAsync(callback);

                        // Respond 200 OK immediately
                        response.StatusCode = 200;
                        response.ContentType = "application/json";
                        var responseMessage = Encoding.UTF8.GetBytes("{\"success\":true}");
                        await response.OutputStream.WriteAsync(responseMessage, cancellationToken);
                        response.Close();
                    }
                    catch (UnauthorizedAccessException)
                    {
                        response.StatusCode = 403;
                        response.Close();
                        Console.WriteLine("[Webhook] Invalid signature detected.");
                    }
                    catch (Exception ex)
                    {
                        response.StatusCode = 500;
                        response.Close();
                        Console.WriteLine($"[Webhook] Error processing request: {ex.Message}");
                    }
                }
            }
            catch (OperationCanceledException)
            {
                Console.WriteLine("Callback server stopped.");
            }
            finally
            {
                listener.Stop();
            }
        }

        private static void HandleCallbackAsync(CallbackResponse callback)
        {
            switch (callback.Event)
            {
                case CallbackEvent.ChargeDisputeCreate:
                    Console.WriteLine("[Webhook] Dispute created. Data: " + callback.Data);
                    break;

                case CallbackEvent.ChargeDisputeRemind:
                    Console.WriteLine("[Webhook] Dispute reminder. Data: " + callback.Data);
                    break;

                case CallbackEvent.ChargeDisputeResolve:
                    Console.WriteLine("[Webhook] Dispute resolved. Data: " + callback.Data);
                    break;

                case CallbackEvent.ChargeSuccess:
                    Console.WriteLine("[Webhook] Charge successful. Data: " + callback.Data);
                    break;

                case CallbackEvent.CustomerIdentificationFailed:
                    Console.WriteLine("[Webhook] Customer identification failed. Data: " + callback.Data);
                    break;

                case CallbackEvent.CustomerIdentificationSuccess:
                    Console.WriteLine("[Webhook] Customer identification successful. Data: " + callback.Data);
                    break;

                case CallbackEvent.DedicatedAccountAssignFailed:
                    Console.WriteLine("[Webhook] DVA assignment failed. Data: " + callback.Data);
                    break;

                case CallbackEvent.DedicatedAccountAssignSuccess:
                    Console.WriteLine("[Webhook] DVA assignment succeeded. Data: " + callback.Data);
                    break;

                case CallbackEvent.InvoiceCreate:
                    Console.WriteLine("[Webhook] Invoice created. Data: " + callback.Data);
                    break;

                case CallbackEvent.InvoicePaymentFailed:
                    Console.WriteLine("[Webhook] Invoice payment failed. Data: " + callback.Data);
                    break;

                case CallbackEvent.InvoiceUpdate:
                    Console.WriteLine("[Webhook] Invoice updated. Data: " + callback.Data);
                    break;

                case CallbackEvent.PaymentRequestPending:
                    Console.WriteLine("[Webhook] Payment request pending. Data: " + callback.Data);
                    break;

                case CallbackEvent.PaymentRequestSuccess:
                    Console.WriteLine("[Webhook] Payment request successful. Data: " + callback.Data);
                    break;

                case CallbackEvent.RefundFailed:
                    Console.WriteLine("[Webhook] Refund failed. Data: " + callback.Data);
                    break;

                case CallbackEvent.RefundPending:
                    Console.WriteLine("[Webhook] Refund pending. Data: " + callback.Data);
                    break;

                case CallbackEvent.RefundProcessed:
                    Console.WriteLine("[Webhook] Refund processed. Data: " + callback.Data);
                    break;

                case CallbackEvent.RefundProcessing:
                    Console.WriteLine("[Webhook] Refund processing. Data: " + callback.Data);
                    break;

                case CallbackEvent.SubscriptionCreate:
                    Console.WriteLine("[Webhook] Subscription created. Data: " + callback.Data);
                    break;

                case CallbackEvent.SubscriptionDisable:
                    Console.WriteLine("[Webhook] Subscription disabled. Data: " + callback.Data);
                    break;

                case CallbackEvent.SubscriptionExpiringCards:
                    Console.WriteLine("[Webhook] Subscription with expiring cards. Data: " + callback.Data);
                    break;

                case CallbackEvent.SubscriptionNotRenew:
                    Console.WriteLine("[Webhook] Subscription not renewing. Data: " + callback.Data);
                    break;

                case CallbackEvent.TransferFailed:
                    Console.WriteLine("[Webhook] Transfer failed. Data: " + callback.Data);
                    break;

                case CallbackEvent.TransferSuccess:
                    Console.WriteLine("[Webhook] Transfer successful. Data: " + callback.Data);
                    break;

                case CallbackEvent.TransferReversed:
                    Console.WriteLine("[Webhook] Transfer reversed. Data: " + callback.Data);
                    break;

                default:
                    Console.WriteLine($"[Webhook] Event: {callback.Event} not supported. Data: {callback.Data}");
                    break;
            }
        }
    }
}