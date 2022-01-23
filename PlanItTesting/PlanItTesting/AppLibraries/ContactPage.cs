using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using PlanItTesting.Utilities;
using SeleniumExtras.PageObjects;

namespace PlanItTesting.AppLibraries
{
    public class ContactPage : PageObjectBase

    {
        [FindsBy(How = How.XPath, Using = "//*[@id='forename']")]
        private IWebElement _txtForeName;

        [FindsBy(How = How.Id, Using = "surname")]
        private IWebElement _txtSurName;

        [FindsBy(How = How.Id, Using = "email")]
        private IWebElement _txtEmail;

        [FindsBy(How = How.Id, Using = "telephone")]
        private IWebElement _txtTelephone;

        [FindsBy(How = How.Id, Using = "message")]
        private IWebElement _txtMessage;

        [FindsBy(How = How.LinkText, Using = "Submit")]
        private IWebElement _btnSubmit;

        [FindsBy(How = How.XPath, Using = "//*[@class='ng-binding']")]
        private IWebElement _txtSuccessMessage;



        IWebDriver driver;

        public ContactPage(IWebDriver driver) : base(driver)
        {

        }
        public void enterFirstName(string forename)
        {

            _txtForeName.SendKeys(forename);
        }

        public void enterSurName(string surname)
        {
            _txtSurName.SendKeys(surname);
        }

        public void enterEmail(string email)
        {
            _txtEmail.SendKeys(email);
        }
        public void enterTelephone(string ph)
        {
            _txtTelephone.SendKeys(ph);
        }

        public void enterMessage(string message)
        {

            _txtMessage.SendKeys(message);
        }

        public void clickSubmit()
        {
            _btnSubmit.Click();
        }

        public void verifySuccessMessage()
        {
            if (_txtSuccessMessage.Text.Contains("Thanks"))
            {
                Console.WriteLine("Contact details has been submitted successfully");
            }
            else
            {
                Assert.Fail("Contact details has not been submitted successfully");

            }

        }
    }
}
