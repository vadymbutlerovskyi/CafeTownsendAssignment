using CafeTownsendSelenium.Pages;
using NUnit.Framework;
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
        #region Given's
        #endregion

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
                employeeManagement.FillInNewEmployeeData(newEmployee.FirstName, newEmployee.LastName, newEmployee.StartDate.ToString("yyyy-MM-dd"), newEmployee.Email);
            }            
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
            employeeManagement.IsTheLastEmployeeListed();
        }

        [Then(@"I accept the alert message '(.*)'")]
        public void ThenIAcceptTheAlertMessage(string alert)
        {
            var employeeManagement = ScenarioContext.Current.Get<EmployeeManagementPage>();
            employeeManagement.IsAlertThrownWithText(alert);
        }

        [Then(@"I see '(.*)' field invalid")]
        public void ThenISeeFieldInvalid(string field)
        {
            var employeeManagement = ScenarioContext.Current.Get<EmployeeManagementPage>();
            employeeManagement.IsFieldInvalid(field);
        }

        [Then(@"I see all the employee data updated after edit")]
        public void ThenISeeAllTheEmployeeDataUpdatedAfterEdit()
        {
            var employeeManagement = ScenarioContext.Current.Get<EmployeeManagementPage>();
            employeeManagement.IsAllEmployeeDataCorrect();
        }
        #endregion
    }
}
