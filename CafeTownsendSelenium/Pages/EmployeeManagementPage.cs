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
        public bool result;

        public EmployeeManagementPage(IWebDriver driver) : base(driver)
        {
            PageFactory.InitElements(_driver, this);
        }

        public struct Employee
        {
            public static string firstName;
            public static string lastName;
            public static string startDate;
            public static string email;
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

        [FindsBy(How = How.XPath, Using = "//button[@type='submit'][text()='Update']")]
        private IWebElement updateBtn { get; set; }
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
                case "Edit":
                    editBtn.Click();
                    break;
                case "Update":
                    updateBtn.Click();
                    break;
            }
        }

        public void FillInNewEmployeeData(string firstName, string lastName, string startDate, string email)
        {
            Employee.firstName = firstName;
            Employee.lastName = lastName;
            Employee.startDate = startDate;
            Employee.email = email;

            ClearEmployeeFields();

            firstNameInp.SendKeys(firstName);
            lastNameInp.SendKeys(lastName);
            startDateInp.SendKeys(startDate);
            emailInp.SendKeys(email);
        }

        public void ClearEmployeeFields()
        {
            firstNameInp.Clear();
            lastNameInp.Clear();
            startDateInp.Clear();
            emailInp.Clear();
        }
        #endregion

        #region Bool
        public void AreEditDeleteButtonsDisabled()
        {
            WaitForElementToAppear(editBtn, 5);
            Assert.IsTrue(editBtn.GetAttribute("class").Contains("disabled") & deleteBtn.GetAttribute("class").Contains("disabled") ? true : false);
        }

        public void IsTheLastEmployeeListed()
        {
            WaitForElementToAppear(lastEmployee, 5);
            Assert.AreEqual(lastEmployee.Text, $"{Employee.firstName} {Employee.lastName}", "The employee created was not found in the list");
            lastEmployee.Click();
        }

        public void IsAlertThrownWithText(string alert)
        {
            Assert.AreEqual(_driver.SwitchTo().Alert().Text, alert, "Alert text is wrong");
            _driver.SwitchTo().Alert().Accept();
        }

        public void IsFieldInvalid(string field)
        {
            switch (field)
            {
                case "Start date":
                    result = startDateInp.GetAttribute("class").Contains("invalid") ? true : false;
                    break;
                case "Email":
                    result = emailInp.GetAttribute("class").Contains("invalid") ? true : false;
                    break;
            }

            Assert.IsTrue(result, "The field \"{0}\" doens't indicate that it is invalid", field);
        }

        public void IsAllEmployeeDataCorrect()
        {
            Assert.AreEqual(Employee.firstName, firstNameInp.GetAttribute("value"), "The first name input value is not correct");
            Assert.AreEqual(Employee.lastName, lastNameInp.GetAttribute("value"), "The last name input value is not correct");
            Assert.AreEqual(Employee.startDate, startDateInp.GetAttribute("value"), "The start date input value is not correct");
            Assert.AreEqual(Employee.email, emailInp.GetAttribute("value"), "The email input value is not correct");
        }
        #endregion
    }
}
