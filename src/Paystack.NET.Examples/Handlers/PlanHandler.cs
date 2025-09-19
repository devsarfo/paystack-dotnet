using Newtonsoft.Json;
using Paystack.NET.Constants;
using Paystack.NET.Models.Plans.Options;
using Paystack.NET.Services.Plan;
using Sharprompt;

namespace Paystack.NET.Examples.Handlers;

public class PlanHandler
{
    private readonly PlanService _planService = new();

    public async Task Init()
    {
        Console.Clear();
        Console.WriteLine("--- Plans ---");

        var option = Prompt.Select("Select an option", [
            "Create Plan",
            "List Plans",
            "Fetch Plan",
            "Update Plan"
        ]);

        Console.Clear();

        try
        {
            switch (option)
            {
                case "Create Plan":
                    Console.WriteLine("--- Create Plan ---\n");
                    await CreatePlan();
                    break;
                case "List Plans":
                    Console.WriteLine("--- List Plans---\n");
                    await ListPlans();
                    break;
                case "Fetch Plan":
                    Console.WriteLine("--- Fetch Plan---\n");
                    await FetchPlan();
                    break;
                case "Update Plan":
                    Console.WriteLine("--- Update Plan---\n");
                    await UpdatePlan();
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

    private async Task CreatePlan()
    {
        var name = Prompt.Input<string>("Enter Name", validators: [Validators.Required()]);
        var amount = Prompt.Input<int>("Enter Amount (in subunit)", validators: [Validators.Required()]);
        var description = Prompt.Input<string>("Enter Description", validators: [Validators.Required()]);
        var interval = Prompt.Select<string>("Select Interval", [
            PlanInterval.Daily,
            PlanInterval.Weekly,
            PlanInterval.Monthly,
            PlanInterval.Quarterly,
            PlanInterval.Biannually,
            PlanInterval.Annually
        ]);

        var response = await _planService.CreateAsync(new CreatePlanOptions
        {
            Name = name,
            Amount = amount,
            Interval = interval,
            Description = description,
            SendInvoices = true,
            SendSms = true
        });

        if (response.Status)
        {
            Console.WriteLine("\nPlan Created Successfully!");
            Console.Write($"ID: {response.Data?.Id}");
            Console.Write($"\nCode: {response.Data?.PlanCode}");
            Console.Write($"\nName: {response.Data?.Name}");
            Console.Write($"\nDescription: {response.Data?.Description}");
            Console.Write($"\nCurrency: {response.Data?.Currency}");
            Console.Write($"\nAmount: {response.Data?.Amount}");
            Console.WriteLine("");
            Console.WriteLine($"JSON: {JsonConvert.SerializeObject(response.Data)}");
        }
        else
        {
            Console.WriteLine($"Error: {response.Message}");
        }
    }

    private async Task ListPlans()
    {
        var perPage = Prompt.Input<int>("Enter Plans Per Page (default 50)", 50);
        var page = Prompt.Input<int>("Enter Page (default 1)", 1);
        var status = Prompt.Input<string?>("Enter Status");
        var interval = Prompt.Select<string>("Select Interval", [
            PlanInterval.Daily,
            PlanInterval.Weekly,
            PlanInterval.Monthly,
            PlanInterval.Quarterly,
            PlanInterval.Biannually,
            PlanInterval.Annually,
            "All"
        ], defaultValue: "All");
        if (interval == "All") interval = null;
        
        var amount = Prompt.Input<int?>("Enter Amount (in subunit)");

        var response = await _planService.ListAsync(new ListPlansOptions
        {
            PerPage = perPage,
            Page = page,
            Amount = amount,
            Interval = interval,
            Status = status
        });

        if (response.Status)
        {
            Console.WriteLine("\nPlans Listed Successfully!");
            Console.WriteLine($"Total: {response.Data.Count}");
            foreach (var plan in response.Data)
            {
                Console.Write($"ID: {plan.Id}");
                Console.Write($"\tCode: {plan.PlanCode}");
                Console.Write($"\tName: {plan.Name}");
                Console.Write($"\tCurrency: {plan.Currency}");
                Console.Write($"\tAmount: {plan.Amount}");
                Console.Write($"\tSubscriptions: {plan.Subscriptions.Count}");
                Console.WriteLine("");
            }
        }
        else
        {
            Console.WriteLine($"Error: {response.Message}");
        }
    }

    private async Task FetchPlan()
    {
        var idOrCode = Prompt.Input<string>("Enter Plan Id or Code", validators: [Validators.Required()]);
        var response = await _planService.FetchAsync(idOrCode);

        if (response.Status)
        {
            Console.WriteLine("\nPlan Fetched Successfully!");
            Console.Write($"ID: {response.Data?.Id}");
            Console.Write($"\nCode: {response.Data?.PlanCode}");
            Console.Write($"\nName: {response.Data?.Name}");
            Console.Write($"\nCurrency: {response.Data?.Currency}");
            Console.Write($"\nAmount: {response.Data?.Amount}");
            Console.Write($"\nSubscriptions: {response.Data?.Subscriptions.Count}");
            Console.WriteLine("");
            Console.WriteLine($"JSON: {JsonConvert.SerializeObject(response.Data)}");
        }
        else
        {
            Console.WriteLine($"Error: {response.Message}");
        }
    }

    private async Task UpdatePlan()
    {
        var emailOrCode = Prompt.Input<string>("Enter Plan Id or Code", validators: [Validators.Required()]);
        var search = await _planService.FetchAsync(emailOrCode);

        if (search is { Status: false, Data: null })
        {
            Console.WriteLine($"Error: {search.Message}");
        }

        var plan = search.Data!;
        var name = Prompt.Input<string>($"Enter Name [{plan.Name}]", plan.Name);
        var amount = Prompt.Input<int>($"Enter Amount (in subunit) [{plan.Amount}]", plan.Amount);

        var interval = Prompt.Select<string>("Select Interval", [
            PlanInterval.Daily,
            PlanInterval.Weekly,
            PlanInterval.Monthly,
            PlanInterval.Quarterly,
            PlanInterval.Biannually,
            PlanInterval.Annually
        ], defaultValue: plan.Interval);

        var description = Prompt.Input<string>($"Enter Description [{plan.Description}]", plan.Description);

        var response = await _planService.UpdateAsync(plan.PlanCode, new UpdatePlanOptions
        {
            Name = name,
            Amount = amount,
            Interval = interval,
            Description = description,
            SendInvoices = true,
            SendSms = true,
            UpdateExistingSubscriptions = true
        });

        if (response.Status)
        {
            Console.WriteLine("\nPlan Updated Successfully!");
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