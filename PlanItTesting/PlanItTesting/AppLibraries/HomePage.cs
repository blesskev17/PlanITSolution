using NUnit.Framework;
using OpenQA.Selenium;
using PlanItTesting.Utilities;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanItTesting.AppLibraries
{
    public class HomePage : PageObjectBase
    {
        [FindsBy(How = How.XPath, Using = "//*[@id='nav-contact']/a")]
        private IWebElement _linkContact;

        [FindsBy(How = How.XPath, Using = "//*[@id='nav-shop']/a")]
        private IWebElement _linkShop;


        IWebDriver driver;


        public HomePage(IWebDriver driver) : base(driver)
        {

        }


        public void ClickContact()
        {
            try
            {
                if (_linkContact.Displayed)
                {
                    _linkContact.Click();
                }
            }
            catch (Exception ex)
            {
                Assert.Fail("Unable to click on Contact", ex);
            }
        }

        public void ClickShop()
        {
            try
            {
                if (_linkShop.Displayed)
                {
                    _linkShop.Click();
                }
            }
            catch (Exception ex)
            {
                Assert.Fail("Unable to click on Shop", ex);
            }
        }
    }
}
