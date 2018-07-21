using CafeTownsendSelenium.Pages;
using FundaSearchComponentBE.Tests;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace CafeTownsendAutomation.Steps
{
    [Binding]
    public class LoginLogoutSteps
    {
        #region Given's

        [Given(@"I open browser and go to CafeTownsend home page")]
        public void GivenIOpenBrowserAndGoToCafeTownsendHomePage()
        {
            var test = new BaseTest(ConfigurationManager.AppSettings["cafeTownsendURL"]);

            var loginLogout = new LoginLogoutPage(test._driver);
            var basePage = new BaseTest(test._driver);

            ScenarioContext.Current.Clear();
            ScenarioContext.Current.Set(loginLogout);
            ScenarioContext.Current.Set(basePage);
        }

        #endregion

        #region When's

        [When(@"I click on the '(.*)' button")]
        public void WhenIClickOnTheLoginButton(string button)
        {
            var loginLogout = ScenarioContext.Current.Get<LoginLogoutPage>();
            loginLogout.ClickButton(button);
        }

        #endregion

        #region Then's
        [Then(@"I see that '(.*)' field is required to be filled")]
        public void ThenISeeThatUsernameFieldIsRequiredToBeFilled(string field)
        {
            var loginLogout = ScenarioContext.Current.Get<LoginLogoutPage>();
            Assert.IsTrue(loginLogout.IsFieldRequired(field), "The {0} field is required but was not found as such", field);
        }

        [Then(@"I enter '(.*)' into the '(.*)' field")]
        public void ThenIEnterIntoTheField(string value, string field)
        {
            var loginLogout = ScenarioContext.Current.Get<LoginLogoutPage>();
            loginLogout.InputIntoTheField(value, field);
        }

        [Then(@"I see the error message '(.*)'")]
        public void ThenISeeTheErrorMessage(string error)
        {
            var loginLogout = ScenarioContext.Current.Get<LoginLogoutPage>();
            string errorUI = loginLogout.GetErrorInvalidCredentials();
            Assert.AreEqual(errorUI, error, "The error of invalid credentials {0}", errorUI == null ? "is not shown" : "don't match with given");    
        }

        [Then(@"I see the greeting message '(.*)''(.*)'")]
        public void ThenISeeTheGreetingMessage(string greeting, string username)
        {
            var loginLogout = ScenarioContext.Current.Get<LoginLogoutPage>();
            string greetingUI = loginLogout.IsGreetingMessage(greeting);
            Assert.AreEqual(greetingUI, greeting + username, "The greeting message {0}", greetingUI == null ? "is not shown" : "don't match with given");
        }

        #endregion
    }
}
