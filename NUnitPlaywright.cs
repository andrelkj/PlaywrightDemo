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
        var lnkLogin = Page.Locator("text=Login");
        await lnkLogin.ClickAsync();
        
        await Page.FillAsync("#UserName", "admin");
        await Page.FillAsync("#Password", "password");
        
        var btnLogin = Page.Locator("input", new PageLocatorOptions{HasTextString = "Log in"});
        await btnLogin.ClickAsync();
        
        await Expect(Page.Locator("text='Employee Details'")).ToBeVisibleAsync();
    }
}
