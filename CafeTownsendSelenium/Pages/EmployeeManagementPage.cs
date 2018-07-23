using CafeTownsendAutomation.Helpers;
using FundaSearchComponentBE.Tests;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
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
        NgWebDriver ngDriver;
        public static bool result;
        public static int employeesBefore;

        public EmployeeManagementPage(IWebDriver driver) : base(driver)
        {
            ngDriver = new NgWebDriver(_driver);
            PageFactory.InitElements(_driver, this);
            ngDriver.WaitForAngular();
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

        [FindsBy(How = How.XPath, Using = "//a[@class='subButton bBack']")]
        private IWebElement backBtn { get; set; }
        #endregion

        #region Delete
        [FindsBy(How = How.XPath, Using = "//*[@ng-click='deleteEmployee()']")]
        private IWebElement deleteBtn { get; set; }
        #endregion

        [FindsBy(How = How.ClassName, Using = "bCancel")]
        private IWebElement cancelBtn { get; set; }

        [FindsBy(How = How.XPath, Using = "//ul[@id='employee-list']/li")]
        private IList<IWebElement> totalEmployees { get; set; }

        [FindsBy(How = How.XPath, Using = "//ul[@id='employee-list']/li[last()]")]
        private IWebElement lastEmployee { get; set; }

        #endregion

        #region Action's
        public void ClickOnButton(string button)
        {
            switch (button)
            {
                case "Cancel":
                    WaitForElementToAppear(cancelBtn, 3);
                    cancelBtn.Click();
                    break;
                case "Create":
                    WaitForElementToAppear(lastEmployee, 3);
                    employeesBefore = totalEmployees.Count;
                    createBtn.Click();
                    WaitForElementToAppear(addBtn, 3);
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
                case "Back":
                    backBtn.Click();
                    break;
                case "Delete":
                    deleteBtn.Click();
                    break;
            }
        }

        public EmployeeManagementPage SelectTheLastEmployee()
        {
            lastEmployee.Click();
            return this;
        }

        public void FillInNewEmployeeData(string firstName, string lastName, string startDate, string email)
        {
            Employee.firstName = firstName;
            Employee.lastName = lastName;
            Employee.startDate = startDate;
            Employee.email = email;

            ClearEmployeeFields(false);

            firstNameInp.SendKeys(firstName);
            lastNameInp.SendKeys(lastName);
            startDateInp.SendKeys(startDate);
            emailInp.SendKeys(email);
        }

        public void ClearEmployeeFields(bool hardly)
        {
            if (hardly == false)
            {
                firstNameInp.Clear();
                lastNameInp.Clear();
                startDateInp.Clear();
                emailInp.Clear();
            }
            else
            {
                ExtraActions actions = new ExtraActions(_driver);
                actions.ClearFieldHardly(firstNameInp)
                    .ClearFieldHardly(lastNameInp)
                    .ClearFieldHardly(startDateInp)
                    .ClearFieldHardly(emailInp);
            }
        }
        #endregion

        #region Bool
        public void IsButtonDisabled(string button)
        {
            switch (button)
            {
                case "Edit":
                    WaitForElementToAppear(editBtn, 3);
                    result = editBtn.GetAttribute("class").Contains("disabled") ? true : false;
                    break;
                case "Delete":
                    WaitForElementToAppear(deleteBtn, 3);
                    result = deleteBtn.GetAttribute("class").Contains("disabled") ? true : false;
                    break;
                case "Add":
                    WaitForElementToAppear(addBtn, 3);
                    result = addBtn.GetAttribute("ng-disabled").Equals("true") ? true : false;
                    break;
                case "Update":
                    WaitForElementToAppear(updateBtn, 3);
                    result = updateBtn.GetAttribute("ng-disabled").Equals("true") ? true : false;
                    break;
            }
            Assert.IsTrue(result, "The button \"{0}\" is not disabled.", button);
        }

        public bool IsEmployeeListed()
        {
            WaitForElementToAppear(lastEmployee, 3);
            string soughtEmployee = $"{Employee.firstName} {Employee.lastName}";
            foreach (var emp in totalEmployees)
            {
                if (emp.Text == soughtEmployee)
                {
                    result = true;
                    emp.Click();
                    break;
                }
                else
                {
                    result = false;
                }
            }
            return result;
        }

        public void RemoveAllEmployees(string employee)
        {
            WaitForSeconds(2);
            WaitForElementToAppear(lastEmployee, 3);
            int i;
            int n = 1;
            int total;
            do
            {
                total = totalEmployees.Count;
                for (i = n; i <= total + 1; i++)
                {
                    try
                    {
                        IWebElement emp = _driver.FindElement(By.XPath($"//ul[@id='employee-list']/li[{i}]"));
                        if (emp.Text == employee)
                        {
                            ProceedWithDelete(emp);
                            break;
                        }
                    }
                    catch (NoSuchElementException)
                    {
                        IWebElement emp = _driver.FindElement(By.XPath($"//ul[@id='employee-list']/li[{--i}]"));
                        if (emp.Text == employee)
                        {
                            ProceedWithDelete(emp);
                            break;
                        }
                        else if (i == total)
                        {
                            break;
                        }
                    }
                }
            }
            while (i < total);


            void ProceedWithDelete(IWebElement emp)
            {
                Actions action = new Actions(_driver);
                action.DoubleClick(emp).Perform();
                BaseTest baseTest = new BaseTest(_driver);
                WaitForSeconds(2);
                deleteBtn.Click();
                WaitForSeconds(2);
                baseTest.AcceptAlert();
                WaitForElementToAppear(lastEmployee, 3);
                WaitForSeconds(3);
                n = i;
            }                                  
        }

        public void IsAlertThrownWithText(string alert)
        {
            Assert.AreEqual(_driver.SwitchTo().Alert().Text, alert, "Alert text is wrong");
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

        public void IsDeleteAlertThrownWithText(string alert)
        {
            Assert.AreEqual(_driver.SwitchTo().Alert().Text, $"{alert}{Employee.firstName} {Employee.lastName}?", "Alert text is wrong");
        }
        #endregion
    }
}
