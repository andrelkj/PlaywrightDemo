using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;

namespace PlaywrightDemo;

public class  NUnitPlaywright : PageTest
{
    [SetUp]
    public async Task Setup()
    {
        await Page.GotoAsync("http://www.eaapp.somee.com");
    }

    [Test]
    public async Task Login()
    {
        Page.SetDefaultTimeout(10000);
        // Using CSS-based Locator
        var lnkLogin = Page.Locator("text=Login");
        await lnkLogin.ClickAsync();
        
        await Page.FillAsync("#UserName", "admin");
        await Page.FillAsync("#Password", "password");
        
        // Using Text-based Page Locator Options
        var btnLogin = Page.Locator("input", new PageLocatorOptions{HasTextString = "Log in"});
        await btnLogin.ClickAsync();
        
        await Expect(Page.Locator("text='Employee Details'")).ToBeVisibleAsync();
    }
}
