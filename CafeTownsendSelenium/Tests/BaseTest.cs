﻿using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FundaSearchComponentBE.Tests
{
    public class BaseTest
    {
        public IWebDriver _driver;

        public BaseTest(IWebDriver driver)
        {
            _driver = driver;
        }

        public BaseTest(string url)
        {
            _driver = new ChromeDriver();
            _driver.Manage().Window.Maximize();
            _driver.Navigate().GoToUrl(url);
        }

        #region Get
        protected List<IWebElement> GetElementsByTag(string tagName)
        {
            return _driver.FindElements(By.TagName(tagName)).ToList();
        }

        public string GetPageUrl()
        {
            return _driver.Url;
        }
        #endregion

        #region Actions
        public void GoToUrl(string url)
        {
            _driver.Navigate().GoToUrl(url);
        }

        public void RefreshPage()
        {
            _driver.Navigate().Refresh();
        }

        public void Quit()
        {
            _driver.Quit();
        }

        public void AcceptAlert()
        {
            _driver.SwitchTo().Alert().Accept();
        }

        public void DismissAlert()
        {
            _driver.SwitchTo().Alert().Dismiss();
        }
        #endregion

        #region Wait's
        public void WaitForElementToAppear(IWebElement element, int secs)
        {
            //Despite WebDriverWait available, this method allows to pass an IWebElement directly
            bool result = false;
            int counter = 0;
            do
            {
                try
                {
                    counter++;
                    result = element.Displayed ? true : false;
                }
                catch (NoSuchElementException)
                {
                    Thread.Sleep(1000 * secs);
                    //_driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1);
                }
                if (counter == secs)
                {
                    throw new NoSuchElementException();
                }
                else if (result == true)
                {
                    break;
                }
            }
            while (counter <= secs);
        }

        public void WaitForSeconds(int secs)
        {
            Thread.Sleep(1000 * secs);
            //Despite this method _driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(secs); and others available,
            //and taking into account the fact that Thread.Sleep is not a good pructice, it worked the best in all the test cases 
        }
        #endregion
    }
}
