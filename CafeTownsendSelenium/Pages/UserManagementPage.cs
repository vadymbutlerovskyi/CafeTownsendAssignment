using FundaSearchComponentBE.Tests;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using Protractor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace CafeTownsendSelenium.Pages
{
    public class UserManagementPage : BaseTest
    {

        public UserManagementPage(IWebDriver driver) : base(driver)
        {
            PageFactory.InitElements(_driver, this);
        }

        #region PageFactory

        #region Create
        [FindsBy(How = How.Id, Using = "bAdd")]
        private IWebElement createBtn { get; set; }

        [FindsBy(How = How.XPath, Using = "//button[@type='submit'][text()='Add']")]
        private IWebElement addBtn { get; set; }

        [FindsBy(How = How.Custom, CustomFinderType = typeof(NgByModel), Using = "selectedEmployee.firstName")]
        private IWebElement firstNameInp { get; set; }

        [FindsBy(How = How.Custom, CustomFinderType = typeof(NgByModel), Using = "selectedEmployee.lastName")]
        private IWebElement lastNameInp { get; set; }

        [FindsBy(How = How.Custom, CustomFinderType = typeof(NgByModel), Using = "selectedEmployee.startDate")]
        private IWebElement startDateInp { get; set; }

        [FindsBy(How = How.Custom, CustomFinderType = typeof(NgByModel), Using = "selectedEmployee.email")]
        private IWebElement emailInp { get; set; }
        #endregion

        #region Edit
        [FindsBy(How = How.Id, Using = "bEdit")]
        private IWebElement editBtn { get; set; }
        #endregion

        #region Delete
        [FindsBy(How = How.Id, Using = "bDelete")]
        private IWebElement deleteBtn { get; set; }
        #endregion

        [FindsBy(How = How.ClassName, Using = "bCancel")]
        private IWebElement cancelBtn { get; set; }

        #endregion

        #region Action's
        public void ClickOnButton(string button)
        {
            switch (button)
            {
                case "Cancel":
                    WaitForElementToAppear(cancelBtn, 5);
                    cancelBtn.Click();
                    break;
                case "Create":
                    AreEditDeleteButtonsDisabled();
                    WaitForElementToAppear(createBtn, 5);
                    createBtn.Click();
                    WaitForElementToAppear(addBtn, 5);
                    Console.WriteLine("Add button {0} disabled", addBtn.GetAttribute("ng-disabled") == "true" ? "is" : "is not (!!!)");
                    break;
            }
        }

        public void FillInNewUserData(string firstName, string lastName, string startDate, string email)
        {
            firstNameInp.SendKeys(firstName);
            lastNameInp.SendKeys(lastName);
            if (startDate == "Today")
            {
                startDateInp.SendKeys(DateTime.Now.Date.ToString("yyyy-MM-dd"));
            }
            else
            {
                startDateInp.SendKeys(startDate);
            }
            emailInp.SendKeys(email);
        }
        #endregion

        #region Bool
        public void AreEditDeleteButtonsDisabled()
        {
            WaitForElementToAppear(editBtn, 5);
            Assert.IsTrue(editBtn.GetAttribute("class").Contains("disabled") & deleteBtn.GetAttribute("class").Contains("disabled") ? true : false);
        }
        #endregion
    }
}
