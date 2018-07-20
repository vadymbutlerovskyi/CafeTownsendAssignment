using FundaSearchComponentBE.Tests;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Protractor;

namespace CafeTownsendSelenium.Pages
{
    public class LoginLogoutPage : BaseTest
    {
        NgWebDriver ngDriver;
        public bool result;

        public LoginLogoutPage(IWebDriver driver) : base(driver)
        {
            ngDriver = new NgWebDriver(_driver);
            PageFactory.InitElements(_driver, this);
            ngDriver.WaitForAngular();
        }

        #region PageFactory
        [FindsBy(How = How.XPath, Using = "//button[@type='submit']")]
        private IWebElement loginBtn { get; set; }

        [FindsBy(How = How.Custom, CustomFinderType = typeof(NgByModel), Using = "user.name")]
        private IWebElement usernameInp { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@ng-model='user.password'][@type='password']")] //this also validates if password symbols are hidden
        private IWebElement passwordInp { get; set; }

        [FindsBy(How = How.Custom, CustomFinderType = typeof(NgBy), Using = "showMessage()")]
        private IWebElement invalidErr { get; set; }
        #endregion

        #region Get's

        #endregion

        #region Action's
        public void ClickLogin()
        {
            loginBtn.Click();
        }

        public void InputIntoTheField(string value, string field)
        {
            if (field == "username")
            {
                usernameInp.Clear();
                usernameInp.SendKeys(value);
            }
            else
            {
                passwordInp.Clear();
                passwordInp.SendKeys(value);
            }
        }
        #endregion

        #region Bool's
        public bool IsFieldRequired(string field)
        {
            if (field == "username")
            {
                result = Convert.ToBoolean(usernameInp.GetAttribute("required"));
            }
            else
            {
                result = Convert.ToBoolean(passwordInp.GetAttribute("required"));
            }

            return result;
        }

        public string GetErrorInvalidCredentials()
        {
            try
            {
                return invalidErr.Text;
            }
            catch (NoSuchElementException)
            {
                return null;
            }
        }
        #endregion

    }
}
