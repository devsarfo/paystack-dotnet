# Paystack.NET Client

**Paystack.NET Client** is a .NET package designed to provide seamless integration with the [Paystack API][paystack]. It is a portable class library that facilitates easy access to various Paystack services, enabling developers to effortlessly manage payments, transactions, and more within their .NET applications.

Whether you're building a payment gateway, managing transactions, or integrating with Paystack's rich feature set, Paystack.NET Client streamlines the process, saving you development time and effort.

## Installation

Using the [.NET Core command-line interface (CLI) tools][dotnet-core-cli-tools]:

```sh
dotnet add package Paystack.NET.Client
```

Using the [NuGet Command Line Interface (CLI)][nuget-cli]:

```sh
nuget install Paystack.NET.Client
```

Using the [Package Manager Console][package-manager-console]:

```powershell
Install-Package Paystack.NET.Client
```

From within Visual Studio:

1. Open the Solution Explorer.
2. Right-click on a project within your solution.
3. Click on _Manage NuGet Packages..._
4. Click on the _Browse_ tab and search for "Paystack.NET".
5. Click on the Paystack.NET package, select the appropriate version in the
   right-tab and click _Install_.

## Documentation

For a comprehensive list of examples, check out the [Examples Project][api-docs].

### Authentication

Paystack authenticates API requests using your account’s secret key, which you can find in the Paystack Dashboard (Settings > API Keys & Webhooks)

Use Configure method in PaystackConfiguration to set the Secret Key and the Base URL if needed.

```C#
PaystackConfiguration.Configure("sk_test_...");
```

## Development

[Contribution guidelines for this project](CONTRIBUTING.md)

.NET 8 is required to build and test Paystack.NET SDK, you can install it from [get.dot.net](https://get.dot.net/).

For any requests, bug or comments, please [open an issue][issues] or [submit a
pull request][pulls].

[api-docs]: https://paystack.com/docs/api
[api-keys]: https://dashboard.paystack.com/#/settings/developers
[dotnet-core-cli-tools]: https://docs.microsoft.com/en-us/dotnet/core/tools/
[dotnet-format]: https://github.com/dotnet/format
[nuget-cli]: https://docs.microsoft.com/en-us/nuget/tools/nuget-exe-cli-reference
[package-manager-console]: https://docs.microsoft.com/en-us/nuget/tools/package-manager-console
[issues]: https://github.com/devsarfo/paystack-dotnet/issues
[pulls]: https://github.com/devsarfo/paystack-dotnet/pulls
[paystack]: https://paystack.com
