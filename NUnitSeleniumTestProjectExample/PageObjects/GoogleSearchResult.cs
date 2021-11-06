using System.Collections.Generic;
using NUnitSeleniumTestProjectExample.Common;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace NUnitSeleniumTestProjectExample.PageObjects
{
    public class GoogleSearchResult : AbstractPage
    {
        private IWebDriver _driver;

        public GoogleSearchResult(IWebDriver driver) : base(driver)
        {
            _driver = driver;
        }

        public override string Url 
        {
            get
            {
                return _driver.Url;
            }
        }

        [FindsBy(How = How.Id, Using ="search" )]
        public IWebElement SerarchResultContainer {get;set;}

        public IList<IWebElement> GetLinks()
        {
            return SerarchResultContainer.FindElements(By.TagName("a"));
        }

        public IWebElement GetFirstLink()
        {
            return SerarchResultContainer.FindElements(By.TagName("a"))[0];
        }
    }
}