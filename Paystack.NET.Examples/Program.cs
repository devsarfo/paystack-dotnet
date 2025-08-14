using Paystack.NET.Configuration;
using Paystack.NET.Examples.Handlers;
using Paystack.NET.Examples.Utils;

var apiKey = InputHelper.GetInput("Enter Paystack Secret Key: ");


// Configure Paystack API Key
PaystackConfiguration.Configure(apiKey);

while (true)
{
    Console.WriteLine("\n--- Paystack Test App ---");
    Console.WriteLine("1. Transactions");
    Console.WriteLine("2. Callback (Webhook)");
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
    catch (Exception e)
    {
        Console.WriteLine($"\nError: {e.Message}\n");
    }

    Console.WriteLine("\nPress the enter key to continue...");
    Console.ReadLine();
}