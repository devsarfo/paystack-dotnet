using Newtonsoft.Json;
using Paystack.NET.Constants;
using Paystack.NET.Examples.Utils;
using Paystack.NET.Models.Transactions.Options;
using Paystack.NET.Services.Transaction;

namespace Paystack.NET.Examples.Handlers;

public class TransactionHandler
{
    private readonly TransactionService _transactionService = new();

    public async Task Init()
    {
        Console.WriteLine("\n--- Transactions ---");
        Console.WriteLine("1. Initialize Transaction");
        Console.WriteLine("2. Verify Transaction");
        Console.WriteLine("3. List Transactions");
        Console.WriteLine("4. Fetch Transaction");
        Console.WriteLine("5. Charge Authorization");
        Console.WriteLine("6. Transaction Timeline");
        Console.WriteLine("7. Transaction Totals");
        Console.WriteLine("8. Export Transaction");
        Console.WriteLine("9. Partial Debit");
        Console.Write("Select an option: ");

        var choice = Console.ReadLine()?.Trim();

        Console.Clear();

        try
        {
            switch (choice)
            {
                case "1":
                    Console.WriteLine("--- Initialize Transaction ---\n");
                    await InitializeTransaction();
                    break;
                case "2":
                    Console.WriteLine("--- Verify Transaction ---\n");
                    await VerifyTransaction();
                    break;
                case "3":
                    Console.WriteLine("--- List Transactions---\n");
                    await ListTransactions();
                    break;
                case "4":
                    Console.WriteLine("--- Get Transaction ---\n");
                    await GetTransaction();
                    break;
                case "5":
                    Console.WriteLine("--- Charge Authorization ---\n");
                    await ChargeAuthorization();
                    break;
                case "6":
                    Console.WriteLine("--- Transaction Timeline ---\n");
                    await TransactionTimeline();
                    break;
                case "7":
                    Console.WriteLine("--- Transaction Totals ---\n");
                    await TransactionTotals();
                    break;
                case "8":
                    Console.WriteLine("--- Export Transaction ---\n");
                    await ExportTransaction();
                    break;
                case "9":
                    Console.WriteLine("--- Partial Debit ---\n");
                    await PartialDebit();
                    break;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }
        catch (Exception e)
        {
            Console.WriteLine($"\nError: {e.Message}\n");
        }
    }

    private async Task InitializeTransaction()
    {
        var email = InputHelper.GetInput("Enter E-mail Address: ");
        var amount = InputHelper.GetInput("Enter Amount (in subunit): ");
        var reference = "TEST-" + DateTime.Now.ToString("yyyyMMddHHmmss");

        var response = await _transactionService.Initialize(new InitializeTransactionOptions
        {
            Amount = amount,
            Email = email,
            Reference = reference,
            CallbackUrl = "https://webhook.site/42b1086b-4443-4e79-a7f6-61f41965fd9b"
        });

        if (response.Status)
        {
            Console.WriteLine($"\nTransaction Initialized Successfully!");
            Console.WriteLine($"Authorization URL: {response.Data?.AuthorizationUrl}");
            Console.WriteLine($"Access Code: {response.Data?.AccessCode}");
            Console.WriteLine($"Reference: {response.Data?.Reference}");
            Console.WriteLine($"JSON: {JsonConvert.SerializeObject(response.Data)}");
        }
        else
        {
            Console.WriteLine($"Error: {response.Message}");
        }
    }

    private async Task VerifyTransaction()
    {
        var reference = InputHelper.GetInput("Enter Reference: ");
        var response = await _transactionService.Verify(reference);

        if (response.Status)
        {
            Console.WriteLine($"\nTransaction Verified Successfully!");
            Console.Write($"ID: {response.Data?.Id}");
            Console.Write($"\tReference: {response.Data?.Reference}");
            Console.Write($"\tAmount: {response.Data?.Amount}");
            Console.Write($"\tStatus: {response.Data?.Status}");

            if (response.Data is { Status: TransactionStatus.Success })
            {
                Console.Write($"\tChannel: {response.Data?.Authorization.Channel}");
                Console.Write($"\tBank: {response.Data?.Authorization.Bank}");
                Console.WriteLine($"\tLast4: {response.Data?.Authorization.Last4}");
            }

            Console.WriteLine("");
            Console.WriteLine($"JSON: {JsonConvert.SerializeObject(response.Data)}");
        }
        else
        {
            Console.WriteLine($"Error: {response.Message}");
        }
    }

    private async Task ListTransactions()
    {
        var perPageString = InputHelper.GetInput("Enter Transactions Per Page (default 50): ", true);
        var perPage = int.TryParse(perPageString, out var parsedPerPage) ? parsedPerPage : 50;

        var pageString = InputHelper.GetInput("Enter Page (default 1): ", true);
        var page = int.TryParse(pageString, out var parsedPage) ? parsedPage : 1;

        var response = await _transactionService.List(new ListTransactionOptions
        {
            PerPage = perPage,
            Page = page
        });

        if (response.Status)
        {
            Console.WriteLine($"\nTransactions Listed Successfully!");
            Console.WriteLine($"Total: {response.Data.Count}");
            foreach (var transaction in response.Data)
            {
                Console.Write($"ID: {transaction?.Id}");
                Console.Write($"\tReference: {transaction?.Reference}");
                Console.Write($"\tAmount: {transaction?.Amount}");
                Console.Write($"\tStatus: {transaction?.Status}");

                if (transaction is { Status: TransactionStatus.Success })
                {
                    Console.Write($"\tChannel: {transaction.Authorization.Channel}");
                    Console.Write($"\tBank: {transaction.Authorization.Bank}");
                    Console.WriteLine($"\tLast4: {transaction.Authorization.Last4}");
                }

                Console.WriteLine("");
            }
        }
        else
        {
            Console.WriteLine($"Error: {response.Message}");
        }
    }

    private async Task GetTransaction()
    {
        var id = InputHelper.GetInput("Enter Transaction ID: ");
        var response = await _transactionService.Fetch(id);

        if (response.Status)
        {
            Console.WriteLine($"\nTransaction Verified Successfully!");
            Console.Write($"ID: {response.Data?.Id}");
            Console.Write($"\tReference: {response.Data?.Reference}");
            Console.Write($"\tAmount: {response.Data?.Amount}");
            Console.Write($"\tStatus: {response.Data?.Status}");

            if (response.Data is { Status: TransactionStatus.Success })
            {
                Console.Write($"\tChannel: {response.Data?.Authorization.Channel}");
                Console.Write($"\tBank: {response.Data?.Authorization.Bank}");
                Console.WriteLine($"\tLast4: {response.Data?.Authorization.Last4}");
            }

            Console.WriteLine("");
            Console.WriteLine($"JSON: {JsonConvert.SerializeObject(response.Data)}");
        }
        else
        {
            Console.WriteLine($"Error: {response.Message}");
        }
    }

    private async Task ChargeAuthorization()
    {
        var email = InputHelper.GetInput("Enter E-mail Address: ");
        var amount = InputHelper.GetInput("Enter Amount (in Pesewa): ");
        var authorizationCode = InputHelper.GetInput("Enter Authorization Code: ");

        var response = await _transactionService.ChargeAuthorization(new ChargeAuthorizationOptions
        {
            Amount = amount,
            Email = email,
            AuthorizationCode = authorizationCode,
        });

        if (response.Status)
        {
            Console.WriteLine($"\nTransaction Verified Successfully!");
            Console.Write($"ID: {response.Data?.Id}");
            Console.Write($"\tReference: {response.Data?.Reference}");
            Console.Write($"\tAmount: {response.Data?.Amount}");
            Console.Write($"\tStatus: {response.Data?.Status}");

            if (response.Data is { Status: TransactionStatus.Success })
            {
                Console.Write($"\tChannel: {response.Data?.Authorization.Channel}");
                Console.Write($"\tBank: {response.Data?.Authorization.Bank}");
                Console.WriteLine($"\tLast4: {response.Data?.Authorization.Last4}");
            }

            Console.WriteLine("");
            Console.WriteLine($"JSON: {JsonConvert.SerializeObject(response.Data)}");
        }
        else
        {
            Console.WriteLine($"Error: {response.Message}");
        }
    }

    private async Task TransactionTimeline()
    {
        var idOrReference = InputHelper.GetInput("Enter Transaction ID or Reference: ");
        var response = await _transactionService.TransactionTimeline(idOrReference);

        if (response.Status)
        {
            Console.WriteLine($"\nTransaction Timeline Retrieved Successfully!");
            Console.Write($"Start Time: {response.Data?.StartTime}");
            Console.Write($"\tTime Spent: {response.Data?.TimeSpent}");
            Console.Write($"\tAttempts: {response.Data?.Attempts}");
            Console.Write($"\tErrors: {response.Data?.Errors}");
            Console.Write($"\tMobile: {response.Data?.Mobile}");
            Console.WriteLine($"\tInput: {response.Data?.Input}");

            Console.WriteLine("\nHistory");
            Console.WriteLine("-------");
            foreach (var history in response.Data?.History ?? [])
            {
                Console.Write($"Type: {history.Type}");
                Console.Write($"\tMessage: {history.Message}");
                Console.WriteLine($"\tTime: {history.Time}");
            }

            Console.WriteLine("");
            Console.WriteLine($"JSON: {JsonConvert.SerializeObject(response.Data)}");
        }
        else
        {
            Console.WriteLine($"Error: {response.Message}");
        }
    }

    private async Task TransactionTotals()
    {
        var response = await _transactionService.TransactionTotals();

        if (response.Status)
        {
            Console.WriteLine("Transaction Totals Retrieved Successfully!");
            Console.WriteLine($"Total Transactions: {response.Data?.TotalTransactions}");
            Console.WriteLine($"Total Volume: {response.Data?.TotalVolume}");

            Console.WriteLine("Total Volume By Currency");
            Console.WriteLine("-------");
            foreach (var item in response.Data?.TotalVolumeByCurrency ?? [])
            {
                Console.Write($"Currency: {item.Currency}");
                Console.WriteLine($"\tAmount: {item.Amount}");
            }

            Console.WriteLine("");

            Console.WriteLine($"Pending Transfers: {response.Data?.PendingTransfers}");
            Console.WriteLine("Pending Transfers By Currency");
            Console.WriteLine("-------");
            foreach (var item in response.Data?.PendingTransfersByCurrency ?? [])
            {
                Console.Write($"Currency: {item.Currency}");
                Console.WriteLine($"\tAmount: {item.Amount}");
            }

            Console.WriteLine("");
            Console.WriteLine($"JSON: {JsonConvert.SerializeObject(response.Data)}");
        }
        else
        {
            Console.WriteLine($"Error: {response.Message}");
        }
    }

    private async Task ExportTransaction()
    {
        var perPageString = InputHelper.GetInput("Enter Transactions Per Page (default 50): ", true);
        var perPage = int.TryParse(perPageString, out var parsedPerPage) ? parsedPerPage : 50;

        var pageString = InputHelper.GetInput("Enter Page (default 1): ", true);
        var page = int.TryParse(pageString, out var parsedPage) ? parsedPage : 1;

        var response = await _transactionService.ExportTransaction(new ExportTransactionOptions
        {
            PerPage = perPage,
            Page = page
        });

        if (response.Status)
        {
            Console.WriteLine("Transaction Exported Successfully!");
            Console.WriteLine($"Path: {response.Data?.Path}");
            Console.WriteLine($"Expires At: {response.Data?.ExpiresAt}");
        }
        else
        {
            Console.WriteLine($"Error: {response.Message}");
        }
    }

    private async Task PartialDebit()
    {
        var email = InputHelper.GetInput("Enter E-mail Address: ");
        var amount = InputHelper.GetInput("Enter Amount (in pesewa): ");
        var authorizationCode = InputHelper.GetInput("Enter Authorization Code: ");
        var reference = "TEST-" + DateTime.Now.ToString("yyyyMMddHHmmss");

        InputHelper.GetInput("Enter Minimum Amount to Charge: ");
        var atLeast = Console.ReadLine();

        var response = await _transactionService.PartialDebit(new PartialDebitOptions
        {
            AuthorizationCode = authorizationCode,
            Currency = "GHS",
            Amount = amount,
            Email = email,
            Reference = reference,
            AtLeast = atLeast
        });

        if (response.Status)
        {
            Console.WriteLine($"\nCharge Attempted Successfully!");
            Console.Write($"ID: {response.Data?.Id}");
            Console.Write($"\tReference: {response.Data?.Reference}");
            Console.Write($"\tAmount: {response.Data?.Amount}");
            Console.Write($"\tStatus: {response.Data?.Status}");

            if (response.Data is { Status: TransactionStatus.Success })
            {
                Console.Write($"\tChannel: {response.Data?.Authorization.Channel}");
                Console.Write($"\tBank: {response.Data?.Authorization.Bank}");
                Console.WriteLine($"\tLast4: {response.Data?.Authorization.Last4}");
            }

            Console.WriteLine("");
            Console.WriteLine($"JSON: {JsonConvert.SerializeObject(response.Data)}");
        }
        else
        {
            Console.WriteLine($"Error: {response.Message}");
        }
    }
}