using Paystack.NET.Configuration;
using Paystack.NET.Examples.Handlers;
using Paystack.NET.Examples.Utils;
using Paystack.NET.Exceptions;

var apiKey = InputHelper.GetInput("Enter Paystack Secret Key: ");

// Configure Paystack API Key
PaystackConfiguration.Configure(apiKey);

while (true)
{
    Console.WriteLine("\n--- Paystack Test App ---");
    Console.WriteLine("1. Transactions");
    Console.WriteLine("2. Customers");
    Console.WriteLine("3. Plans");
    Console.WriteLine("4. Subscriptions");
    Console.WriteLine("5. Callback (Webhook)");
    Console.WriteLine("Q. Quit");
    Console.Write("Select an option: ");

    var choice = Console.ReadLine()?.Trim();

    Console.Clear();

    try
    {
        switch (choice)
        {
            case "1":
                var transactionHandler = new TransactionHandler();
                await transactionHandler.Init();
                break;
            case "2":
                var customerHandler = new CustomerHandler();
                await customerHandler.Init();
                break;
            case "3":
                var planHandler = new PlanHandler();
                await planHandler.Init();
                break;
            case "4":
                var subscriptionHandler = new SubscriptionHandler();
                await subscriptionHandler.Init();
                break;
            case "5":
                var callbackHandler = new CallbackHandler();
                await callbackHandler.Init();
                break;
            case "q" or "Q":
                Console.WriteLine("Exiting application...");
                return;
            default:
                Console.WriteLine("Invalid option. Please try again.");
                break;
        }
    }
    catch (PaystackClientException e)
    {
        Console.WriteLine($"\nPaystack Error: {e.Error.Message}\n");
    }
    catch (Exception e)
    {
        Console.WriteLine($"\nError: {e.Message}\n");
    }


    Console.WriteLine("\nPress the enter key to continue...");
    Console.ReadLine();
}