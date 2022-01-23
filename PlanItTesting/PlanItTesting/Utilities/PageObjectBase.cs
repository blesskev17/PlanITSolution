using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace PlanItTesting.Utilities
{

    public class PageObjectBase
    {
        protected IWebDriver _Driver;

        public PageObjectBase(IWebDriver driver)
        {

            _Driver = driver;
            PageFactory.InitElements(this, new RetryingElementLocator(_Driver, TimeSpan.FromSeconds(30), TimeSpan.FromMilliseconds(500)));
        }
    }
}