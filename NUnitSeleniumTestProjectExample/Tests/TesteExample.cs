using System.Collections.Generic;
using System.Threading.Tasks;
using NUnit.Framework;
using NUnitSeleniumTestProjectExample.Helpers;
using NUnitSeleniumTestProjectExample.Models;
using NUnitSeleniumTestProjectExample.PageObjects;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumExtras.PageObjects;
using System.Reflection;
using System.Diagnostics;

namespace NUnitSeleniumTestProjectExample.Tests
{
    public class TesteExample
    {
        private IWebDriver driver;
        private Login _loginInfo;
        [SetUp]
        public void Setup()
        {
            Logger.logLevel = 0; // log all messages
            driver = new ChromeDriver();
            _loginInfo = new Login();
            _loginInfo = LocalTestDataReader.LoadTestData<Login>(_loginInfo.GetType().Name);

        }

        [Test]
        public void SearchForViacheslav()
        {
            Logger.LogDebug("Debug message");
            Logger.LogInfo("Info message");
            Logger.LogWarning("Warning message");
            Logger.LogError("Error message");
            Logger.LogFatal("Fatal message");

            driver.Navigate().GoToUrl("https://google.com.ua");
            GoogleSearchPage gPage = new GoogleSearchPage(driver);
            GoogleSearchResult gResults = gPage.Search("viacheslav levkoniuk");

            var link = gResults.GetFirstLink();
            string href = link.GetAttribute("href");
            Assert.IsTrue(href.Contains("linkedin") && href.Contains("viacheslav-levkoniuk"), "The search result does not contain requested search result");
            link.Click();
            
        }

        [TearDown]
        public void TearDown()
        {
            driver.Close();
        }
        
    }
}