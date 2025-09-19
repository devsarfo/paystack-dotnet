using Newtonsoft.Json;
using Paystack.NET.Constants;
using Paystack.NET.Models.Customers.Options;
using Paystack.NET.Models.Customers.Shared;
using Paystack.NET.Services.Customer;
using Sharprompt;

namespace Paystack.NET.Examples.Handlers;

public class CustomerHandler
{
    private readonly CustomerService _customerService = new();

    public async Task Init()
    {
        Console.Clear();
        Console.WriteLine("--- Customers ---");

        var option = Prompt.Select("Select an option", [
            "Create Customer",
            "List Customers",
            "Fetch Customer",
            "Update Customer",
            "Validate Customer",
            "Whitelist/Blacklist Customer",
            "Initialize Authorization",
            "Verify Authorization",
            "Initialize Direct Debit",
            "Direct Debit Activation Charge",
            "Fetch Mandate Authorizations",
            "Deactivate Authorization"
        ]);


        Console.Clear();

        try
        {
            switch (option)
            {
                case "Create Customer ":
                    Console.WriteLine("--- Create Customer ---\n");
                    await CreateCustomer();
                    break;
                case "List Customers":
                    Console.WriteLine("--- List Customers---\n");
                    await ListCustomers();
                    break;
                case "Fetch Customer":
                    Console.WriteLine("--- Fetch Customers---\n");
                    await FetchCustomer();
                    break;
                case "Update Customer":
                    Console.WriteLine("--- Update Customer---\n");
                    await UpdateCustomer();
                    break;
                case "Validate Customer":
                    Console.WriteLine("--- Validate Customer---\n");
                    await ValidateCustomer();
                    break;
                case "Whitelist/Blacklist Customer":
                    Console.WriteLine("--- Whitelist/Blacklist Customer---\n");
                    await WhitelistBlacklistCustomer();
                    break;
                case "Initialize Authorization":
                    Console.WriteLine("--- Initialize Authorization ---\n");
                    await InitializeAuthorization();
                    break;
                case "Verify Authorization":
                    Console.WriteLine("--- Verify Authorization ---\n");
                    await VerifyAuthorization();
                    break;
                case "Initialize Direct Debit":
                    Console.WriteLine("--- Initialize Direct Debit ---\n");
                    await InitializeDirectDebit();
                    break;
                case "Direct Debit Activation Charge":
                    Console.WriteLine("--- Direct Debit Activation Charge ---\n");
                    await DirectDebitActivationCharge();
                    break;
                case "Fetch Mandate Authorizations":
                    Console.WriteLine("--- Fetch Mandate Authorizations ---\n");
                    await FetchMandateAuthorizations();
                    break;
                case "Deactivate Authorization":
                    Console.WriteLine("--- Deactivate Authorization ---\n");
                    await DeactivateAuthorization();
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
        var email = Prompt.Input<string>("Enter E-mail Address", validators: [Validators.Required()]);
        var firstName = Prompt.Input<string>("Enter First Name", validators: [Validators.Required()]);
        var lastName = Prompt.Input<string>("Enter Last Name", validators: [Validators.Required()]);
        var phone = Prompt.Input<string>("Enter Phone (in int'l format)", true);

        var response = await _customerService.CreateAsync(new CreateCustomerOptions
        {
            Email = email,
            FirstName = firstName,
            LastName = lastName,
            Phone = phone,
            Metadata = new Dictionary<string, object>
            {
                { "source", "Paystack.NET.Examples" }
            }
        });

        if (response.Status)
        {
            Console.WriteLine("\nCustomer Created Successfully!");
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
        var perPage = Prompt.Input<int>("Enter Customers Per Page (default 50)", 50);
        var page = Prompt.Input<int>("Enter Page (default 1)", 1);
        
        var response = await _customerService.ListAsync(new ListCustomersOptions
        {
            PerPage = perPage,
            Page = page
        });

        if (response.Status)
        {
            Console.WriteLine("\nCustomers Listed Successfully!");
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
        var emailOrCode = Prompt.Input<string>("Enter Customer E-mail or Code", validators: [Validators.Required()]);
        var response = await _customerService.FetchAsync(emailOrCode);

        if (response.Status)
        {
            Console.WriteLine("\nCustomer Fetched Successfully!");
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
        var emailOrCode = Prompt.Input<string>("Enter Customer E-mail or Code", validators: [Validators.Required()]);
        var search = await _customerService.FetchAsync(emailOrCode);

        if (search is { Status: false, Data: null })
        {
            Console.WriteLine($"Error: {search.Message}");
        }

        var customer = search.Data!;
        var firstName = Prompt.Input<string>($"Enter First Name [{customer.FirstName}]", customer.FirstName);
        var lastName = Prompt.Input<string>($"Enter Last Name [{customer.LastName}]", customer.LastName);
        var phone = Prompt.Input<string>($"Enter Phone (in int'l format) [{customer.Phone}]", customer.Phone);

        var response = await _customerService.UpdateAsync(customer.CustomerCode, new UpdateCustomerOptions
        {
            FirstName = firstName,
            LastName = lastName,
            Phone = phone,
            Metadata = new Dictionary<string, object>
            {
                { "source", "Paystack.NET.Examples" }
            }
        });

        if (response.Status)
        {
            Console.WriteLine("\nCustomer Updated Successfully!");
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
        var emailOrCode = Prompt.Input<string>("Enter Customer E-mail or Code", validators: [Validators.Required()]);
        var search = await _customerService.FetchAsync(emailOrCode);

        if (search is { Status: false, Data: null })
        {
            Console.WriteLine($"Error: {search.Message}");
        }

        var customer = search.Data!;
        var firstName = Prompt.Input<string>($"Enter First Name [{customer.FirstName}]", customer.FirstName);
        var lastName = Prompt.Input<string>($"Enter Last Name [{customer.LastName}]", customer.LastName);
        var type = Prompt.Input<string>($"Enter Type of Identification [{IdentificationType.BankAccount}]", IdentificationType.BankAccount);
        var value = Prompt.Input<string>("Enter Customer's Identification Number", validators: [Validators.Required()]);
        var country = Prompt.Input<string>("Enter The 2-letter Country Code of Identification Issuer", validators: [Validators.Required()]);
        var bvn = Prompt.Input<string>("Enter Customer's Bank Verification Number", validators: [Validators.Required()]);
        var bankCode = Prompt.Input<string>("Enter Customer's Bank Code", validators: [Validators.Required()]);
        var accountNumber = Prompt.Input<string>("Enter Customer's Bank Account Number", validators: [Validators.Required()]);
        var middleName = Prompt.Input<string>("Enter Middle Name");


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
            Console.WriteLine("\nCustomer Validation Request Sent Successfully!");
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
        var emailOrCode = Prompt.Input<string>("Enter Customer E-mail or Code", validators: [Validators.Required()]);
        var search = await _customerService.FetchAsync(emailOrCode);

        if (search is { Status: false, Data: null })
        {
            Console.WriteLine($"Error: {search.Message}");
        }

        var customer = search.Data!;
        var riskAction = Prompt.Input<string>($"Enter Risk Action [{customer.RiskAction}]", customer.RiskAction);

        var response = await _customerService.UpdateRiskActionAsync(new CustomerRiskActionOptions
        {
            Customer = customer.CustomerCode,
            RiskAction = riskAction
        });

        if (response.Status)
        {
            Console.WriteLine("\nCustomer Risk Action Updated Successfully!");
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
        var emailOrCode = Prompt.Input<string>("Enter Customer E-mail or Code", validators: [Validators.Required()]);
        var search = await _customerService.FetchAsync(emailOrCode);

        if (search is { Status: false, Data: null })
        {
            Console.WriteLine($"Error: {search.Message}");
        }

        var customer = search.Data!;
        var channel = Prompt.Input<string>($"Enter Channel [{AuthorizationChannel.DirectDebit}]", AuthorizationChannel.DirectDebit);
        var callbackUrl = Prompt.Input<string?>("Enter Callback URL");
        var response = await _customerService.InitializeAuthorizationAsync(new InitializeAuthorizationOptions
        {
            Email = customer.Email,
            Channel = channel,
            CallbackUrl = callbackUrl
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

    private async Task VerifyAuthorization()
    {
        var reference = Prompt.Input<string>("Enter Authorization Reference", validators: [Validators.Required()]);
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
        var emailOrCode = Prompt.Input<string>("Enter Customer E-mail or Code", validators: [Validators.Required()]);
        var search = await _customerService.FetchAsync(emailOrCode);

        if (search is { Status: false, Data: null })
        {
            Console.WriteLine($"Error: {search.Message}");
        }

        var customer = search.Data!;
        var accountNumber = Prompt.Input<string>("Enter Account Number", validators: [Validators.Required()]);
        var accountBankCode = Prompt.Input<string>("Enter Account Bank Code", validators: [Validators.Required()]);
        var street = Prompt.Input<string>("Enter Address Street", validators: [Validators.Required()]);
        var city = Prompt.Input<string>("Enter Address City", validators: [Validators.Required()]);
        var state = Prompt.Input<string>("Enter Address State", validators: [Validators.Required()]);

        var response = await _customerService.InitializeDirectDebitAsync(customer.Id.ToString(),
            new InitializeDirectDebitOptions
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
        var emailOrCode = Prompt.Input<string>("Enter Customer E-mail or Code", validators: [Validators.Required()]);
        var search = await _customerService.FetchAsync(emailOrCode);

        if (search is { Status: false, Data: null })
        {
            Console.WriteLine($"Error: {search.Message}");
        }

        var customer = search.Data!;
        var authorizationId = Prompt.Input<string>("Enter Authorization ID: ");

        var response = await _customerService.DirectDebitActivationChargeAsync(customer.Id.ToString(),
            new DirectDebitActivationChargeOptions
            {
                AuthorizationId = authorizationId
            });

        if (response.Status)
        {
            Console.WriteLine("\nDirect Debit Activation Charge Sent Successfully!");
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
        var emailOrCode = Prompt.Input<string>("Enter Customer E-mail or Code: ");
        var search = await _customerService.FetchAsync(emailOrCode);

        if (search is { Status: false, Data: null })
        {
            Console.WriteLine($"Error: {search.Message}");
        }

        var customer = search.Data!;
        var response = await _customerService.FetchMandateAuthorizationsAsync(customer.Id.ToString());

        if (response.Status)
        {
            Console.WriteLine("\nCustomer Mandate Authorizations Fetched Successfully!");
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
        var authorizationCode = Prompt.Input<string>("Enter Authorization Code: ");
        var response = await _customerService.DeactivateAuthorizationAsync(new DeactivateAuthorizationOptions
        {
            AuthorizationCode = authorizationCode
        });

        if (response.Status)
        {
            Console.WriteLine("\nAuthorization Deactivated Successfully!");
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