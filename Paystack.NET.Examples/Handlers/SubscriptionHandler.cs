using Newtonsoft.Json;
using Paystack.NET.Examples.Utils;
using Paystack.NET.Models.Subscriptions.Options;
using Paystack.NET.Models.Transactions.Options;
using Paystack.NET.Services.Customer;
using Paystack.NET.Services.Plan;
using Paystack.NET.Services.Subscription;

namespace Paystack.NET.Examples.Handlers;

public class SubscriptionHandler
{
    private readonly SubscriptionService _subscriptionService = new();
    private readonly CustomerService _customerService = new();
    private readonly PlanService _planService = new();

    public async Task Init()
    {
        Console.WriteLine("\n--- Subscriptions ---");
        Console.WriteLine("1. Create Subscription");
        Console.Write("Select an option: ");

        var choice = Console.ReadLine()?.Trim();

        Console.Clear();

        try
        {
            switch (choice)
            {
                case "1":
                    Console.WriteLine("--- Create Subscription ---\n");
                    await CreateSubscription();
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
    
    private async Task CreateSubscription()
    {
        var customerCodeOrEmail = InputHelper.GetInput("Enter Customer Code E-mail Address: ");
        var customerResponse = await _customerService.FetchAsync(customerCodeOrEmail);
        
        if (!customerResponse.Status) 
        {
            Console.WriteLine($"Error: {customerResponse.Message}");
            return;
        }
        
        var customer = customerResponse.Data!;
        
        var planIdOrCode = InputHelper.GetInput("Enter Plan Id or Code: ");
        var planResponse = await _planService.FetchAsync(planIdOrCode);

        if (!planResponse.Status)
        {
            Console.WriteLine($"Error: {planResponse.Message}");
            return;
        }
        
        var plan = planResponse.Data!;
        var authorization = InputHelper.GetInput("Enter Authorization Code [Optional]: ", true);
        if(string.IsNullOrEmpty(authorization)) authorization = null;
        
        var startDate = InputHelper.GetInput("Enter Start Date (ISO 8601 format e.g. 2017-05-16T00:30:13+01:00) [Optional]: ", true);
        if(string.IsNullOrEmpty(startDate)) startDate = null;
        
        var response = await _subscriptionService.CreateAsync(new CreateSubscriptionOptions
        {
            Customer = customer.CustomerCode,
            Plan = plan.PlanCode,
            Authorization = authorization,
            StartDate = startDate
        });

        if (response.Status)
        {
            Console.WriteLine($"\nSubscription Created Successfully!");
            Console.Write($"ID: {response.Data?.Id}");
            Console.Write($"\nCode: {response.Data?.SubscriptionCode}");
            Console.Write($"\nCustomer: {response.Data?.Customer}");
            Console.Write($"\nPlan: {response.Data?.Plan}");
            Console.Write($"\nAmount: {response.Data?.Amount}");
            Console.Write($"\nStatus: {response.Data?.Status}");
            Console.Write($"\nStart (UTC): {DateTimeOffset.FromUnixTimeSeconds(response.Data!.Start).UtcDateTime}");
            Console.WriteLine("");
            Console.WriteLine($"JSON: {JsonConvert.SerializeObject(response.Data)}");
        }
        else
        {
            Console.WriteLine($"Error: {response.Message}");
        }
    }
}