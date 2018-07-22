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
        public struct Employee
        {
            public static string firstName;
            public static string lastName;
            public static string startDate;
            public static string email;
        }

        #region Given's
        #endregion

        #region When's
        [When(@"I fill in new employee data with the following:")]
        public void WhenIFillInNewEmployeeDataWithTheFollowing(Table table)
        {
            dynamic newUser = table.CreateDynamicInstance();
            Employee.firstName = newUser.FirstName;
            Employee.lastName = newUser.LastName;
            Employee.startDate = newUser.StartDate;
            Employee.email = newUser.Email;
            var employeeManagement = ScenarioContext.Current.Get<EmployeeManagementPage>();
            employeeManagement.FillInNewEmployeeData(Employee.firstName, Employee.lastName, Employee.startDate, Employee.email);
        }

        #endregion

        #region Then's

        [Then(@"I click on the '(.*)' button")]
        public void ThenIClickOnTheButton(string button)
        {
            var employeeManagement = ScenarioContext.Current.Get<EmployeeManagementPage>();
            employeeManagement.ClickOnButton(button);
        }

        [Then(@"I see the new user listed")]
        public void ThenISeeTheNewUserListed()
        {
            var employeeManagement = ScenarioContext.Current.Get<EmployeeManagementPage>();
            employeeManagement.IsTheLastEmployeeListedWith(Employee.firstName, Employee.lastName);
        }

        [Then(@"I accept the alert message '(.*)'")]
        public void ThenIAcceptTheAlertMessage(string alert)
        {
            var employeeManagement = ScenarioContext.Current.Get<EmployeeManagementPage>();
            employeeManagement.IsAlertThrownWithText(alert);
        }

        #endregion
    }
}
