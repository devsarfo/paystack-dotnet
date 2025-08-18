using Newtonsoft.Json;
using Paystack.NET.Constants;
using Paystack.NET.Examples.Utils;
using Paystack.NET.Models.Customers.Options;
using Paystack.NET.Models.Customers.Shared;
using Paystack.NET.Services.Customer;

namespace Paystack.NET.Examples.Handlers
{
    public class CustomerHandler
    {
        private readonly CustomerService _customerService = new();

        public async Task Init()
        {
            Console.WriteLine("\n--- Customers ---");
            Console.WriteLine("1. Create Customer");
            Console.WriteLine("2. List Customers");
            Console.WriteLine("3. Fetch Customer");
            Console.WriteLine("4. Update Customer");
            Console.WriteLine("5. Validate Customer");
            Console.WriteLine("6. Whitelist/Blacklist Customer");
            Console.WriteLine("7. Initialize Authorization");
            Console.WriteLine("8. Verify Authorization");
            Console.WriteLine("9. Initialize Direct Debit");
            Console.WriteLine("10. Direct Debit Activation Charge");
            Console.WriteLine("11. Fetch Mandate Authorizations");
            Console.WriteLine("12. Deactivate Authorization");
            Console.Write("Select an option: ");

            var choice = Console.ReadLine()?.Trim();

            Console.Clear();

            try
            {
                switch (choice)
                {
                    case "1":
                        Console.WriteLine("--- Create Customer ---\n");
                        await CreateCustomer();
                        break;
                    case "2":
                        Console.WriteLine("--- List Customers---\n");
                        await ListCustomers();
                        break;
                    case "3":
                        Console.WriteLine("--- Fetch Customers---\n");
                        await FetchCustomer();
                        break;
                    case "4":
                        Console.WriteLine("--- Update Customer---\n");
                        await UpdateCustomer();
                        break;
                    case "5":
                        Console.WriteLine("--- Validate Customer---\n");
                        await ValidateCustomer();
                        break;
                    case "6":
                        Console.WriteLine("--- Whitelist/Blacklist Customer---\n");
                        await WhitelistBlacklistCustomer();
                        break;
                    case "7":
                        Console.WriteLine("--- Initialize Authorization ---\n");
                        await InitializeAuthorization();
                        break;
                    case "8":
                        Console.WriteLine("--- Verify Authorization ---\n");
                        await VerifyAuthorization();
                        break;
                    case "9":
                        Console.WriteLine("--- Initialize Direct Debit ---\n");
                        await InitializeDirectDebit();
                        break;
                    case "10":
                        Console.WriteLine("--- Direct Debit Activation Charge ---\n");
                        await DirectDebitActivationCharge();
                        break;
                    case "11":
                        Console.WriteLine("--- Fetch Mandate Authorizations ---\n");
                        await FetchMandateAuthorizations();
                        break;
                    case "12":
                        Console.WriteLine("--- Deactivate Authorization ---\n");
                        await DeactivateAuthorization();
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

        private async Task CreateCustomer()
        {
            var email = InputHelper.GetInput("Enter E-mail Address: ");
            var firstName = InputHelper.GetInput("Enter First Name: ");
            var lastName = InputHelper.GetInput("Enter Last Name: ");
            var phone = InputHelper.GetInput("Enter Phone (in int'l format): ", true);

            var response = await _customerService.CreateAsync(new CreateCustomerOptions
            {
                Email = email,
                FirstName = firstName,
                LastName = lastName,
                Phone = phone,
                Metadata = new Dictionary<string, object>
                {
                    { "source", "Paystack.NET.Examples" },
                }
            });

            if (response.Status)
            {
                Console.WriteLine($"\nCustomer Created Successfully!");
                Console.Write($"ID: {response.Data?.Id}");
                Console.Write($"\nCode: {response.Data?.CustomerCode}");
                Console.Write($"\nName: {response.Data?.FirstName} {response.Data?.LastName}");
                Console.Write($"\nE-mail: {response.Data?.Email}");
                Console.Write($"\nPhone: {response.Data?.Phone}");
                Console.WriteLine("");
                Console.WriteLine($"JSON: {JsonConvert.SerializeObject(response.Data)}");
            }
            else
            {
                Console.WriteLine($"Error: {response.Message}");
            }
        }

        private async Task ListCustomers()
        {
            var perPageString = InputHelper.GetInput("Enter Customers Per Page (default 50): ", true);
            var perPage = int.TryParse(perPageString, out var parsedPerPage) ? parsedPerPage : 50;

            var pageString = InputHelper.GetInput("Enter Page (default 1): ", true);
            var page = int.TryParse(pageString, out var parsedPage) ? parsedPage : 1;

            var response = await _customerService.ListAsync(new ListCustomersOptions
            {
                PerPage = perPage,
                Page = page
            });

            if (response.Status)
            {
                Console.WriteLine($"\nCustomers Listed Successfully!");
                Console.WriteLine($"Total: {response.Data.Count}");
                foreach (var customer in response.Data)
                {
                    Console.Write($"ID: {customer.Id}");
                    Console.Write($"\tE-mail: {customer.Email}");
                    Console.Write($"\tName: {customer.FirstName} {customer.LastName}");
                    Console.WriteLine("");
                }
            }
            else
            {
                Console.WriteLine($"Error: {response.Message}");
            }
        }

        private async Task FetchCustomer()
        {
            var emailOrCode = InputHelper.GetInput("Enter Customer E-mail or Code: ");
            var response = await _customerService.FetchAsync(emailOrCode);

            if (response.Status)
            {
                Console.WriteLine($"\nCustomer Fetched Successfully!");
                Console.Write($"ID: {response.Data?.Id}");
                Console.Write($"\nCode: {response.Data?.CustomerCode}");
                Console.Write($"\nName: {response.Data?.FirstName} {response.Data?.LastName}");
                Console.Write($"\nE-mail: {response.Data?.Email}");
                Console.Write($"\nPhone: {response.Data?.Phone}");
                Console.WriteLine("");
                Console.WriteLine($"JSON: {JsonConvert.SerializeObject(response.Data)}");
            }
            else
            {
                Console.WriteLine($"Error: {response.Message}");
            }
        }

        private async Task UpdateCustomer()
        {
            var emailOrCode = InputHelper.GetInput("Enter Customer E-mail or Code: ");
            var search = await _customerService.FetchAsync(emailOrCode);

            if (search is { Status: false, Data: null })
            {
                Console.WriteLine($"Error: {search.Message}");
            }

            var customer = search.Data!;
            var firstName = InputHelper.GetInput($"Enter First Name [{customer.FirstName}]: ", true);
            if (string.IsNullOrEmpty(firstName)) firstName = customer.FirstName;

            var lastName = InputHelper.GetInput($"Enter Last Name [{customer.LastName}]: ", true);
            if (string.IsNullOrEmpty(lastName)) lastName = customer.LastName;

            var phone = InputHelper.GetInput($"Enter Phone (in int'l format) [{customer.Phone}]: ", true);
            if (string.IsNullOrEmpty(phone)) phone = customer.Phone;

            var response = await _customerService.UpdateAsync(customer.CustomerCode, new UpdateCustomerOptions
            {
                FirstName = firstName,
                LastName = lastName,
                Phone = phone,
                Metadata = new Dictionary<string, object>
                {
                    { "source", "Paystack.NET.Examples" },
                }
            });

            if (response.Status)
            {
                Console.WriteLine($"\nCustomer Updated Successfully!");
                Console.Write($"ID: {response.Data?.Id}");
                Console.Write($"\nCode: {response.Data?.CustomerCode}");
                Console.Write($"\nName: {response.Data?.FirstName} {response.Data?.LastName}");
                Console.Write($"\nE-mail: {response.Data?.Email}");
                Console.Write($"\nPhone: {response.Data?.Phone}");
                Console.WriteLine("");
                Console.WriteLine($"JSON: {JsonConvert.SerializeObject(response.Data)}");
            }
            else
            {
                Console.WriteLine($"Error: {response.Message}");
            }
        }

        private async Task ValidateCustomer()
        {
            var emailOrCode = InputHelper.GetInput("Enter Customer E-mail or Code: ");
            var search = await _customerService.FetchAsync(emailOrCode);

            if (search is { Status: false, Data: null })
            {
                Console.WriteLine($"Error: {search.Message}");
            }

            var customer = search.Data!;
            var firstName = InputHelper.GetInput($"Enter First Name [{customer.FirstName}]: ", true);
            if (string.IsNullOrEmpty(firstName)) firstName = customer.FirstName;

            var lastName = InputHelper.GetInput($"Enter Last Name [{customer.LastName}]: ", true);
            if (string.IsNullOrEmpty(lastName)) lastName = customer.LastName;

            var type = InputHelper.GetInput($"Enter Type of Identification [{IdentificationType.BankAccount}]: ", true);
            if (string.IsNullOrEmpty(type)) type = IdentificationType.BankAccount;

            var value = InputHelper.GetInput("Enter Customer's Identification Number: ");

            var country = InputHelper.GetInput("Enter The 2-letter Country Code of Identification Issuer: ");

            var bvn = InputHelper.GetInput("Enter Customer's Bank Verification Number: ");

            var bankCode = InputHelper.GetInput("Enter Customer's Bank Code: ");

            var accountNumber = InputHelper.GetInput("Enter Customer's Bank Account Number: ");

            var middleName = InputHelper.GetInput("Enter Middle Name: ", true);


            var response = await _customerService.ValidateAsync(customer.CustomerCode, new ValidateCustomerOptions
            {
                FirstName = firstName,
                LastName = lastName,
                MiddleName = middleName,
                Type = type,
                Value = value,
                Country = country,
                Bvn = bvn,
                BankCode = bankCode,
                AccountNumber = accountNumber
            });

            if (response.Status)
            {
                Console.WriteLine($"\nCustomer Validation Request Sent Successfully!");
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
        
        private async Task WhitelistBlacklistCustomer()
        {
            var emailOrCode = InputHelper.GetInput("Enter Customer E-mail or Code: ");
            var search = await _customerService.FetchAsync(emailOrCode);

            if (search is { Status: false, Data: null })
            {
                Console.WriteLine($"Error: {search.Message}");
            }

            var customer = search.Data!;
            var riskAction = InputHelper.GetInput($"Enter Risk Action [{customer.RiskAction}]: ", true);
            if (string.IsNullOrEmpty(riskAction)) riskAction = customer.RiskAction;

            var response = await _customerService.UpdateRiskActionAsync(new CustomerRiskActionOptions
            {
                Customer = customer.CustomerCode,
                RiskAction = riskAction
            });

            if (response.Status)
            {
                Console.WriteLine($"\nCustomer Risk Action Updated Successfully!");
                Console.Write($"ID: {response.Data?.Id}");
                Console.Write($"\nCode: {response.Data?.CustomerCode}");
                Console.Write($"\nName: {response.Data?.FirstName} {response.Data?.LastName}");
                Console.Write($"\nE-mail: {response.Data?.Email}");
                Console.Write($"\nRisk Action: {response.Data?.RiskAction}");
                Console.WriteLine("");
                Console.WriteLine($"JSON: {JsonConvert.SerializeObject(response.Data)}");
            }
            else
            {
                Console.WriteLine($"Error: {response.Message}");
            }
        }
        
        private async Task InitializeAuthorization()
        {
            var emailOrCode = InputHelper.GetInput("Enter Customer E-mail or Code: ");
            var search = await _customerService.FetchAsync(emailOrCode);

            if (search is { Status: false, Data: null })
            {
                Console.WriteLine($"Error: {search.Message}");
            }

            var customer = search.Data!;
            var channel = InputHelper.GetInput($"Enter Channel [{AuthorizationChannel.DirectDebit}]: ", true);
            if(string.IsNullOrEmpty(channel)) channel = AuthorizationChannel.DirectDebit;

            var callbackUrl = InputHelper.GetInput($"Enter Callback URL: ", true);
            if (string.IsNullOrEmpty(callbackUrl)) callbackUrl = null;
            
            var response = await _customerService.InitializeAuthorizationAsync(new InitializeAuthorizationOptions
            {
                Email = customer.Email,
                Channel = channel,
                CallbackUrl = callbackUrl
            });

            if (response.Status)
            {
                Console.WriteLine($"\nCustomer Authorization Initialized Successfully!");
                Console.Write($"Reference: {response.Data?.RedirectUrl}");
                Console.Write($"\nAccess Code: {response.Data?.AccessCode}");
                Console.Write($"\nRedirect URL: {response.Data?.RedirectUrl}");
                Console.WriteLine("");
                Console.WriteLine($"JSON: {JsonConvert.SerializeObject(response.Data)}");
            }
            else
            {
                Console.WriteLine($"Error: {response.Message}");
            }
        }
        
        private async Task VerifyAuthorization()
        {
            var reference = InputHelper.GetInput("Enter Authorization Reference: ");
            var response = await _customerService.VerifyAuthorizationAsync(reference);

            if (response.Status)
            {
                Console.WriteLine("\nCustomer Authorization Verified Successfully!");
                Console.Write($"Authorization Code: {response.Data?.AuthorizationCode}");
                Console.Write($"\nChannel: {response.Data?.Channel}");
                Console.Write($"\nBank: {response.Data?.Bank}");
                Console.Write($"\nActive: {response.Data?.Active}");
                Console.Write($"\nCustomer: {response.Data?.Customer.Email}");
                Console.WriteLine("");
                Console.WriteLine($"JSON: {JsonConvert.SerializeObject(response.Data)}");
            }
            else
            {
                Console.WriteLine($"Error: {response.Message}");
            }
        }
        
        private async Task InitializeDirectDebit()
        {
            var emailOrCode = InputHelper.GetInput("Enter Customer E-mail or Code: ");
            var search = await _customerService.FetchAsync(emailOrCode);

            if (search is { Status: false, Data: null })
            {
                Console.WriteLine($"Error: {search.Message}");
            }

            var customer = search.Data!;
            var accountNumber = InputHelper.GetInput("Enter Account Number: ");
            var accountBankCode = InputHelper.GetInput("Enter Account Bank Code: ");
            var street = InputHelper.GetInput("Enter Address Street: ");
            var city = InputHelper.GetInput("Enter Address City: ");
            var state = InputHelper.GetInput("Enter Address State: ");
            
            var response = await _customerService.InitializeDirectDebitAsync(customer.Id.ToString(), new InitializeDirectDebitOptions
            {
                Account = new AccountDetails
                {
                    BankCode = accountBankCode,
                    Number = accountNumber
                },
                Address = new AddressDetails
                {
                    Street = street,
                    City = city,
                    State = state
                }
            });

            if (response.Status)
            {
                Console.WriteLine("\nCustomer Authorization Initialized Successfully!");
                Console.Write($"Reference: {response.Data?.RedirectUrl}");
                Console.Write($"\nAccess Code: {response.Data?.AccessCode}");
                Console.Write($"\nRedirect URL: {response.Data?.RedirectUrl}");
                Console.WriteLine("");
                Console.WriteLine($"JSON: {JsonConvert.SerializeObject(response.Data)}");
            }
            else
            {
                Console.WriteLine($"Error: {response.Message}");
            }
        }
        
        private async Task DirectDebitActivationCharge()
        {
            var emailOrCode = InputHelper.GetInput("Enter Customer E-mail or Code: ");
            var search = await _customerService.FetchAsync(emailOrCode);

            if (search is { Status: false, Data: null })
            {
                Console.WriteLine($"Error: {search.Message}");
            }

            var customer = search.Data!;
            var authorizationId = InputHelper.GetInput("Enter Authorization ID: ");
            
            var response = await _customerService.DirectDebitActivationChargeAsync(customer.Id.ToString(), new DirectDebitActivationChargeOptions
            {
                AuthorizationId = authorizationId
            });

            if (response.Status)
            {
                Console.WriteLine($"\nDirect Debit Activation Charge Sent Successfully!");
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
        
        private async Task FetchMandateAuthorizations()
        {
            var emailOrCode = InputHelper.GetInput("Enter Customer E-mail or Code: ");
            var search = await _customerService.FetchAsync(emailOrCode);

            if (search is { Status: false, Data: null })
            {
                Console.WriteLine($"Error: {search.Message}");
            }

            var customer = search.Data!;
            var response = await _customerService.FetchMandateAuthorizationsAsync(customer.Id.ToString());

            if (response.Status)
            {
                Console.WriteLine($"\nCustomer Mandate Authorizations Fetched Successfully!");
                Console.WriteLine($"Total: {response.Data.Count}");
                foreach (var authorization in response.Data)
                {
                    Console.Write($"Authorization ID: {authorization.Id}");
                    Console.Write($"\tAuthorization Code: {authorization.AuthorizationCode}");
                    Console.Write($"\tAccount Number: {authorization.AccountNumber}");
                    Console.Write($"\tBank Code: {authorization.BankCode}");
                    Console.Write($"\tCustomer: {authorization.Customer?.FirstName} {authorization.Customer?.LastName}");
                    Console.Write($"\tAuthorized At: {authorization.AuthorizedAt}");
                    Console.WriteLine("");
                }
                Console.WriteLine("");
                Console.WriteLine($"JSON: {JsonConvert.SerializeObject(response)}");
            }
            else
            {
                Console.WriteLine($"Error: {response.Message}");
            }
        }
        
        private async Task DeactivateAuthorization()
        {
            var authorizationCode = InputHelper.GetInput("Enter Authorization Code: ");
            var response = await _customerService.DeactivateAuthorizationAsync(new DeactivateAuthorizationOptions
            {
                AuthorizationCode = authorizationCode
            });

            if (response.Status)
            {
                Console.WriteLine($"\nAuthorization Deactivated Successfully!");
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