# Playwright with .NET C# Demo Project

This repository contains a sample project demonstrating how to use Microsoft Playwright for automated browser testing with .NET C# and NUnit.

## Project Overview

This demo project showcases how to implement automated UI tests for web applications using Playwright, a modern end-to-end testing framework. The sample tests interact with a demo application at http://www.eaapp.somee.com.

## Technologies Used

- .NET 9.0
- NUnit 4.2.2
- Microsoft Playwright 1.52.0
- Microsoft Playwright NUnit integration

## Prerequisites

- [.NET SDK](https://dotnet.microsoft.com/download) (9.0 or compatible version)
- [Visual Studio](https://visualstudio.microsoft.com/) or [Visual Studio Code](https://code.visualstudio.com/)

## Getting Started

### Installation

1. Clone this repository:
   ```bash
   git clone <repository-url>
   cd PlaywrightDemo
   ```

2. Install Playwright CLI and browser binaries:
   ```bash
   dotnet tool install --global Microsoft.Playwright.CLI
   playwright install
   ```

### Running Tests

To run the tests using the command line:

```bash
dotnet test
```

Or run the tests directly from Visual Studio using the Test Explorer.

## Project Structure

- `PlaywrightDemo.csproj` - Project file with all the required package references
- `UnitTest1.cs` - Basic Playwright test using the standard Playwright API
- `NUnitPlaywright.cs` - Test using the Playwright NUnit integration with PageTest

## Test Approaches

This project demonstrates two approaches to writing tests with Playwright:

1. **Standard Playwright API** (UnitTest1.cs):
   - Manually initializes Playwright, browser, and page
   - Provides full control over the testing lifecycle
   - Example includes taking screenshots

2. **Playwright NUnit Integration** (NUnitPlaywright.cs):
   - Uses the PageTest base class to simplify test setup
   - Automatically handles browser and page initialization
   - More concise test code

## Key Features Demonstrated

- Page navigation
- Element location using text and CSS selectors
- Form interaction (clicking, filling)
- Screenshots
- Assertions
- Headless/headed browser configuration

## Best Practices

- Use PageTest for cleaner, more maintainable tests
- Implement proper assertions to validate expected behavior
- Use descriptive test and method names
- Consider implementing Page Object Model for larger test suites

## Resources

- [Playwright .NET Documentation](https://playwright.dev/dotnet/docs/intro)
- [NUnit Documentation](https://docs.nunit.org/)
- [.NET Documentation](https://docs.microsoft.com/en-us/dotnet/)

## License

This project is open source and available under the [MIT License](LICENSE).