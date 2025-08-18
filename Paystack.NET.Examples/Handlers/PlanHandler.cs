using Newtonsoft.Json;
using Paystack.NET.Constants;
using Paystack.NET.Examples.Utils;
using Paystack.NET.Models.Plans.Options;
using Paystack.NET.Services.Plan;

namespace Paystack.NET.Examples.Handlers
{
    public class PlanHandler
    {
        private readonly PlanService _planService = new();

        public async Task Init()
        {
            Console.WriteLine("\n--- Plans ---");
            Console.WriteLine("1. Create Plan");
            Console.WriteLine("2. List Plans");
            Console.WriteLine("3. Fetch Plan");
            Console.WriteLine("4. Update Plan");
            Console.Write("Select an option: ");

            var choice = Console.ReadLine()?.Trim();

            Console.Clear();

            try
            {
                switch (choice)
                {
                    case "1":
                        Console.WriteLine("--- Create Plan ---\n");
                        await CreatePlan();
                        break;
                    case "2":
                        Console.WriteLine("--- List Plans---\n");
                        await ListPlans();
                        break;
                    case "3":
                        Console.WriteLine("--- Fetch Plans---\n");
                        await FetchPlan();
                        break;
                    case "4":
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
            var name = InputHelper.GetInput("Enter Name: ");
            var amountString = InputHelper.GetInput("Enter Amount (in subunit): ");
            var amount = int.TryParse(amountString, out var parsedAmount) ? parsedAmount : 500;
            var interval = InputHelper.GetInput("Enter Interval (daily, weekly, monthly,quarterly, biannually, annually): ");
            var description = InputHelper.GetInput("Enter Description: ");
            
            
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
                Console.WriteLine($"\nPlan Created Successfully!");
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
            var perPageString = InputHelper.GetInput("Enter Plans Per Page (default 50): ", true);
            var perPage = int.TryParse(perPageString, out var parsedPerPage) ? parsedPerPage : 50;
            
            var pageString = InputHelper.GetInput("Enter Page (default 1): ", true);
            var page = int.TryParse(pageString, out var parsedPage) ? parsedPage : 1;
            
            var status = InputHelper.GetInput("Enter Status: ", true);
            if(string.IsNullOrEmpty(status)) status = null;
            
            var interval = InputHelper.GetInput("Enter Interval: ", true);
            if(string.IsNullOrEmpty(interval)) interval = null;
            
            var amountString = InputHelper.GetInput("Enter Amount (in subunit): ", true);
            int? amount = int.TryParse(amountString, out var parsedAmount) ? parsedAmount : null;
            
            var response = await _planService.ListAsync(new ListPlansOptions
            {
                PerPage = perPage,
                Page = page
            });
            
            if (response.Status)
            {
                Console.WriteLine($"\nPlans Listed Successfully!");
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
            var idOrCode = InputHelper.GetInput("Enter Plan Id or Code: ");
            var response = await _planService.FetchAsync(idOrCode);
            
            if (response.Status)
            {
                Console.WriteLine($"\nPlan Fetched Successfully!");
                Console.Write($"ID: {response.Data?.Id}");
                Console.Write($"\nCode: {response.Data?.PlanCode}");
                Console.Write($"\nName: {response.Data?.PlanCode} {response.Data?.PlanCode}");
                Console.Write($"\tCurrency: {response.Data?.Currency}");
                Console.Write($"\tAmount: {response.Data?.Amount}");
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
            var emailOrCode = InputHelper.GetInput("Enter Plan Id or Code: ");
            var search = await _planService.FetchAsync(emailOrCode);
            
            if (search is { Status: false, Data: null })
            {
                Console.WriteLine($"Error: {search.Message}");
            }
            
            var plan = search.Data!;
            var name = InputHelper.GetInput($"Enter Name [{plan.Name}]: ", true);
            if(string.IsNullOrEmpty(name)) name = plan.Name;
            
            var amountString = InputHelper.GetInput($"Enter Amount (in subunit) [{plan.Amount}]: ", true);
            var amount = int.TryParse(amountString, out var parsedAmount) ? parsedAmount : plan.Amount;
            
            var interval = InputHelper.GetInput($"Enter Interval (daily, weekly, monthly,quarterly, biannually, annually) [{plan.Interval}]: ", true);
            if(string.IsNullOrEmpty(interval)) interval = plan.Interval;
            
            var description = InputHelper.GetInput($"Enter Description [{plan.Description}]: ", true);
            if(string.IsNullOrEmpty(description)) description = plan.Description;

            
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
                Console.WriteLine($"\nPlan Updated Successfully!");
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
}