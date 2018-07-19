using FundaSearchComponentBE.Tests;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeTownsendSelenium.Pages
{
    public class LoginLogoutPage : BaseTest
    {
        public LoginLogoutPage(IWebDriver driver) : base(driver)
        {
            PageFactory.InitElements(_driver, this);
        }
    }
}
