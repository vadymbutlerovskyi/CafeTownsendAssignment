using FundaSearchComponentBE.Tests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace FundaSearchComponentAutomation.Steps
{
    [Binding]
    public class BaseSteps
    {
        #region When's
        [When(@"I refresh the page")]
        public void WhenIRefreshThePage()
        {
            var test = ScenarioContext.Current.Get<BaseTest>();
            test.RefreshPage();
        }
        #endregion

        #region Then's
        [Then(@"I wait for '(.*)' second\(s\)")]
        public void ThenIWaitForSecond(int seconds)
        {
            var test = ScenarioContext.Current.Get<BaseTest>();
            test.WaitForSeconds(seconds);
        }

        [Then(@"I close browser")]
        public void ThenCloseTheBrowser()
        {
            var test = ScenarioContext.Current.Get<BaseTest>();
            test.Quit();
        }
        #endregion
    }
}