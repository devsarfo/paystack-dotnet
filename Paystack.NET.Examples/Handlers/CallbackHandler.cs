using System.Globalization;
using System.Net;
using System.Net.Sockets;
using System.Text;
using Paystack.NET.Constants;
using Paystack.NET.Models.Callback.Responses;
using Paystack.NET.Services.Callback;

namespace Paystack.NET.Examples.Handlers;

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
                // A dispute was logged against your business
                break;

            case CallbackEvent.ChargeDisputeRemind:
                // A logged dispute has not been resolved
                break;

            case CallbackEvent.ChargeDisputeResolve:
                // A dispute has been resolved
                break;

            case CallbackEvent.ChargeSuccess:
                // A successful charge was made
                break;

            case CallbackEvent.CustomerIdentificationFailed:
                // Customer ID validation has failed
                break;

            case CallbackEvent.CustomerIdentificationSuccess:
                // Customer ID validation was successful
                break;

            case CallbackEvent.DedicatedAccountAssignFailed:
                // DVA couldn't be created and assigned to a customer
                break;

            case CallbackEvent.DedicatedAccountAssignSuccess:
                // DVA has been successfully created and assigned to a customer
                break;

            case CallbackEvent.InvoiceCreate:
                // An invoice has been created for a subscription
                break;

            case CallbackEvent.InvoicePaymentFailed:
                // A payment for an invoice failed
                break;

            case CallbackEvent.InvoiceUpdate:
                // An invoice has been updated (payment may have succeeded)
                break;

            case CallbackEvent.PaymentRequestPending:
                // A payment request has been sent to a customer
                break;

            case CallbackEvent.PaymentRequestSuccess:
                // A payment request has been paid for
                break;

            case CallbackEvent.RefundFailed:
                // Refund cannot be processed; account credited with refund amount
                break;

            case CallbackEvent.RefundPending:
                // Refund initiated, waiting for processor response
                break;

            case CallbackEvent.RefundProcessed:
                // Refund successfully processed by the processor
                break;

            case CallbackEvent.RefundProcessing:
                // Refund has been received by the processor
                break;

            case CallbackEvent.SubscriptionCreate:
                // A subscription has been created
                break;

            case CallbackEvent.SubscriptionDisable:
                // A subscription on your account has been disabled
                break;

            case CallbackEvent.SubscriptionExpiringCards:
                // Info on subscriptions with cards expiring this month
                break;

            case CallbackEvent.SubscriptionNotRenew:
                // Subscription status changed to non-renewing
                break;

            case CallbackEvent.TransferFailed:
                // A transfer you attempted has failed
                break;

            case CallbackEvent.TransferSuccess:
                // A successful transfer has been completed
                break;

            case CallbackEvent.TransferReversed:
                // A transfer you attempted has been reversed
                break;

            default:
                Console.WriteLine($"[Webhook] Event: {callback.Event} not supported.");
                break;
        }
    }
}