//using Microsoft.AspNetCore.Routing;
using System.Xml.Linq;
using aurora_automation.ApiTests.Models;
using Microsoft.Playwright;
using Newtonsoft.Json;
using NHamcrest;
using Xunit;
using static RestAssured.Dsl;

namespace aurora_automation.UITests
{
    public class UITests
    {
      
        [Fact]
        public async Task TestPlaywright()
        {
            var playwright = await Playwright.CreateAsync();
            var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions { Headless = true });
            var page = await browser.NewPageAsync();
            await page.GotoAsync("https://example.com");
            Assert.Equal("Example Domain", await page.TitleAsync());
            await browser.CloseAsync();
        }
    }
}
