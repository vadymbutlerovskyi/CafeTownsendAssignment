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
    public class EmployeeManagementPage : BaseTest
    {

        public EmployeeManagementPage(IWebDriver driver) : base(driver)
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

        [FindsBy(How = How.XPath, Using = "//ul[@id='employee-list']/li[last()]")]
        private IWebElement lastEmployee { get; set; }

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
                case "Add":
                    addBtn.Click();
                    break;
            }
        }

        public void FillInNewEmployeeData(string firstName, string lastName, string startDate, string email)
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

        public void IsTheLastEmployeeListedWith(string firstName, string lastName)
        {
            WaitForElementToAppear(lastEmployee, 5);
            Assert.AreEqual(lastEmployee.Text, $"{firstName} {lastName}", "The employee created was not found in the list");
        }

        public void IsAlertThrownWithText(string alert)
        {
            Assert.AreEqual(_driver.SwitchTo().Alert().Text, alert, "Alert text is wrong");
            _driver.SwitchTo().Alert().Accept();
        }
        #endregion
    }
}
