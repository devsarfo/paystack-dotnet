using Paystack.NET.Configuration;
using Paystack.NET.Examples.Handlers;
using Paystack.NET.Examples.Utils;

var apiKey = InputHelper.GetInput("Enter Paystack Secret Key: ");

// Configure Paystack API Key
PaystackConfiguration.Configure(apiKey);

// Initialize Handlers
var transactionHandler = new TransactionHandler();

while (true)
{
    Console.WriteLine("\n--- Paystack Test App ---");
    Console.WriteLine("1. Initialize Transaction");
    Console.WriteLine("2. Verify Transaction");
    Console.WriteLine("3. List Transactions");
    Console.WriteLine("4. Fetch Transaction");
    Console.WriteLine("5. Charge Authorization");
    Console.WriteLine("6. Transaction Timeline");
    Console.WriteLine("7. Transaction Totals");
    Console.WriteLine("8. Export Transaction");
    Console.WriteLine("9. Partial Debit");
    Console.WriteLine("Q. Quit");
    Console.Write("Select an option: ");

    var choice = Console.ReadLine()?.Trim();
    
    Console.Clear();
    
    try
    {
        switch (choice)
        {
            case "1":
                Console.WriteLine("--- Initialize Transaction ---\n");
                await transactionHandler.InitializeTransaction();
                break;
            case "2":
                Console.WriteLine("--- Verify Transaction ---\n");
                await transactionHandler.VerifyTransaction();
                break;
            case "3":
                Console.WriteLine("--- List Transactions---\n");
                await transactionHandler.ListTransactions();
                break;
            case "4":
                Console.WriteLine("--- Get Transaction ---\n");
                await transactionHandler.GetTransaction();
                break;
            case "5":
                Console.WriteLine("--- Charge Authorization ---\n");
                await transactionHandler.ChargeAuthorization();
                break;
            case "6":
                Console.WriteLine("--- Transaction Timeline ---\n");
                await transactionHandler.TransactionTimeline();
                break;
            case "7":
                Console.WriteLine("--- Transaction Totals ---\n");
                await transactionHandler.TransactionTotals();
                break;
            case "8":
                Console.WriteLine("--- Export Transaction ---\n");
                await transactionHandler.ExportTransaction();
                break;
            case "9":
                Console.WriteLine("--- Partial Debit ---\n");
                await transactionHandler.PartialDebit();
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