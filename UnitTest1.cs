using Microsoft.Playwright;
using PlaywrightDemo.Pages;

namespace PlaywrightDemo;

public class  Tests
{
    [SetUp]
    public void Setup()
    {
    }
    
    [Test]
    public async Task Test1()
    {
        // Playwright
        using var playwright = await Playwright.CreateAsync();
        // Browser
        await using var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
        {
            Headless = false,
        });
        // Page
        var page = await browser.NewPageAsync();
        await page.GotoAsync("http://www.eaapp.somee.com");
        await page.ClickAsync("text=Login");
        await page.ScreenshotAsync(new PageScreenshotOptions
        {
            Path = "EAApp.jpg"
        });
        await page.FillAsync("#UserName", "admin");
        await page.FillAsync("#Password", "password");
        await page.ClickAsync("text=Log in");
        var isExist = await page.Locator("text='Employee Details'").IsVisibleAsync();
        Assert.That(isExist);
    }
    
    [Test]
    public async Task TestWithPom()
    {
        // Playwright
        using var playwright = await Playwright.CreateAsync();
        // Browser
        await using var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
        {
            Headless = false,
        });
        // Page
        var page = await browser.NewPageAsync();
        await page.GotoAsync("http://www.eaapp.somee.com");

        // Perform login
        var loginPage = new LoginPageUpgraded(page);
        await loginPage.ClickLogin();
        await loginPage.Login("admin", "password");

        // Verify login
        var isExist = await loginPage.IsEmployeeDetailsVisible();
        Assert.That(isExist);
    }
    
    [Test]
    public async Task TestNetwork()
    {
        // Playwright
        using var playwright = await Playwright.CreateAsync();
        // Browser
        await using var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
        {
            Headless = false,
        });
        // Page
        var page = await browser.NewPageAsync();
        await page.GotoAsync("http://www.eaapp.somee.com");

        // Perform login
        var loginPage = new LoginPageUpgraded(page);
        await loginPage.ClickLogin();
        await loginPage.Login("admin", "password");

        // Request interception
        // var waitResponse = page.WaitForResponseAsync("**/Employee");
        // await loginPage.ClickEmployeeList();
        // var getResponse = await waitResponse;

        var response = await page.RunAndWaitForResponseAsync(async () =>
        {
            await loginPage.ClickEmployeeList();
        }, x => x.Url.Contains("/Employee") && x.Status == 200);

        // Verify login
        var isExist = await loginPage.IsEmployeeDetailsVisible();
        Assert.That(isExist);
    }
}
