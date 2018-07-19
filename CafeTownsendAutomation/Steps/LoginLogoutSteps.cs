using CafeTownsendSelenium.Pages;
using FundaSearchComponentBE.Tests;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
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
        #endregion

        #region Then's
        #endregion
    }
}
