using CafeTownsendAutomation.Helpers;
using CafeTownsendSelenium.Pages;
using FundaSearchComponentBE.Tests;
using NUnit.Framework;
using SpecFlow.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace CafeTownsendAutomation.Steps
{
    [Binding]
    public class EmployeeManagementSteps
    {
        #region When's
        [When(@"I fill in new employee data with the following:")]
        public void WhenIFillInNewEmployeeDataWithTheFollowing(Table table)
        {
            dynamic newEmployee = table.CreateDynamicInstance();
            var employeeManagement = ScenarioContext.Current.Get<EmployeeManagementPage>();
            if (newEmployee.StartDate.ToString() == "Today")
            {
                employeeManagement.FillInNewEmployeeData(newEmployee.FirstName, newEmployee.LastName, DateTime.Now.Date.ToString("yyyy-MM-dd"), newEmployee.Email);
            }
            else
            {
                var dictionary = TableExtensions.ToDictionary(table);
                ScenarioContext.Current.Remove("StartDate");
                ScenarioContext.Current.Add("StartDate", dictionary["Start date"]);
                string startDate = ScenarioContext.Current.Get<string>("StartDate");
                employeeManagement.FillInNewEmployeeData(newEmployee.FirstName, newEmployee.LastName, startDate, newEmployee.Email);
            }            
        }

        [When(@"I clear all the employee fields")]
        public void WhenIClearAllTheEmployeeFields()
        {
            var employeeManagement = ScenarioContext.Current.Get<EmployeeManagementPage>();
            employeeManagement.ClearEmployeeFields(true);
        }

        [When(@"I '(.*)' the alert")]
        public void WhenITheAlert(string action)
        {
            var baseTest = ScenarioContext.Current.Get<BaseTest>();
            if (action == "accept")
            {
                baseTest.AcceptAlert();
            }
            else
            {
                baseTest.DismissAlert();
            }
        }  

        [When(@"I see the alert to confirm delete with message '(.*)'")]
        public void WhenISeeTheAlertToConfirmDeleteWithMessage(string alert)
        {
            var employeeManagement = ScenarioContext.Current.Get<EmployeeManagementPage>();
            employeeManagement.IsDeleteAlertThrownWithText(alert);
        }     
        #endregion

        #region Then's
        [Then(@"I click on the (.*) button")]
        public void ThenIClickOnTheButton(string button)
        {
            var employeeManagement = ScenarioContext.Current.Get<EmployeeManagementPage>();
            employeeManagement.ClickOnButton(button);
        }

        [Then(@"I see and select the new employee listed")]
        public void ThenISeeAndSelectTheNewEmployeeListed()
        {
            var employeeManagement = ScenarioContext.Current.Get<EmployeeManagementPage>();
            Assert.IsTrue(employeeManagement.IsEmployeeListed(), "The employee created was not found in the list");
        }

        [Then(@"I see '(.*)' field invalid")]
        public void ThenISeeFieldInvalid(string field)
        {
            var employeeManagement = ScenarioContext.Current.Get<EmployeeManagementPage>();
            employeeManagement.IsFieldInvalid(field);
        }

        [Then(@"I see all the employee data is shown correctly")]
        public void ThenISeeAllTheEmployeeDataIsShownCorrectly()
        {
            var employeeManagement = ScenarioContext.Current.Get<EmployeeManagementPage>();
            employeeManagement.IsAllEmployeeDataCorrect();
        }

        [Then(@"I see (.*) button disabled")]
        public void ThenISeeButtonDisabled(string button)
        {
            var employeeManagement = ScenarioContext.Current.Get<EmployeeManagementPage>();
            employeeManagement.IsButtonDisabled(button);
        }

        [Then(@"I see the alert message '(.*)'")]
        public void ThenISeeTheAlertMessageTBeBlank(string alert)
        {
            var employeeManagement = ScenarioContext.Current.Get<EmployeeManagementPage>();
            employeeManagement.IsAlertThrownWithText(alert);
        }

        [Then(@"I don't see the deleted employee listed")]
        public void ThenIDonTSeeTheDeletedEmployeeListed()
        {
            var employeeManagement = ScenarioContext.Current.Get<EmployeeManagementPage>();
            Assert.IsFalse(employeeManagement.IsEmployeeListed(), "The employee created was found in the list");
        }

        [Then(@"I remove all employees such as '(.*)' plus '(.*)'")]
        public void ThenIRemoveAllEmployeesSuchAs(string firstname, string lastname)
        {
            string employee = firstname + " " + lastname;
            var employeeManagement = ScenarioContext.Current.Get<EmployeeManagementPage>();
            employeeManagement.RemoveAllEmployees(employee);
        }

        #endregion
    }
}
