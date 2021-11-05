using NUnit.Framework;
using NUnitSeleniumTestProjectExample.PageObjects;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace NUnitSeleniumTestProjectExample.Tests
{
    public class TesteExample
    {
        private IWebDriver driver;
        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
        }

        [Test]
        public void Test1()
        {
            GoogleSearchPage gPage = new GoogleSearchPage(driver);
            gPage.GoTo(gPage.Url);
            gPage.SearchString.SendKeys("GitHub VLevkoniuk");
            gPage.SearchButton.Click();
        }
        
    }
}