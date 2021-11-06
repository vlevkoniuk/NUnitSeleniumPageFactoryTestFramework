using System.Collections.Generic;
using System.Threading.Tasks;
using NUnit.Framework;
using NUnitSeleniumTestProjectExample.PageObjects;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumExtras.PageObjects;

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
            GoogleSearchResult gResults = gPage.Search("viacheslav levkoniuk");

            var link = gResults.GetFirstLink();
            string href = link.GetAttribute("href");
            Assert.IsTrue(href.Contains("linkedin") && href.Contains("viacheslav-levkoniuk"));
            link.Click();
            
        }

        [TearDown]
        public void TearDown()
        {
            Task.Delay(10000);
            driver.Close();
        }
        
    }
}