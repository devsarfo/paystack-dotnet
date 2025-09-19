using Newtonsoft.Json;
using Paystack.NET.Models.Subscriptions.Options;
using Paystack.NET.Services.Customer;
using Paystack.NET.Services.Plan;
using Paystack.NET.Services.Subscription;
using Sharprompt;

namespace Paystack.NET.Examples.Handlers;

public class SubscriptionHandler
{
    private readonly SubscriptionService _subscriptionService = new();
    private readonly CustomerService _customerService = new();
    private readonly PlanService _planService = new();

    public async Task Init()
    {
        Console.Clear();
        Console.WriteLine("--- Subscriptions ---");

        var option = Prompt.Select("Select an option", [
            "Create Subscription",
            "List Subscriptions",
            "Fetch Subscription",
            "Enable Subscription",
            "Disable Subscription",
            "Generate Update Subscription Link",
            "Send Update Subscription Link",
        ]);

        var choice = Console.ReadLine()?.Trim();

        Console.Clear();

        try
        {
            switch (choice)
            {
                case "Create Subscription":
                    Console.WriteLine("--- Create Subscription ---\n");
                    await CreateSubscription();
                    break;
                case "List Subscriptions":
                    Console.WriteLine("--- List Subscriptions ---\n");
                    await ListSubscriptions();
                    break;
                case "Fetch Subscription":
                    Console.WriteLine("--- Fetch Subscription ---\n");
                    await FetchSubscription();
                    break;
                case "Enable Subscription":
                    Console.WriteLine("--- Enable Subscription ---\n");
                    await EnableSubscription();
                    break;
                case "Disable Subscription":
                    Console.WriteLine("--- Disable Subscription ---\n");
                    await DisableSubscription();
                    break;
                case "Generate Update Subscription Link":
                    Console.WriteLine("--- Generate Update Subscription Link ---\n");
                    await GenerateUpdateSubscriptionLink();
                    break;
                case "Send Update Subscription Link":
                    Console.WriteLine("--- Send Update Subscription Link ---\n");
                    await SendUpdateSubscriptionLink();
                    break;
            }
        }
        catch (Exception e)
        {
            Console.WriteLine($"\nError: {e.Message}\n");
        }
    }
    
    private async Task CreateSubscription()
    {
        var customerCodeOrEmail = Prompt.Input<string>("Enter Customer Code E-mail Address", validators: [Validators.Required()]);
        var customerResponse = await _customerService.FetchAsync(customerCodeOrEmail);
        
        if (!customerResponse.Status) 
        {
            Console.WriteLine($"Error: {customerResponse.Message}");
            return;
        }
        
        var customer = customerResponse.Data!;
        
        var planIdOrCode = Prompt.Input<string>("Enter Plan Id or Code", validators: [Validators.Required()]);
        var planResponse = await _planService.FetchAsync(planIdOrCode);

        if (!planResponse.Status)
        {
            Console.WriteLine($"Error: {planResponse.Message}");
            return;
        }
        
        var plan = planResponse.Data!;
        var authorization = Prompt.Input<string?>("Enter Authorization Code [Optional]");
        var startDate = Prompt.Input<string?>("Enter Start Date (ISO 8601 format e.g. 2017-05-16T00:30:13+01:00) [Optional]");
        
        var response = await _subscriptionService.CreateAsync(new CreateSubscriptionOptions
        {
            Customer = customer.CustomerCode,
            Plan = plan.PlanCode,
            Authorization = authorization,
            StartDate = startDate
        });

        if (response.Status)
        {
            Console.WriteLine("\nSubscription Created Successfully!");
            Console.Write($"ID: {response.Data?.Id}");
            Console.Write($"\nCode: {response.Data?.SubscriptionCode}");
            Console.Write($"\nCustomer: {response.Data?.Customer}");
            Console.Write($"\nPlan: {response.Data?.Plan}");
            Console.Write($"\nAmount: {response.Data?.Amount}");
            Console.Write($"\nStatus: {response.Data?.Status}");
            Console.Write($"\nStart (UTC): {response.Data?.Start}");
            Console.WriteLine("");
            Console.WriteLine($"JSON: {JsonConvert.SerializeObject(response.Data)}");
        }
        else
        {
            Console.WriteLine($"Error: {response.Message}");
        }
    }
    
    private async Task ListSubscriptions()
    {
        var perPage = Prompt.Input<int>("Enter Subscriptions Per Page (default 50)", 50);
        var page = Prompt.Input<int>("Enter Page (default 1)", 1);

        var response = await _subscriptionService.ListAsync(new ListSubscriptionsOptions
        {
            PerPage = perPage,
            Page = page
        });

        if (response.Status)
        {
            Console.WriteLine("\nSubscriptions Listed Successfully!");
            Console.WriteLine($"Total: {response.Data.Count}");
            foreach (var subscription in response.Data)
            {
                Console.Write($"ID: {subscription.Id}");
                Console.Write($"\tCode: {subscription.SubscriptionCode}");
                Console.Write($"\tCustomer: {subscription.Customer.FirstName} {subscription.Customer.LastName}");
                Console.Write($"\tPlan: {subscription.Plan.Name}");
                Console.Write($"\tStatus: {subscription.Status}");
                Console.Write($"\tChannel: {subscription.Authorization.Channel}");
                Console.Write($"\tBank: {subscription.Authorization.Bank}");
                Console.Write($"\tLast4: {subscription.Authorization.Last4}");
                Console.WriteLine("");
            }
        }
        else
        {
            Console.WriteLine($"Error: {response.Message}");
        }
    }
    
