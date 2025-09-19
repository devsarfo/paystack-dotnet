using Paystack.NET.Configuration;
using Paystack.NET.Examples.Handlers;
using Sharprompt;

using var cts = new CancellationTokenSource();

// Optional: allow Ctrl+C to cancel
Console.CancelKeyPress += (s, e) =>
{
    Console.WriteLine("Cancellation requested...");
    cts.Cancel();
    e.Cancel = true;
};

var apiKey = Prompt.Input<string>("Enter Paystack Secret Key", validators: [Validators.Required()]);

// Configure Paystack API Key
PaystackConfiguration.Configure(apiKey);

while (!cts.Token.IsCancellationRequested)
{
    Console.Clear();
    Console.WriteLine("--- Paystack Test App ---");
    
    var option = Prompt.Select("Select an option", [
        "Transactions",
        "Customers",
        "Plans",
        "Subscriptions",
        "Callback (Webhook)",
        "Quit"
    ]);

    switch (option)
    {
        case "Transactions":
            var transactionHandler = new TransactionHandler();
            await transactionHandler.Init();
            break;
        case "Customers":
            var customerHandler = new CustomerHandler();
            await customerHandler.Init();
            break;
        case "Plans":
            var planHandler = new PlanHandler();
            await planHandler.Init();
            break;
        case "Subscriptions":
            var subscriptionHandler = new SubscriptionHandler();
            await subscriptionHandler.Init();
            break;
        case "Callback (Webhook)":
            var callbackHandler = new CallbackHandler();
            await callbackHandler.Init();
            break;
        case "Quit":
            Console.WriteLine("Exiting application...");
            return;
        default:
            Console.WriteLine("Invalid option. Please try again.");
            break;
    }

    Console.WriteLine("\nPress any key to continue...");
    Console.ReadKey();
}