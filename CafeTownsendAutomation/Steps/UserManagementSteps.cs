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
    public class UserManagementSteps
    {
        #region Given's
        #endregion

        #region When's
        [When(@"I fill in new user data with the following:")]
        public void WhenIFillInNewUserDataWithTheFollowing(Table table)
        {
            dynamic newUser = table.CreateDynamicInstance();
            var userManagement = ScenarioContext.Current.Get<UserManagementPage>();
            userManagement.FillInNewUserData(newUser.FirstName, newUser.LastName, newUser.StartDate, newUser.Email);
        }

        #endregion

        #region Then's

        [Then(@"I click on the '(.*)' button")]
        public void ThenIClickOnTheButton(string button)
        {
            var userManagement = ScenarioContext.Current.Get<UserManagementPage>();
            userManagement.ClickOnButton(button);
        }

        #endregion
    }
}
