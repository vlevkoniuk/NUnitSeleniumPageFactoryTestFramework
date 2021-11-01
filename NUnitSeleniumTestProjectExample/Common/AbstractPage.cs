using OpenQA.Selenium;
using System;
using System.Collections.Generic;

namespace NUnitSeleniumTestProjectExample.Common

{
    public abstract class AbstractPage
    {
        private IWebDriver driver;
        public abstract string Url { get;}
        public AbstractPage(IWebDriver _driver) 
        {
            driver = _driver;
        }

        public void GoTo(string url)
        {
            driver.Navigate().GoToUrl(url);
        }
        public void GoToNewTab(string url)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript($"window.open({url},'_blank');");
        }

        public string GetPageName()
        {
            string name = string.Empty;
            name = driver.Title == null ? driver.Title : name ;
            return name;
        }

        public int CurrentTabIndex ()
        {
            String currentTab = driver.CurrentWindowHandle;
            List<string> tabs = new List<string>(driver.WindowHandles);
            int index = tabs.IndexOf(currentTab);
            return index;
        }

        public void Refresh() => driver.Navigate().Refresh();

        public void Close() => driver.Close();
        
    }
}