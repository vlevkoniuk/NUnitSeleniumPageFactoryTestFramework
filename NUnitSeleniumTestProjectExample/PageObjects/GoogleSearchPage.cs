using System.Collections.Generic;
using NUnitSeleniumTestProjectExample.Common;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.Extensions;
//using OpenQA.Selenium.Support.PageObjects;
using SeleniumExtras.PageObjects;

namespace NUnitSeleniumTestProjectExample.PageObjects
{
    public class GoogleSearchPage : AbstractPage
    {
        private string _url = "https://google.com.ua";
        private IWebDriver _driver;
        public GoogleSearchPage(IWebDriver driver) : base(driver)
        {
            _driver = driver;
        }
        public override string Url 
        {
            get
            {
                return _url;
            }
        }

        [FindsBy(How = How.Name, Using = "q")]
        public IWebElement SearchString {get;set;}

        [FindsBy(How = How.Name, Using = "btnK")]
        public IList<IWebElement> SearchButton { get; set; }

        public GoogleSearchResult Search(string text_to_search)
        {
            SearchString.SendKeys(text_to_search);
            SearchString.Submit();
            //SearchButton[1].Click(); also works
            return new GoogleSearchResult(_driver);
        }
    }
}