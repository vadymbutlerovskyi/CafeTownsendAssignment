using FundaSearchComponentBE.Tests;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeTownsendAutomation.Helpers
{
    public class ExtraActions : BaseTest
    {
        public ExtraActions(IWebDriver driver) : base(driver) {}

        public ExtraActions ClearFieldHardly(IWebElement element)
        {
            Actions action = new Actions(_driver);
            action.DoubleClick(element).Perform();
            do
            {
                action.SendKeys(Keys.Backspace).Perform();
            }
            while (element.GetAttribute("value").Length > 0);
            return this;
        }
    }
}
