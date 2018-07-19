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
        #region Then's

        [Then(@"I wait for '(.*)' second\(s\)")]
        public void ThenIWaitForSecond(int seconds)
        {
            Thread.Sleep(seconds * 1000);
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