﻿using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
            _driver.Close();
        }
        #endregion
    }
}