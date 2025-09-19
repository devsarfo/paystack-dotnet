using Newtonsoft.Json;
using Paystack.NET.Constants;
using Paystack.NET.Models.Transactions.Options;
using Paystack.NET.Services.Transaction;
using Sharprompt;

namespace Paystack.NET.Examples.Handlers;

public class TransactionHandler
{
    private readonly TransactionService _transactionService = new();

    public async Task Init()
    {
        Console.Clear();
        Console.WriteLine("--- Transactions ---");

        var option = Prompt.Select("Select an option", [
            "Initialize Transaction",
            "Verify Transaction",
            "List Transactions",
            "Fetch Transaction",
            "Charge Authorization",
            "Transaction Timeline",
            "Transaction Totals",
            "Export Transaction",
            "Partial Debit"
        ]);

        Console.Clear();

        try
        {
            switch (option)
            {
                case "Initialize Transaction":
                    Console.WriteLine("--- Initialize Transaction ---\n");
                    await InitializeTransaction();
                    break;
                case "Verify Transaction":
                    Console.WriteLine("--- Verify Transaction ---\n");
                    await VerifyTransaction();
                    break;
                case "List Transactions":
                    Console.WriteLine("--- List Transactions---\n");
                    await ListTransactions();
                    break;
                case "Fetch Transaction":
                    Console.WriteLine("--- Get Transaction ---\n");
                    await GetTransaction();
                    break;
                case "Charge Authorization":
                    Console.WriteLine("--- Charge Authorization ---\n");
                    await ChargeAuthorization();
                    break;
                case "Transaction Timeline":
                    Console.WriteLine("--- Transaction Timeline ---\n");
                    await TransactionTimeline();
                    break;
                case "Transaction Totals":
                    Console.WriteLine("--- Transaction Totals ---\n");
                    await TransactionTotals();
                    break;
                case "Export Transaction":
                    Console.WriteLine("--- Export Transaction ---\n");
                    await ExportTransaction();
                    break;
                case "Partial Debit":
                    Console.WriteLine("--- Partial Debit ---\n");
                    await PartialDebit();
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
        var email = Prompt.Input<string>("Enter E-mail Address", validators: [Validators.Required()]);
        var amount = Prompt.Input<int>("Enter Amount (in subunit)", validators: [Validators.Required()]);
        var reference = "TEST-" + DateTime.Now.ToString("yyyyMMddHHmmss");

        var response = await _transactionService.InitializeAsync(new InitializeTransactionOptions
        {
            Amount = amount,
            Email = email,
            Reference = reference,
            CallbackUrl = "https://webhook.site/42b1086b-4443-4e79-a7f6-61f41965fd9b"
        });

        if (response.Status)
        {
            Console.WriteLine("\nTransaction Initialized Successfully!");
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
        var reference = Prompt.Input<string>("Enter Reference", validators: [Validators.Required()]);
        var response = await _transactionService.VerifyAsync(reference);

        if (response.Status)
        {
            Console.WriteLine("\nTransaction Verified Successfully!");
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
        var perPage = Prompt.Input<int>("Enter Transactions Per Page (default 50)", 50);
        var page = Prompt.Input<int>("Enter Page (default 1)", 1);

        var response = await _transactionService.ListAsync(new ListTransactionsOptions
        {
            PerPage = perPage,
            Page = page
        });

        if (response.Status)
        {
            Console.WriteLine("\nTransactions Listed Successfully!");
            Console.WriteLine($"Total: {response.Data.Count}");
            foreach (var transaction in response.Data)
            {
                Console.Write($"ID: {transaction.Id}");
                Console.Write($"\tReference: {transaction.Reference}");
                Console.Write($"\tAmount: {transaction.Amount}");
                Console.Write($"\tStatus: {transaction.Status}");

                if (transaction is { Status: TransactionStatus.Success })
                {
                    Console.Write($"\tChannel: {transaction.Authorization.Channel}");
                    Console.Write($"\tBank: {transaction.Authorization.Bank}");
                    Console.Write($"\tLast4: {transaction.Authorization.Last4}");
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
        var id = Prompt.Input<string>("Enter Transaction ID", validators: [Validators.Required()]);
        var response = await _transactionService.FetchAsync(id);

        if (response.Status)
        {
            Console.WriteLine("\nTransaction Verified Successfully!");
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
        var email = Prompt.Input<string>("Enter E-mail Address", validators: [Validators.Required()]);
        var amount = Prompt.Input<int>("Enter Amount (in subunit)", validators: [Validators.Required()]);
        var authorizationCode = Prompt.Input<string>("Enter Authorization Code", validators: [Validators.Required()]);

        var response = await _transactionService.ChargeAuthorizationAsync(new ChargeAuthorizationOptions
        {
            Amount = amount,
            Email = email,
            AuthorizationCode = authorizationCode
        });

        if (response.Status)
        {
            Console.WriteLine("\nTransaction Verified Successfully!");
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
        var idOrReference = Prompt.Input<string>("Enter Transaction ID or Reference", validators: [Validators.Required()]);
        var response = await _transactionService.TransactionTimelineAsync(idOrReference);

        if (response.Status)
        {
            Console.WriteLine("\nTransaction Timeline Retrieved Successfully!");
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
        var response = await _transactionService.TransactionTotalsAsync();

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
        var perPage = Prompt.Input<int>("Enter Transactions Per Page (default 50)", 50);
        var page = Prompt.Input<int>("Enter Page (default 1)", 1);
        
        var response = await _transactionService.ExportTransactionAsync(new ExportTransactionOptions
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
        var email = Prompt.Input<string>("Enter E-mail Address", validators: [Validators.Required()]);
        var amount = Prompt.Input<int>("Enter Amount (in subunit)", validators: [Validators.Required()]);
        var authorizationCode = Prompt.Input<string>("Enter Authorization Code", validators: [Validators.Required()]);
        var reference = "TEST-" + DateTime.Now.ToString("yyyyMMddHHmmss");

        Prompt.Input<string>("Enter Minimum Amount to Charge", validators: [Validators.Required()]);
        var atLeast = Console.ReadLine();

        var response = await _transactionService.PartialDebitAsync(new PartialDebitOptions
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
            Console.WriteLine("\nCharge Attempted Successfully!");
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