    private async Task FetchSubscription()
    {
        var idOrCode = Prompt.Input<string>("Enter Subscription Id or Code", validators: [Validators.Required()]);
        var response = await _subscriptionService.FetchAsync(idOrCode);

        if (response.Status)
        {
            Console.WriteLine("\nSubscription Fetched Successfully!");
            Console.Write($"ID: {response.Data?.Id}");
            Console.Write($"\nCode: {response.Data?.SubscriptionCode}");
            Console.Write($"\nPlan: {response.Data?.Plan.Name} ({response.Data?.Plan.PlanCode})");
            Console.Write($"\nCustomer: {response.Data?.Customer.FirstName} {response.Data?.Customer.LastName}");
            Console.Write($"\nCreated At: {response.Data?.CreatedAt}");
            Console.Write($"\nNext Payment Date: {response.Data?.NextPaymentDate}");
            Console.Write($"\nCancelled At: {response.Data?.CancelledAt}");
            Console.Write($"\nStatus: {response.Data?.Status}");
            Console.WriteLine("");
            Console.WriteLine($"JSON: {JsonConvert.SerializeObject(response.Data)}");
        }
        else
        {
            Console.WriteLine($"Error: {response.Message}");
        }
    }
    
    private async Task EnableSubscription()
    {
        var idOrCode = Prompt.Input<string>("Enter Subscription Id or Code", validators: [Validators.Required()]);
        var token = Prompt.Input<string>("Enter Subscription E-mail Token", validators: [Validators.Required()]);
        
        var response = await _subscriptionService.EnableAsync(new EnableSubscriptionOptions
        {
            Code = idOrCode,
            Token = token
        });

        if (response.Status)
        {
            Console.WriteLine("\nSubscription Enabled Successfully!");
            Console.Write($"Status: {response.Status}");
            Console.Write($"\nMessage: {response.Message}");
            Console.WriteLine("");
            Console.WriteLine($"JSON: {JsonConvert.SerializeObject(response)}");
        }
        else
        {
            Console.WriteLine($"Error: {response.Message}");
        }
    }
    
    private async Task DisableSubscription()
    {
        var idOrCode = Prompt.Input<string>("Enter Subscription Id or Code", validators: [Validators.Required()]);
        var token = Prompt.Input<string>("Enter Subscription E-mail Token", validators: [Validators.Required()]);
        
        var response = await _subscriptionService.DisableAsync(new DisableSubscriptionOptions
        {
            Code = idOrCode,
            Token = token
        });

        if (response.Status)
        {
            Console.WriteLine("\nSubscription Disabled Successfully!");
            Console.Write($"Status: {response.Status}");
            Console.Write($"\nMessage: {response.Message}");
            Console.WriteLine("");
            Console.WriteLine($"JSON: {JsonConvert.SerializeObject(response)}");
        }
        else
        {
            Console.WriteLine($"Error: {response.Message}");
        }
    }
    
    private async Task GenerateUpdateSubscriptionLink()
    {
        var idOrCode = Prompt.Input<string>("Enter Subscription Id or Code", validators: [Validators.Required()]);
        var response = await _subscriptionService.GenerateUpdateSubscriptionLinkAsync(idOrCode);

        if (response.Status)
        {
            Console.WriteLine("\nSubscription Update Link Generated Successfully!");
            Console.Write($"Status: {response.Status}");
            Console.Write($"\nMessage: {response.Message}");
            Console.Write($"\nLink: {response.Data?.Link}");
            Console.WriteLine("");
            Console.WriteLine($"JSON: {JsonConvert.SerializeObject(response)}");
        }
        else
        {
            Console.WriteLine($"Error: {response.Message}");
        }
    }
    
    private async Task SendUpdateSubscriptionLink()
    {
        var idOrCode = Prompt.Input<string>("Enter Subscription Id or Code", validators: [Validators.Required()]);
        var response = await _subscriptionService.SendUpdateSubscriptionLinkAsync(idOrCode);

        if (response.Status)
        {
            Console.WriteLine("\nSubscription Update Link Sent Successfully!");
            Console.Write($"Status: {response.Status}");
            Console.Write($"\nMessage: {response.Message}");
            Console.WriteLine("");
            Console.WriteLine($"JSON: {JsonConvert.SerializeObject(response)}");
        }
        else
        {
            Console.WriteLine($"Error: {response.Message}");
        }
    }
}